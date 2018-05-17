#ifndef _DIRECTIONS_H
#define _DIRECTIONS_H

#include <stdio.h>

void Forward(uint8_t* s, uint8_t* M1_PWM, uint8_t* M1_Dir1, uint8_t* M1_Dir2, uint8_t* M2_PWM, uint8_t* M2_Dir1, uint8_t* M2_Dir2);
void Backward(uint8_t* s, uint8_t* M1_PWM, uint8_t* M1_Dir1, uint8_t* M1_Dir2, uint8_t* M2_PWM, uint8_t* M2_Dir1, uint8_t* M2_Dir2);
void Left(uint8_t* s, uint8_t* M1_PWM, uint8_t* M1_Dir1, uint8_t* M1_Dir2, uint8_t* M2_PWM, uint8_t* M2_Dir1, uint8_t* M2_Dir2);
void Right(uint8_t* s, uint8_t* M1_PWM, uint8_t* M1_Dir1, uint8_t* M1_Dir2, uint8_t* M2_PWM, uint8_t* M2_Dir1, uint8_t* M2_Dir2);
void ChangeSpeed(uint8_t* s, uint8_t* M1_PWM, uint8_t* M2_PWM);
void Stop(uint8_t* M2_Dir1, uint8_t* M2_Dir2, uint8_t* M1_Dir1, uint8_t* M1_Dir2);

#endif
