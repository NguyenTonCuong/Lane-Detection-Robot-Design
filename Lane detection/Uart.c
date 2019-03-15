/*
 * Uart.c
 *
 *  Created on: Mar 19, 2016
 *      Author: Satu
 */

//module UART, dung de nhan code CNC tu PC chuyen xuong
//sau do tach chuoi nhan duoc luu vao trong bo dem buffer[] de tien hanh xu ly tiep



#include "Uart.h"



//static void UART1_ISR(void);

void Config_Uart(uint32_t baudrate)	//A0, A1
{
	ROM_SysCtlPeripheralEnable(SYSCTL_PERIPH_UART0);
	ROM_SysCtlPeripheralEnable(SYSCTL_PERIPH_GPIOA);
	ROM_GPIOPinConfigure(GPIO_PA0_U0RX);
	ROM_GPIOPinConfigure(GPIO_PA1_U0TX);
	ROM_GPIOPinTypeUART(GPIO_PORTA_BASE, GPIO_PIN_0 | GPIO_PIN_1);
	ROM_UARTClockSourceSet(UART0_BASE, UART_CLOCK_SYSTEM);

	UARTStdioConfig(0, baudrate,ROM_SysCtlClockGet());
	//UARTIntRegister(UART0_BASE,&UART0_ISR);
	ROM_UARTEnable(UART0_BASE);
	//ROM_IntEnable(INT_UART0);
	//ROM_UARTIntEnable(UART0_BASE, UART_INT_RX | UART_INT_RT);

	ROM_SysCtlPeripheralEnable(SYSCTL_PERIPH_UART1);
	ROM_SysCtlPeripheralEnable(SYSCTL_PERIPH_GPIOB);
	ROM_GPIOPinConfigure(GPIO_PB0_U1RX);
	ROM_GPIOPinConfigure(GPIO_PB1_U1TX);
	ROM_GPIOPinTypeUART(GPIO_PORTB_BASE, GPIO_PIN_0 | GPIO_PIN_1);
	ROM_UARTClockSourceSet(UART1_BASE, UART_CLOCK_SYSTEM);

	UARTStdioConfig(1, baudrate,ROM_SysCtlClockGet());
//	UARTIntRegister(UART1_BASE,&UART1_ISR);
	ROM_UARTEnable(UART1_BASE);
//	ROM_IntEnable(INT_UART1);
//	ROM_UARTIntEnable(UART1_BASE, UART_INT_RX | UART_INT_RT);

}

/*static void UART1_ISR(void)
{
	UARTIntClear(UART1_BASE,UARTIntStatus(UART1_BASE,true));
	//uint32_t c=ROM_UARTCharGet(UART1_BASE);
	if(ROM_UARTCharGet(UART1_BASE)=='@')
		ROM_GPIOPinWrite(GPIO_PORTF_BASE,GPIO_PIN_1,GPIO_PIN_1);
}
*/

