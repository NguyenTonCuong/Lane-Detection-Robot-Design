/*
 * motor.h
 *
 *  Created on: Nov 18, 2018
 *      Author: NGUYEN_CUONG_PC
 */

#ifndef MOTOR_H_
#define MOTOR_H_

#define LED_RED		GPIO_PIN_1
#define LED_BLUE	GPIO_PIN_2
#define LED_GREEN	GPIO_PIN_3

#define MOTOR1_DIR1 GPIO_PIN_4
#define MOTOR2_DIR1 GPIO_PIN_6

extern void Config_MOTOR(void);
extern void Config_PWM(void);

extern void motorForward(void);
extern void motorLeft(void);
extern void motorRight(void);
extern void motorStop(void);
extern void motorEnable(void);


#endif /* MOTOR_H_ */
