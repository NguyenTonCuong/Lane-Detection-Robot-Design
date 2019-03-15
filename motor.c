/*
 * motor.c
 *
 *  Created on: Nov 18, 2018
 *      Author: NGUYEN_CUONG_PC
 */

#include "include.h"
#include "motor.h"
#include "srf05.h"



int32_t PID_Saturation=200;//MAX DUTY
int32_t averageSpeed1  = 65;
int32_t averageSpeed2  = 65;

uint64_t u64_DutyCycle1 = 100;   //Duty cycle of PWM
uint64_t u64_DutyCycle2 = 100;   //Duty cycle of PWM
uint64_t u64_Period1;           //Period of PWM
uint64_t u64_Period2;           //Period of PWM


extern void Config_MOTOR(void);
extern void Config_PWM(void);

extern void motorForward(void);
extern void motorLeft(void);
extern void motorRight(void);
extern void motorStop(void);
extern void motorEnable(void);

extern void Config_MOTOR(void)
{
	SysCtlPeripheralEnable(SYSCTL_PERIPH_GPIOF);             // enable portF
	GPIOPinTypeGPIOOutput(GPIO_PORTF_BASE, LED_RED|LED_GREEN|LED_BLUE);             // cau hinh output PF123
	GPIOPinWrite(GPIO_PORTF_BASE, LED_RED|LED_BLUE|LED_GREEN, 0);
	SysCtlPeripheralEnable(SYSCTL_PERIPH_GPIOE);             // enable portE
	GPIOPinTypeGPIOOutput(GPIO_PORTE_BASE, MOTOR1_DIR1);
	GPIOPinWrite(GPIO_PORTE_BASE, MOTOR1_DIR1,  ~MOTOR1_DIR1);
	SysCtlPeripheralEnable(SYSCTL_PERIPH_GPIOA);             // enable portA
	GPIOPinTypeGPIOOutput(GPIO_PORTA_BASE, MOTOR2_DIR1);     // cau hinh output PF123
	GPIOPinWrite(GPIO_PORTA_BASE, MOTOR2_DIR1,  ~MOTOR2_DIR1);
}

extern void Config_PWM(void)
{
	//Configure PWM clock to match system
	SysCtlPWMClockSet(SYSCTL_PWMDIV_1);
	// config PWM GEN2
	//Enable the peripherals used by this program.
	SysCtlPeripheralEnable(SYSCTL_PERIPH_PWM1);//Tiva Launchpad has 2 modules (0 and 1) and module 1 covers led pins
	SysCtlPeripheralEnable(SYSCTL_PERIPH_GPIOF);

	//Configure PF1 pins as PWM
	GPIOPinConfigure(GPIO_PF1_M1PWM5);
	GPIOPinTypePWM(GPIO_PORTF_BASE, GPIO_PIN_1);
	//Configure PWM Options
	PWMGenConfigure(PWM1_BASE, PWM_GEN_2, PWM_GEN_MODE_DOWN | PWM_GEN_MODE_NO_SYNC);
	PWMGenPeriodSet(PWM1_BASE, PWM_GEN_2, PID_Saturation);//PWM frequency = 200Hz
	PWMPulseWidthSet(PWM1_BASE, PWM_OUT_5, u64_DutyCycle1);

	//Turn on the Output pins
	PWMOutputState(PWM1_BASE, PWM_OUT_5_BIT, true);
	PWMGenDisable(PWM1_BASE, PWM_GEN_2);
	//Enable the peripherals used by this program.
	SysCtlPeripheralEnable(SYSCTL_PERIPH_PWM1);//Tiva Launchpad has 2 modules (0 and 1) and module 1 covers led pins
	SysCtlPeripheralEnable(SYSCTL_PERIPH_GPIOF);
	//Configure PF2 pins as PWM
	GPIOPinConfigure(GPIO_PF2_M1PWM6);
	GPIOPinTypePWM(GPIO_PORTF_BASE, GPIO_PIN_2);
	//Configure PWM Options
	PWMGenConfigure(PWM1_BASE, PWM_GEN_3, PWM_GEN_MODE_DOWN | PWM_GEN_MODE_NO_SYNC);
	PWMGenPeriodSet(PWM1_BASE, PWM_GEN_3,PID_Saturation);//PWM frequency = 200Hz
	PWMPulseWidthSet(PWM1_BASE, PWM_OUT_6, u64_DutyCycle2);
	//Turn on the Output pins
	PWMOutputState(PWM1_BASE, PWM_OUT_6_BIT, true);
	PWMGenDisable(PWM1_BASE, PWM_GEN_3);
}

extern void motorForward(void)
{
	GPIOPinWrite(GPIO_PORTE_BASE, MOTOR1_DIR1,  ~MOTOR1_DIR1);
	GPIOPinWrite(GPIO_PORTA_BASE, MOTOR2_DIR1,  ~MOTOR2_DIR1);
	u64_DutyCycle1= 75;
	u64_DutyCycle2= 75;
	motorEnable();
}

extern void motorLeft(void)
{
	GPIOPinWrite(GPIO_PORTE_BASE, MOTOR1_DIR1,  ~MOTOR1_DIR1);
	GPIOPinWrite(GPIO_PORTA_BASE, MOTOR2_DIR1,  ~MOTOR2_DIR1);
	u64_DutyCycle1= 75;	//quick
	u64_DutyCycle2= 40;
	motorEnable();
}

extern void motorRight(void)
{
	GPIOPinWrite(GPIO_PORTE_BASE, MOTOR1_DIR1,  ~MOTOR1_DIR1);
	GPIOPinWrite(GPIO_PORTA_BASE, MOTOR2_DIR1,  ~MOTOR2_DIR1);
	u64_DutyCycle1= 40;
	u64_DutyCycle2= 75;	//quick
	motorEnable();
}
extern void motorStop(void)
{
	GPIOPinWrite(GPIO_PORTE_BASE, MOTOR1_DIR1,  ~MOTOR1_DIR1);
	GPIOPinWrite(GPIO_PORTA_BASE, MOTOR2_DIR1,  ~MOTOR2_DIR1);
	u64_DutyCycle1= 1;
	u64_DutyCycle2= 1;
	motorEnable();
}

extern void motorEnable(void)
{
	PWMPulseWidthSet(PWM1_BASE, PWM_OUT_5,u64_DutyCycle1);
	PWMPulseWidthSet(PWM1_BASE, PWM_OUT_6,u64_DutyCycle2);
	PWMGenEnable(PWM1_BASE, PWM_GEN_2);
	PWMGenEnable(PWM1_BASE, PWM_GEN_3);
}






