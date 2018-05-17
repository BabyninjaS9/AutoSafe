#include <stdio.h>
#include <Arduino.h>
#include "directions.h"
#include "sensors.h"

uint8_t   M1_PWM  = 6;  //MOTOR 1
uint8_t   M1_Dir1 = 7;
uint8_t   M1_Dir2 = 8;

uint8_t  M2_PWM  = 11; //MOTOR 2
uint8_t  M2_Dir1 = 10;
uint8_t  M2_Dir2 =  9;

uint8_t U1_trigPin = 2;   //ultrasone sensor 1
uint8_t U1_echoPin = 4;

uint8_t U2_trigPin = 12;  //ultrasone sensor 2
uint8_t U2_echoPin = 13;

uint8_t Speed = 255;
float distance1 = 0;
float distance2 =0;

void setup()
{
  Serial.begin(9600);

  pinMode(M1_PWM, OUTPUT);    //MOTOR 1
  pinMode(M1_Dir1, OUTPUT);
  pinMode(M1_Dir2, OUTPUT);

  pinMode(M2_PWM, OUTPUT);    //MOTOR 2
  pinMode(M2_Dir1, OUTPUT);
  pinMode(M2_Dir2, OUTPUT);

  pinMode(U1_trigPin, OUTPUT); //ultasone sensor 1
  pinMode(U1_echoPin, INPUT);

  pinMode(U2_trigPin, OUTPUT);  //ultrasone sensor 2
  pinMode(U2_echoPin, INPUT);
}

void loop()
{
  Forward(&Speed, &M1_PWM, &M1_Dir1, &M1_Dir2, &M2_PWM, &M2_Dir1, &M2_Dir2);
  Serial.println("Forward");
  delay(1000);
  Stop(&M2_Dir1, &M2_Dir2, &M1_Dir1, &M1_Dir2);
  Serial.println("Stop");
  delay(1000);
  Backward(&Speed, &M1_PWM, &M1_Dir1, &M1_Dir2, &M2_PWM, &M2_Dir1, &M2_Dir2);
  Serial.println("Backward");
  delay(1000);
  Left(&Speed, &M1_PWM, &M1_Dir1, &M1_Dir2, &M2_PWM, &M2_Dir1, &M2_Dir2);
  Serial.println("Left");
  delay(1000);
  Right(&Speed, &M1_PWM, &M1_Dir1, &M1_Dir2, &M2_PWM, &M2_Dir1, &M2_Dir2);
  Serial.println("Right");
  delay(1000);

  uint8_t DUS1 = GetDistance(&U1_trigPin, &U1_echoPin, &distance1);
  if(DUS1 == 1){
    Serial.println(distance1);
  }

  uint8_t DUS2 = GetDistance(&U2_trigPin, &U2_echoPin, &distance2);
  if(DUS2 == 1){
    Serial.println(distance2);
  }

}
