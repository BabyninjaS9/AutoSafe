#include <stdio.h>
#include <Arduino.h>

uint8_t GetDistance(uint8_t* trigPin, uint8_t* echoPin, float* distance){
  if(trigPin != NULL || echoPin != NULL || distance != NULL){
    long duration;
    // Clears the trigPin
    digitalWrite(*trigPin, LOW);
    delayMicroseconds(2);
    // Sets the trigPin on HIGH state for 10 micro seconds
    digitalWrite(*trigPin, HIGH);
    delayMicroseconds(10);
    digitalWrite(*trigPin, LOW);
    // Reads the echoPin, returns the sound wave travel time in microseconds
    duration = pulseIn(*echoPin, HIGH);
    // Calculating the distance
    float calculatedDistance = duration * 0.034 / 2;
    delay(10);

    if(calculatedDistance < 1000){
        *distance = calculatedDistance;
        //Serial.println(*distance);
        return 1;
      }
    return 0;
  }
  else{
    return -1;
  }
}
