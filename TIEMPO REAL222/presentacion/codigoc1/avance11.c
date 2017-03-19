#include <16f887.h>
#fuses XT,NOPROTECT,NOWDT
#use delay(clock=4000000)
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
#byte tris_a =0x85
#byte port_a =0x05
#byte tris_b =0x86
#byte port_b =0x06
#byte tris_c =0x87
#byte port_c =0x07
#byte tris_d =0x88
#byte port_d =0x08
#byte tris_e =0x89
#byte port_e =0x09
//definiendo bits
#bit rb0=port_b.0 //quantum
#bit rb1=port_b.1 //proceso1
#bit rb2=port_b.2 //proceso2
#bit rb3=port_b.3 //proceso3
#bit rb4=port_b.4 //proceso4
#bit rb5=port_b.5 //sistema operativo
#bit rb6=port_b.6 //indicador si funciona el quantum

//estructura del bloque de control de procesos(PCB)
 struct pcb {
 int id;
 int estado_proceso;
 int dir_inicio;
 int tiempo;
 int acumulador;
 };
 
//definiendo variables
char tecla_pulsada;
int mensaje_recibido;
int contador1=0;
int contador2=0;
int contador3=0;
int contador4=0;
int i;
int copia1;
int copia2;
int copia3;
int copia4;
//tiempos de duracion de cada proceso
long int time1=1000;
long int time2=2000;
long int time3=3000;
long int time4=4000;
long int quantum=250;/// 250 ms
//interrupciones
#int_rda
void RDA_isr(){
tecla_pulsada=getc();
mensaje_recibido=1;
//!port_b=0;
}

//funcion interrupcion serial
#int_timer0
//interrupcion del timer0,para hallar el quantum
//funcion quantum 
void timer0_isr(){
delay_ms(quantum-4);
   rb6=!rb6;
   rb0=!rb0;
   set_timer0(0x01);
}
 
