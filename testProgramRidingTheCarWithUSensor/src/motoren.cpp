#include <stdio.h>
#include <Arduino.h>

void MotorLeftForward(uint8_t* s, uint8_t* M1_PWM, uint8_t* M1_Dir1, uint8_t* M1_Dir2){
if(s != NULL || M1_PWM != NULL || M1_Dir1 != NULL || M1_Dir2 != NULL){
  analogWrite(*M1_PWM, *s);
  digitalWrite(*M1_Dir1, LOW);
  digitalWrite(*M1_Dir2, HIGH);
  }
}

void MotorRightForward(uint8_t* s, uint8_t* M2_PWM, uint8_t* M2_Dir1, uint8_t* M2_Dir2){
if(s != NULL || M2_PWM != NULL || M2_Dir1 != NULL || M2_Dir2 != NULL){
  analogWrite(*M2_PWM, *s);
  digitalWrite(*M2_Dir1, LOW);
  digitalWrite(*M2_Dir2, HIGH);
  }
}

void MotorLeftBackward(uint8_t* s, uint8_t* M1_PWM, uint8_t* M1_Dir1, uint8_t* M1_Dir2){
if(s != NULL || M1_PWM != NULL || M1_Dir1 != NULL || M1_Dir2 != NULL){
  analogWrite(*M1_PWM, *s);
  digitalWrite(*M1_Dir1, HIGH);
  digitalWrite(*M1_Dir2, LOW);
  }
}

void MotorRightBackward(uint8_t* s, uint8_t* M2_PWM, uint8_t* M2_Dir1, uint8_t* M2_Dir2){
if(s != NULL || M2_PWM != NULL || M2_Dir1 != NULL || M2_Dir2 != NULL){
  analogWrite(*M2_PWM, *s);
  digitalWrite(*M2_Dir1, HIGH);
  digitalWrite(*M2_Dir2, LOW);
  }
}
