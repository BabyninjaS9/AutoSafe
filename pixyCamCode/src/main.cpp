#include <Arduino.h>
#include <functions.h>

#include <Pixy.h>

Pixy pixy;

typedef struct{
  int signatureID;
  //arrays to calculate moving average
  int X[10];
  int Y[10];
  int with[10];
  int height[10];
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
    printSignatures(allSignatureData, 7);
    //printSignaturePos(&pixy, count, 1, 0);
    delay(500);
}
