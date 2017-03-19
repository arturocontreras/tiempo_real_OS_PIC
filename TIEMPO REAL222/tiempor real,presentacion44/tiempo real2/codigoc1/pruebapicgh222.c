#include <18f452.h>
#FUSES HS,NOPROTECT,NOWDT,NOlvP
#use delay(clock=20000000)
#use rs232(baud=9600,xmit=PIN_C6,rcv=PIN_C7,bits=8)
#define LCD_ENABLE_PIN  PIN_D2                                   ////
#define LCD_RS_PIN      PIN_D0                                    ////
#define LCD_RW_PIN      PIN_D1                                    ////
#define LCD_DATA4       PIN_D4                                    ////
#define LCD_DATA5       PIN_D5                                    ////
#define LCD_DATA6       PIN_D6                                    ////
#define LCD_DATA7       PIN_D7                                    ////
#include <LCD.c> 
//definiendo puertos
#byte tris_a =0xf92
#byte port_a =0xf80
#byte tris_b =0xf93
#byte port_b =0xf81
#byte tris_c =0xf94
#byte port_c =0xf82
#byte tris_d =0xf95
#byte port_d =0xf83
#byte tris_e =0xf96
#byte port_e =0xf84
//definiendo bits
#bit rb0=port_b.0 //
#bit rb1=port_b.1 //
#bit rb2=port_b.2 //
#bit rb3=port_b.3 //
#bit rd2=port_d.2 //
#bit rd3=port_d.3 //
int cnt=0;
#int_timer0
void timer0_isr(){
delay_ms(246);
cnt++;
   rb1=!rb1;
   rb2=!rb2;
   set_timer0(0x01);
  
  
}
//!#int_rda 
//!void RDA_isr(){
//if(cnt<=2){
//! rb0=!rb0;
//! rb3=!rb3;
//! delay_ms(30);
//}
//if(cnt>//2){
//rb3=1;
//rb0=1;
//}
//!}
//!

void main(){
setup_timer_0(rtcc_internal | rtcc_div_16);
set_timer0(0x01);
enable_interrupts(global);
enable_interrupts(int_rda);
enable_interrupts(int_timer0);
tris_b=0;
tris_d=0;
port_b=1;
port_d=0;


}