//funciones de los procesos
//proceso1:
void do_proceso1(){
lcd_putc("\f");
lcd_putc("proceso 1");
puts("proceso 1");
rb1=1;
}
//proceso2:
void do_proceso2(){
lcd_putc("\f");
lcd_putc("proceso 2");
puts("proceso 2");
rb2=1;
}
//proceso3:
void do_proceso3(){
lcd_putc("\f");
lcd_putc("proceso 3");
puts("proceso 3");
rb3=1;
}
//proceso4:
void do_proceso4(){
lcd_putc("\f");
lcd_putc("proceso 4");
puts("proceso 4");
rb4=1;
}
//proceso11:
void do_proceso11(){
for (contador1=1;contador1<=4;contador1++){
             copia1=contador1;
             if(quantum*contador1<time1){
                rb1=1;
                delay_ms(quantum);
                rb1=0;
                delay_ms(quantum);
                                        }
             else {
                    do_proceso1();
                   }  
             if(tecla_pulsada=='2'){
                   break;
                  }
             if(tecla_pulsada=='3'){
                   break;
                  }
             if(tecla_pulsada=='4'){
                   break;
                  }
 
         }
 
     if(tecla_pulsada=='2'){
               for (contador2=1;contador2<=8;contador2++){
                    copia2=contador2;
                    if(quantum*contador1<=time1){
                      rb2=1;
                      rb1=1;
                      delay_ms(quantum);
                      rb1=0;
                      rb2=0;
                      delay_ms(quantum);
                                               }
                                               
                   else  {

                          if(quantum*contador2<time2){
                               rb2=1;
                               delay_ms(quantum);
                               rb2=0;
                               delay_ms(quantum);
                                                     } 
                         }

                 if(contador1==4 && copia1<4) do_proceso1();
                 else{ if(contador2==8) do_proceso2();}
         
                 if(tecla_pulsada=='3'){
                      break;
                  }
                 if(tecla_pulsada=='4'){
                      break;
                  }
                  contador1++;
                  
              }

              if(tecla_pulsada=='3'){
                      for (contador3=1;contador3<=12;contador3++){
                    copia3=contador3;
                    if(quantum*contador1<time1){
                      rb3=1;
                      rb2=1;
                      rb1=1;
                      delay_ms(quantum);
                      rb3=1;
                      rb1=0;
                      rb2=0;
                      delay_ms(quantum);
                                               }
                                               
                   else  {
                   
                          if(quantum*contador2<time2){
                               rb3=1;
                               rb2=1;
                               delay_ms(quantum);
                               rb3=0;
                               rb2=0;
                               delay_ms(quantum);
                                                    } 
                     else{
                         if(quantum*contador3<time3){
                               rb3=1;
                               delay_ms(quantum);
                               rb3=0;
                               delay_ms(quantum);
                                                     } 
    
                           }
                         }

                 if(contador1==4 && copia1<4) do_proceso1();                
                 if(contador2==8 && copia2<8) do_proceso2();
                 if(contador3==12 && copia3<12)do_proceso3();
         
       
                 if(tecla_pulsada=='4'){
                      break;
                  }
                  contador1++;
                  contador2++;
                
              }
                   if(tecla_pulsada=='4'){
                     for (contador4=1;contador4<=16;contador4++){
                    copia4=contador4;
                    if(quantum*contador1<time1){
                      rb4=1;
                      rb3=1;
                      rb2=1;
                      rb1=1;
                      delay_ms(quantum);
                      rb4=0;
                      rb3=1;
                      rb2=0;
                      rb1=0;
                      delay_ms(quantum);
                                               }
                                               
                   else  {
                   
                          if(quantum*contador2<time2){
                               rb4=1;
                               rb3=1;
                               rb2=1;
                               delay_ms(quantum);
                               rb4=0;
                               rb3=0;
                               rb2=0;
                               delay_ms(quantum);
                                                    } 
                     else{
                         if(quantum*contador3<time3){
                               rb4=1;
                               rb3=1;
                               delay_ms(quantum);
                               rb4=0;
                               rb3=0;
                               delay_ms(quantum);
                                                     } 
                           else {
                                   if(quantum*contador4<time4){
                                     rb4=1;
                                     delay_ms(quantum);
                                     rb4=0;
                                    delay_ms(quantum);
                                }
                                                     
                           }
                         }
                       }
                 if(contador1==4  &&  copia1<4) do_proceso1();
                 if(contador2==8  &&  copia2<8) do_proceso2();
                 if(contador3==12 &&  copia3<12) do_proceso3();
                 if(contador4==16 &&  copia4<16) do_proceso4();
                 
                  contador1++;
                  contador2++;
                  contador3++;
                  }
              
               }
                  
   }
             
              
          }
          
          if(tecla_pulsada=='3'){
               for (contador3=1;contador3<=12;contador3++){
                    copia3=contador3;
                    if(quantum*contador1<time1){
                      rb3=1;
                      rb1=1;
                      delay_ms(quantum);
                      rb3=0;
                      rb1=0;
                      delay_ms(quantum);
                                               }
                                               
                   else  {
                   
                          if(quantum*contador3<time3){
                               rb3=1;
                               delay_ms(quantum);
                               rb3=0;
                               delay_ms(quantum);
                                                     } 
                         }

                 if(contador1==4) do_proceso1();
                 if(contador3==12)do_proceso3();
         
                 if(tecla_pulsada=='4'){
                      break;
                  }
                 if(tecla_pulsada=='2'){
                      break;
                  }
                  contador1++;
                  
                  
              }
          }
          
          if(tecla_pulsada=='4'){
               for (contador4=1;contador4<=16;contador4++){
                    copia4=contador4;
                    if(quantum*contador1<time1){
                      rb4=1;
                      rb1=1;
                      delay_ms(quantum);
                      rb4=0;
                      rb1=0;
                      delay_ms(quantum);
                                               }
                                               
                   else  {
                   
                          if(quantum*contador4<time4){
                               rb4=1;
                               delay_ms(quantum);
                               rb4=0;
                               delay_ms(quantum);
                                                     } 
                         }

                 if(contador1==4) do_proceso1();
                 if(contador4==16) do_proceso4();
         
                 if(tecla_pulsada=='3'){
                      break;
                  }
                 if(tecla_pulsada=='2'){
                      break;
                  }
                  contador1++;
                  
              }
          }
          
          
          
   
}////////

void main(){
setup_timer_0(rtcc_internal | rtcc_div_16);//quantun de 250 ms
set_timer0(0x01);
enable_interrupts(global);

tris_b=0;
port_b=0;
mensaje_recibido=0;
lcd_init();
lcd_putc("hola");
delay_ms(100);
lcd_putc("\f");
lcd_putc("comprabando");
lcd_gotoxy(2,2);
lcd_putc("proceso...");
delay_ms(100);
rb6=0;

enable_interrupts(int_rda);
enable_interrupts(int_timer0);
   while(true){            
         if(mensaje_recibido==1){
                  lcd_putc("\f");
                  
               if(tecla_pulsada=='1'){
               do_proceso11();
               
            
                  }
               if(tecla_pulsada=='2'){
                   do_proceso2();
                  }
               if(tecla_pulsada=='3'){
                    do_proceso3();
                  }
                if(tecla_pulsada=='4'){
                  do_proceso4();
                  }   
                if(tecla_pulsada=='s'){
                  lcd_putc("\f");
                  lcd_putc("sist.oper. XAK"); 
                   puts("sistema operativo XAK");
                  rb5=1;
                  }

                  mensaje_recibido=0;
//!                  
//!                  while(1){
//!                       
//!                 
//!                  }
             }
        }
  }
