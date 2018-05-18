#include <Arduino.h>
#include <functions.h>
#include <protocol.h>

#include <Pixy.h>

Pixy pixy;

unsigned long lastPrintMillis = 0;

typedef struct{
  uint8_t signatureID;
  //arrays to calculate moving average
  uint16_t X[10];
  uint16_t Y[10];
}SignatureData;

SignatureData allSignatureData[7] = {
  {.signatureID = 1},
  {.signatureID = 2},
  {.signatureID = 3},
  {.signatureID = 4},
  {.signatureID = 5},
  {.signatureID = 6},
  {.signatureID = 7}
};

void setup()
{
    Serial.begin(9600);
    pixy.init();
}

//Updates SignatureData array and calculates average position
//if multiple block are detected with the same signature
void processData(Pixy* pixyCam, int count){
  for(int i = 0; i < 7; i++){
    int numberOfBlocks = 0;
    int totalX = 0;
    int totalY = 0;
    bool found = false;

    for(int j = 0; j < count; j++){
      if((int)pixyCam->blocks[j].signature == allSignatureData[i].signatureID){
          //A block has been found with the right signature
          found = true;
          numberOfBlocks++;
          totalX += pixyCam->blocks[j].x;
          totalY += pixyCam->blocks[j].y;
      }
    }
    //Shift X and Y position array
    for(int j = 0; j < 9; j++){
      allSignatureData[i].X[j + 1] = allSignatureData[i].X[j];
      allSignatureData[i].Y[j + 1] = allSignatureData[i].Y[j];
    }
    if(found){
      //Add new X and Y values
      allSignatureData[i].X[0] = totalX / numberOfBlocks;
      allSignatureData[i].Y[0] = totalY / numberOfBlocks;
    }
    //Repeat for every signature in array
  }
}

//Sends the position data according to the protocol
void sendPositionProtocol(SignatureData* data, int count){
  //data [signature] 1 byte [X] 2 bytes [Y] 2 bytes
  uint8_t packetData[count * 5];
  for(int i = 0; i < count; i++){
    //Get moving average X and Y
    uint16_t totalX = 0;
    uint16_t totalY = 0;
    for(int j = 0; j < 10; j++){
      totalX += data[i].X[j];
      totalY += data[i].Y[j];
    }
    uint16_t X = totalX / 10;
    uint16_t Y = totalY / 10;

    //Create data
    packetData[i * 5] = (data[i].signatureID);
    packetData[i * 5 + 1] = X & 0x0F;
    packetData[i * 5 + 2] = X >> 8;
    packetData[i * 5 + 3] = Y & 0x0F;
    packetData[i * 5 + 4] = Y >> 8;
  }

  //Make data packet
  struct packet packet =
  {
    .magic =  0x0EE0,
    .length = uint16_t(count * 5 + 6),
    .category = 1,
    .command = 5,
    .payload = packetData,
    .checksum = 0
  };

  //serialize data
  uint8_t serialData;
  size_t size;
  if(packet_serialize(&packet, &serialData, &size) == 0){
    //send data
    for(unsigned int i = 0; i < size; i++){
      Serial.write((&serialData)[i]);
    }
  }
}

//Prints X and Y values of the signature data in the array
void printSignatures(SignatureData* data, int count){
  Serial.println("==================");
  for(int i = 0; i < count; i++){
    Serial.print("Signature" + (String)data[i].signatureID + ": ");
    int totalX = 0;
    int totalY = 0;
    for(int j = 0; j < 10; j++){
      totalX += data[i].X[j];
      totalY += data[i].Y[j];
    }
    int X = totalX / 10;
    int Y = totalY / 10;
    Serial.println("x " + (String)X + " y " + (String)Y);
  }
}

//Prints the X and Y values of the blocks the pixycam provice
void printBlocksXY(Pixy* pixyCam, int count){
  Serial.println("Found " + (String)count + " signatures");
  for(int i = 0; i < count; i++){
    Serial.print("Detected signature ");
    Serial.println(pixyCam->blocks[i].signature);
    Serial.print("   X: ");
    Serial.println(pixyCam->blocks[i].x);
    Serial.print("   Y: ");
    Serial.println(pixyCam->blocks[i].y);
  }
  Serial.println("========================");
}

//Prints the X or Y value of one signature provided by the pixycam
void printSignaturePos(Pixy* pixyCam, int count, int signature, int XorY){
  for(int i = 0; i < count; i++){
    if((int)pixyCam->blocks[i].signature == signature){
      if(XorY == 0){
        Serial.println(pixyCam->blocks[i].x);
      }
      else if(XorY == 1){
        Serial.println(pixyCam->blocks[i].y);
      }
    }
  }
}

void loop()
{
    int count = pixy.getBlocks();
    //printBlocksXY(&pixy, count);
    processData(&pixy, count);
    if(lastPrintMillis < millis() - 1000){
      lastPrintMillis = millis();
      printSignatures(allSignatureData, 7);
    }
    //printSignaturePos(&pixy, count, 1, 0);
}
