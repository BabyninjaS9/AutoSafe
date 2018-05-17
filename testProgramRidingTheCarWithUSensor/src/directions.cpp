#include <stdio.h>
#include <Arduino.h>
#include "motoren.h"

void Forward(uint8_t* s, uint8_t* M1_PWM, uint8_t* M1_Dir1, uint8_t* M1_Dir2, uint8_t* M2_PWM, uint8_t* M2_Dir1, uint8_t* M2_Dir2){
if(s != NULL || M1_PWM != NULL || M1_Dir1 != NULL || M1_Dir2 != NULL || M2_PWM != NULL || M2_Dir1!= NULL || M2_Dir2 != NULL){
  MotorLeftForward(s, M1_PWM, M1_Dir1, M1_Dir2);
  MotorRightForward(s, M2_PWM, M2_Dir1, M2_Dir2);
  }
}

void Backward(uint8_t* s, uint8_t* M1_PWM, uint8_t* M1_Dir1, uint8_t* M1_Dir2, uint8_t* M2_PWM, uint8_t* M2_Dir1, uint8_t* M2_Dir2){
if(s != NULL || M1_PWM != NULL || M1_Dir1 != NULL || M1_Dir2 != NULL || M2_PWM != NULL || M2_Dir1!= NULL || M2_Dir2 != NULL){
  MotorLeftBackward(s, M1_PWM, M1_Dir1, M1_Dir2);
  MotorRightBackward(s, M2_PWM, M2_Dir1, M2_Dir2);
  }
}

void Left(uint8_t *s, uint8_t* M1_PWM, uint8_t* M1_Dir1, uint8_t* M1_Dir2, uint8_t* M2_PWM, uint8_t* M2_Dir1, uint8_t* M2_Dir2){
if(s != NULL || M1_PWM != NULL || M1_Dir1 != NULL || M1_Dir2 != NULL || M2_PWM != NULL || M2_Dir1!= NULL || M2_Dir2 != NULL){
  MotorLeftBackward(s, M1_PWM, M1_Dir1, M1_Dir2);
  MotorRightForward(s, M2_PWM, M2_Dir1, M2_Dir2);
  }
}

void Right(uint8_t* s, uint8_t* M1_PWM, uint8_t* M1_Dir1, uint8_t* M1_Dir2, uint8_t* M2_PWM, uint8_t* M2_Dir1, uint8_t* M2_Dir2){
if(s != NULL || M1_PWM != NULL || M1_Dir1 != NULL || M1_Dir2 != NULL || M2_PWM != NULL || M2_Dir1!= NULL || M2_Dir2 != NULL){
  MotorLeftForward(s, M1_PWM, M1_Dir1, M1_Dir2);
  MotorRightBackward(s, M2_PWM, M2_Dir1, M2_Dir2);
  }
}

void ChangeSpeed(uint8_t* s, uint8_t* M1_PWM, uint8_t* M2_PWM){
  if(s != NULL || M1_PWM != NULL || M2_PWM != NULL){
    analogWrite(*M1_PWM, *s);
    analogWrite(*M2_PWM, *s);
  }
}

void Stop(uint8_t* M2_Dir1, uint8_t* M2_Dir2, uint8_t* M1_Dir1, uint8_t* M1_Dir2){
if(M2_Dir1 != NULL || M2_Dir2 != NULL || M1_Dir1 != NULL || M1_Dir2 != NULL){
  digitalWrite(*M2_Dir1, LOW);
  digitalWrite(*M2_Dir2, LOW);
  digitalWrite(*M1_Dir1, LOW);
  digitalWrite(*M1_Dir2, LOW);
  }
}
