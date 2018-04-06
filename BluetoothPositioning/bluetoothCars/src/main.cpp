#include <Arduino.h>
#include <SoftwareSerial.h>
#include <string.h>
#include <stdlib.h>

int BT_TX = 6;
int BT_RX = 5;
bool addSearch = false;
String woord = "";

SoftwareSerial BTSerial(BT_RX, BT_TX);

void startUpPrint()
{
    for(int i = 0; i < 8; i++)
    {
        if(i == 0)
        {
            Serial.print("\nBT STATE: ");
            BTSerial.println("AT+STATE?");
        }
        else if(i == 1)
        {
            Serial.print("\nBT NAME: ");
            BTSerial.println("AT+NAME?");
        }
        else if(i == 2)
        {
            Serial.print("\nBT LAST CONNECTED: ");
            BTSerial.println("AT+MRAD?");
        }
        else if(i == 3)
        {
            Serial.print("\nBT CLASS: ");
            BTSerial.println("AT+CLASS?");
        }
        else if(i == 4)
        {
            Serial.print("\nBT CMODE: ");
            BTSerial.println("AT+CMODE=1");
        }
        else if(i == 5)
        {
            Serial.print("\nBT ROLE: ");
            BTSerial.println("AT+ROLE=0");
        }
        else if(i == 6)
        {
            Serial.print("BT INQM: ");
            BTSerial.println("AT+INQM=1,90,5");
        }
        else if(i == 7)
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

void searchDevices()
{
    Serial.println("\nFound devices nearby");
    Serial.println("--------------------");
    delay(500);
    addSearch = true;
    BTSerial.println("AT+INQ");

}

void setup()
{
    Serial.begin(9600);
    while(!Serial);
    BTSerial.begin(38400);
    delay(2000);
    startUpPrint();
    searchDevices();
}

void loop()
{
    if(addSearch)
    {
        while(BTSerial.available() > 0)
        {
            char c = (char)BTSerial.read();
            if(c == '\n')
            {
                Serial.println(woord);
                String hexString = woord.substring(woord.lastIndexOf(',') + 1);
                char* hex_p = &hexString[0];
                long distanceValue = strtol(hex_p, NULL , 16);
                Serial.print("RSSI: ");
                Serial.println(distanceValue);
                woord = "";
            }
            else
            {
                woord.concat(c);
            }

            if(woord == "OK")
            {
                addSearch = false;
                Serial.println("Done looping");
            }
        }
        //24df:6a:e5d1bb
        //Serial.println("Out of while");
    }

    if(addSearch == false)
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

}
