#include <TM1637Display.h>

// Define pins for TM1637 display
#define CLK 2
#define DIO 3

// Define pin for motor (PWM capable)
#define MOTOR_PIN 9

TM1637Display display(CLK, DIO);

int speed = 0;

void setup() {
  Serial.begin(9600);
  display.setBrightness(0x0f); // Max brightness
  pinMode(MOTOR_PIN, OUTPUT);
}

void loop() {
  if (Serial.available() > 0) {
    String data = Serial.readStringUntil('\n');
    speed = data.toInt();
    // Clamp speed to 0-999 for display
    speed = constrain(speed, 0, 999);
    display.showNumberDec(speed, false); // Display speed without leading zeros
    // Map speed to motor PWM (0-255)
    int motorSpeed = map(speed, 0, 100, 0, 255); // Assuming speed 0-100
    analogWrite(MOTOR_PIN, motorSpeed);
  }
}