#ifndef _MOTOREN_H
#define _MOTOREN_H

#include <stdio.h>

void MotorLeftForward(uint8_t* s, uint8_t* M1_PWM, uint8_t* M1_Dir1, uint8_t* M1_Dir2);
void MotorRightForward(uint8_t* s, uint8_t* M2_PWM, uint8_t* M2_Dir1, uint8_t* M2_Dir2);
void MotorLeftBackward(uint8_t* s, uint8_t* M1_PWM, uint8_t* M1_Dir1, uint8_t* M1_Dir2);
void MotorRightBackward(uint8_t* s, uint8_t* M2_PWM, uint8_t* M2_Dir1, uint8_t* M2_Dir2);

#endif
