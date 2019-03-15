/*
 * Uart.h
 *
 *  Created on: Mar 19, 2016
 *      Author: Satu
 */

#ifndef UART_UART_H_
#define UART_UART_H_

#include "include.h"

extern void Config_Uart(uint32_t baudrate );
extern bool Is_Update_UART(char *buff);
extern void Finish_cycle(void);
extern void UARTNum_Put(uint8_t port, int32_t num);


#endif /* UART_UART_H_ */
