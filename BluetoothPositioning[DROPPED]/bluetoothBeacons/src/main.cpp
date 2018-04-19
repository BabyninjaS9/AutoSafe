#include <Arduino.h>
#include <SoftwareSerial.h>
#include <string.h>
#include <stdlib.h>

int BT_TX = 6;
int BT_RX = 5;
bool addSearch = false;
String woord = "";

SoftwareSerial BTSerial(BT_RX, BT_TX);

void setAndStartBluetooth()
{
    for(int i = 0; i < 7; i++)
    {
        if(i == 0)
        {
            Serial.print("\nBT STATE: ");
            BTSerial.println("AT+STATE?");
        }
        else if(i == 1)
        {
            Serial.print("\nBT NAME: ");
            BTSerial.println("AT+NAME=Beacon1");
        }
        else if(i == 2)
        {
            Serial.print("\nBT LAST CONNECTED: ");
            BTSerial.println("AT+MRAD?");
        }
        else if(i == 3)
        {
            Serial.print("\nBT CLASS: ");
            BTSerial.println("AT+CLASS=16");
        }
        else if(i == 4)
        {
            Serial.print("\nBT CMODE: ");
            BTSerial.println("AT+CMODE=0");
        }
        else if(i == 5)
        {
            Serial.print("\nBT ROLE: ");
            BTSerial.println("AT+ROLE=0");
        }
        else if(i == 6)
        {
            Serial.print("\nBT INIT: ");
            BTSerial.println("AT+INIT");
        }
        delay(500);
        while(BTSerial.available())
        {
            Serial.write(BTSerial.read());
        }
    }
}

void setup()
{
    Serial.begin(9600);
    while(!Serial);
    BTSerial.begin(38400);
    setAndStartBluetooth();
}

void loop()
{
    if (BTSerial.available())
    {
        Serial.write(BTSerial.read());
    }

    if (Serial.available())
    {
        BTSerial.write(Serial.read());
    }
}
