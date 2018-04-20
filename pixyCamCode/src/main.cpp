#include <Arduino.h>
#include <functions.h>

#include <Pixy.h>

Pixy pixy;

void setup()
{
    Serial.begin(9600);
    pixy.init();
}

void loop()
{

}
