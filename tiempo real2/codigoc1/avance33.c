#include <18f452.h>
#fuses HS,NOPROTECT,NOWDT
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
#bit rb0=port_b.0 //quantum
#bit rb1=port_b.1 //proceso1
#bit rb2=port_b.2 //proceso2
#bit rb3=port_b.3 //proceso3
#bit rb5=port_b.5 //sistema operativo
#bit rb6=port_b.6 //indicador si funciona el quantum
#bit rc1=port_c.1 //procesoA
#bit rc2=port_c.2 //procesoB
#bit rc3=port_c.3 //procesoC
#bit rc4=port_c.4 //procesoD
//definiendo variables
char tecla_pulsada;
int mensaje_recibido;
int contador1=0;
int contador2=0;
int contador3=0;
int copia1;
int copia2;
int copia3;
char calendario[500];
//estados
char est1[12];
char est2[12];
char est3[12];
//flags
int flag_ver=0;
int flag_procesador=0;
int flag_so=0;
//acumuladores
long int acc1;
long int acc2;
long int acc3;
//colas
int cola1;
int cola2;
int cola3;
char col_fijo[20];
//tiempos de duracion de cada proceso
long int time1=2500;//10
long int time2=4000;//16
long int time3=5000;//20
long int quantum=250;/// 250 ms
//estructura del bloque de control de procesos(PCB)
 typedef struct  {
 int id;
 int estado;
 int dir_inicio;
 int id_corriente;//el valor del PC
 long int tiempo;
 }bloque ;
 long int acumulador;
 bloque pcb[3];
 int cola [3];//cola de procesos
 char col[20];
//funcion para ver procesos
 void ver_estado_proceso (int a){
 //0=vacio
 //1=ejecutandose
 //2=cargado
     if(a==0){
    if(contador1*quantum==0)
     est1= "vacio" ;
     acc1=0;
     cola1=0;
    if(contador1*quantum>0 && contador1*quantum<time1){
     est1="ejecutando";
     acc1=contador1*quantum;
     cola1=1;
    }
    if(contador1*quantum>=time1){
     est1="cargado";
     acc1=time1;
     cola1=0;
    }
     }
     if(a==1){
    if(contador2*quantum==0)
     est2= "vacio" ;
     acc2=0;
     cola2=0;
    if(contador2*quantum>0 && contador2*quantum<time2){
     est2="ejecutando";
     acc2=contador2*quantum;
     cola2=1;
    }
    if(contador2*quantum>=time2){
     est2="cargado";
     acc2=time2;
     cola2=0;
    }
     }
     if(a==2){
    if(contador3*quantum==0)
     est3= "vacio" ;
     acc3=0;
     cola3=0;
    if(contador3*quantum>0 && contador3*quantum<time3){
     est3="ejecutando";
     acc3=contador3*quantum;
     cola3=1;
    }
    if(contador3*quantum>=time3){
     est3="cargado";
     acc3=time3;
     cola3=0;
    }
     }
    
 }
  void ver_cola(int a ,int b,int c){
     if(a==0 && b==0 && c==0){
       col_fijo="no hay procesos";
        }
     if(a==1 && b==0 && c==0){
       col_fijo="solo el proceso 1"; 
     }
     if(a==1 && b==1 && c==0){
       col_fijo="procesos 1 y 2";
     }
     if(a==1 && b==0 && c==1){
       col_fijo="procesos 1 y 3";
     }
      if(a==0 && b==1 && c==0){
       col_fijo="solo el proceso 2";
     }
     if(a==0 && b==0 && c==1){
       col_fijo="solo el proceso 3";
     }
     if(a==0 && b==1 && c==1){
       col_fijo="procesos 2 y 3";
     } 
     if(a==1 && b==1 && c==1){
       col_fijo="procesos 1,2 y 3";
     }
    
  }
//interrupciones
#int_rda 
void RDA_isr(){
tecla_pulsada=getc();
mensaje_recibido=1;
if(tecla_pulsada=='v')flag_ver=1;
if(tecla_pulsada=='p')flag_procesador=1;
if(tecla_pulsada=='s')flag_so=1;
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
   if(tecla_pulsada=='v'&& flag_ver==1){
//!  est1=ver_estado_proceso(pcb[0].id);
ver_estado_proceso(pcb[0].id);
  ver_estado_proceso(pcb[1].id);
 ver_estado_proceso(pcb[2].id);
  pcb[0].tiempo=acc1;
  pcb[1].tiempo=acc2;
  pcb[2].tiempo=acc3;
  acumulador=acc1+acc2+acc3;
  puts("ver procesos");
  puts("id     dir-inicio        tiempo         estado");
  printf("%1u           %Lu            %Lu            ",pcb[0].id,100,pcb[0].tiempo);
  puts(est1);
  
  printf("%1u           %Lu            %Lu            ",pcb[1].id,200,pcb[1].tiempo);
  puts(est2);
  
  printf("%1u           %Lu            %Lu            ",pcb[2].id,300,pcb[2].tiempo);
  puts(est3);
  
  //el acumulador
  
  printf("acumulador = %Lu",acumulador);
  //la cola
  printf("  ");
  
  printf(" ----  ver cola :  ");
  cola[0]=cola1;
  cola[1]=cola2;
  cola[2]=cola3;
 ver_cola(cola[0],cola[1],cola[2]);
  puts(col_fijo);
  //
  flag_ver=0;}
  if(tecla_pulsada=='p'&& flag_procesador==1){
  flag_procesador=0;}
  if(tecla_pulsada=='s' && flag_so==1){
  lcd_putc("\f");
  lcd_putc("sist.oper. XAK"); 
  puts("sistema operativo XAK");
   rb5=1;
   
   flag_so=0;}
//!   if(tecla_pulsada=='h'&& flag_help==1){
//!   flag_help=0;}
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
//descarga de procesos

void descargar_proceso1(){
rb1=0;
}

void descargar_proceso2(){
rb2=0;
}

void descargar_proceso3(){
rb3=0;
}
//funciones para los de procesos_calendario
//procesoA:
void do_procesoA(){
lcd_putc("\f");
lcd_putc("proceso A");
puts("A");
rb1=1;
}
//procesoB:
void do_procesoB(){
lcd_putc("\f");
lcd_putc("proceso B");
puts("B");
rb2=1;
}
//procesoC:
void do_procesoC(){
lcd_putc("\f");
lcd_putc("proceso C");
puts("C");
rb3=1;
}

//procesoD:
void do_procesoD(){
lcd_putc("\f");
lcd_putc("proceso D");
puts("D");
rb3=1;
}

//proceso11:
void do_proceso11(){
for (contador1=1;contador1<=10;contador1++){
             
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
             if(tecla_pulsada=='a'){
                   break;
                  }
         }
 
     if(tecla_pulsada=='2'){
               for (contador2=1;contador2<=16;contador2++){
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

                 if(contador1==10 && copia1<10) do_proceso1();
                 else{ if(contador2==16) do_proceso2();}
         
                 if(tecla_pulsada=='3'){
                      break;
                  }
              
                  contador1++;
                  
              }

              if(tecla_pulsada=='3'){
                      for (contador3=1;contador3<=20;contador3++){
                           copia3=contador3;
                           if(quantum*contador1<time1){
                            rb3=1;
                            rb2=1;
                            rb1=1;
                            delay_ms(quantum);
                            rb3=0;
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
                     else {
                         if(quantum*contador3<time3){
                               rb3=1;
                               delay_ms(quantum);
                               rb3=0;
                               delay_ms(quantum);
                                                     } 
                             }
                         }

                 if(contador1==10 && copia1<10) do_proceso1();                
                 if(contador2==16 && copia2<16) do_proceso2();
                 if(contador3==20 )do_proceso3();

                  contador1++;
                  contador2++;
                
              }
                   
                  
   }
        
              
}
          else {
          if(tecla_pulsada=='3'){
               for (contador3=1;contador3<=20;contador3++){
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
                   
                          if(quantum*contador3<=time3){
                               rb3=1;
                               delay_ms(quantum);
                               rb3=0;
                               delay_ms(quantum);
                                                     } 
                         }

                 if(contador1==10 && copia1<10) do_proceso1();
                 if(contador3==20 )do_proceso3();
                 
                 if(tecla_pulsada=='2'){
                      break;
                  }
                  contador1++;

                 }
                 if(tecla_pulsada=='2'){
                         if(copia3<=4){/////////////
                           for (contador3=copia3;contador3<=20;contador3++){
                    copia3=contador3;
                    if(quantum*contador1<=time1){
                      rb2=1;
                      rb3=1;
                      rb1=1;
                      delay_ms(quantum);
                      rb2=0;
                      rb3=0;
                      rb1=0;
                      delay_ms(quantum);
                                               }
                                               
                   else  {
                   
                          if(quantum*contador2<=time2){
                               rb2=1;
                               rb3=1;
                               delay_ms(quantum);
                               rb2=0;
                               rb3=0;
                               delay_ms(quantum);
                                                     } 
                             else{
                                        if(quantum*contador3<=time3){
                               rb3=1;
                              
                               delay_ms(quantum);
                               rb3=0;
                              
                               delay_ms(quantum);
                                                     }               
                                                     
                                                     }
                         }

                 if(contador1==10 && copia1<10) do_proceso1();
                 if(contador3==20 )do_proceso3();
                 if(contador2==16 )do_proceso2();
                  contador1++;
                  contador2++;

                 }
                         }
                         else{
                              for (contador2=1;contador2<=16;contador2++){
                    copia2=contador2;
                    if(quantum*contador1<=time1){
                      rb2=1;
                      rb3=1;
                      rb1=1;
                      delay_ms(quantum);
                      rb2=0;
                      rb3=0;
                      rb1=0;
                      delay_ms(quantum);
                                               }
                                               
                   else  {
                   
                          if(quantum*contador3<=time3){
                               rb2=1;
                               rb3=1;
                               delay_ms(quantum);
                               rb2=0;
                               rb3=0;
                               delay_ms(quantum);
                                                     } 
                             else{
                                        if(quantum*contador2<=time2){
                               rb2=1;
                              
                               delay_ms(quantum);
                               rb2=0;
                              
                               delay_ms(quantum);
                                                     }               
                                                     
                                                     }
                         }

                 if(contador1==10 && copia1<10) do_proceso1();
                 if(contador3==20 && copia3<20)do_proceso3();
                 if(contador2==16 )do_proceso2();
                  contador1++;
                  contador3++;

                 }
                             }
                 
                                       }
              }
}  
          }
          
////////////////////////////////////////////
void do_proceso22(){
for (contador2=1;contador2<=16;contador2++){
             copia2=contador2;
             if(quantum*contador2<time2){
                rb2=1;
                delay_ms(quantum);
                rb2=0;
                delay_ms(quantum);
                                        }
             else {
                    do_proceso2();
                   }  
             if(tecla_pulsada=='1'){
                   break;
                  }
             if(tecla_pulsada=='3'){
                   break;
                  }
         }
 
     if(tecla_pulsada=='1'){
               if(copia2<=6){
               for (contador2=copia2;contador2<=16;contador2++){
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

                 if(contador1==10 && copia1<10) do_proceso1();
                 if(contador2==16 ) do_proceso2();
         
                 if(tecla_pulsada=='3'){
                      break;
                  }
              
                  contador1++;
                  
              }
             }
                       else{
                        for (contador1=1;contador1<=10;contador1++){
                    copia1=contador1;
                    if(quantum*contador2<=time2){
                      rb2=1;
                      rb1=1;
                      delay_ms(quantum);
                      rb1=0;
                      rb2=0;
                      delay_ms(quantum);
                                               }
                                               
                   else  {

                          if(quantum*contador1<time1){
                               rb1=1;
                               delay_ms(quantum);
                               rb1=0;
                               delay_ms(quantum);
                                                     } 
                         }

                 if(contador1==10 && copia1<10) do_proceso1();
                 if(contador2==16 && copia2<16) do_proceso2();
         
                 if(tecla_pulsada=='3'){
                      break;
                  }
              
                  contador2++;
                  
              }
                       
                       
          }
              if(tecla_pulsada=='3'){
                      for (contador3=1;contador3<=20;contador3++){
                           copia3=contador3;
                           if(quantum*contador1<time1){
                           if(quantum*contador2<=time2){
                             rb2=1;
                             rb3=1;
                             rb1=1;
                             delay_ms(quantum);
                             rb2=0;
                             rb3=0;
                             rb1=0;
                             delay_ms(quantum);
                          }
                          else{   
                             rb3=1;
                             rb1=1;
                             delay_ms(quantum);
                             rb3=0;
                             rb1=0;
                             delay_ms(quantum);
                          }
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

                 if(contador1==10 && copia1<10) do_proceso1();                
                 if(contador2==16 && copia2<16) do_proceso2();
                 if(contador3==20 )do_proceso3();

                  contador1++;
                  contador2++;
                
              }                                  
         }      
     }  
     //      
         else{
          if(tecla_pulsada=='3'){
               for (contador3=1;contador3<=20;contador3++){
                    copia3=contador3;
                    if(quantum*contador2<time2){
                      rb3=1;
                      rb2=1;
                      delay_ms(quantum);
                      rb3=0;
                      rb2=0;
                      delay_ms(quantum);
                                               }
                                               
                   else  {
                   
                          if(quantum*contador3<=time3){
                               rb3=1;
                               delay_ms(quantum);
                               rb3=0;
                               delay_ms(quantum);
                                                     } 
                         }

                 if(contador2==16 && copia2<16) do_proceso2();
                 if(contador3==20 )do_proceso3();
                 
                 if(tecla_pulsada=='1'){
                      break;
                  }
                  contador2++;

                 }
                 if(tecla_pulsada=='1'){
                         
                         for (contador3=copia3;contador3<=20;contador3++){
                              copia3=contador3;
                    if(quantum*contador1<=time1){
                          
                             rb2=1;
                             rb3=1;
                             rb1=1;
                             delay_ms(quantum);
                             rb2=0;
                             rb3=0;
                             rb1=0;
                             delay_ms(quantum);
                         
                                               }
                                               
                   else  {
                   
                          if(quantum*contador2<=time2){
                               rb2=1;
                               rb3=1;
                               delay_ms(quantum);
                               rb2=0;
                               rb3=0;
                               delay_ms(quantum);
                                                     } 
                             else{
                                        if(quantum*contador3<=time3){
                               rb3=1;
                              
                               delay_ms(quantum);
                               rb3=0;
                              
                               delay_ms(quantum);
                                                     }               
                                                     
                                                     }
                         }

                 if(contador1==10 ) do_proceso1();
                 if(contador3==20 )do_proceso3();
                 if(contador2==16 )do_proceso2();
                  contador1++;
                  contador2++;

                 }
                         
                        
                 
                                       }
              }
       }   
   }
          
////////////////////////////////////////
void do_proceso33(){
for (contador3=1;contador2<=20;contador3++){
             copia3=contador3;
             if(quantum*contador3<time3){
                rb3=1;
                delay_ms(quantum);
                rb3=0;
                delay_ms(quantum);
                                        }
             else {
                    do_proceso3();
                   }  
             if(tecla_pulsada=='1'){
                   break;
                  }
             if(tecla_pulsada=='2'){
                   break;
                  }
         }
 
     if(tecla_pulsada=='1'){
               if(copia3<=10){
               for (contador3=copia3;contador3<=20;contador3++){
                    copia3=contador3;
                    if(quantum*contador1<=time1){
                      rb3=1;
                      rb1=1;
                      delay_ms(quantum);
                      rb1=0;
                      rb3=0;
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

                 if(contador1==10 && copia1<10) do_proceso1();
                 if(contador3==20 ) do_proceso3();
         
                 if(tecla_pulsada=='2'){
                      break;
                  }
              
                  contador1++;
                  
              }
             }
                       else{
                        for (contador1=1;contador1<=10;contador1++){
                    copia1=contador1;
                    if(quantum*contador3<=time3){
                      rb3=1;
                      rb1=1;
                      delay_ms(quantum);
                      rb1=0;
                      rb3=0;
                      delay_ms(quantum);
                                               }
                                               
                   else  {

                          if(quantum*contador1<time1){
                               rb1=1;
                               delay_ms(quantum);
                               rb1=0;
                               delay_ms(quantum);
                                                     } 
                         }

                 if(contador1==10 ) do_proceso1();
                 if(contador3==20 && copia3<20) do_proceso3();
         
                 if(tecla_pulsada=='2'){
                      break;
                  }
              
                  contador3++;
                  
              }
                       
                       
          }
          
              if(tecla_pulsada=='2'){
                          if (copia3<=4){
                      for (contador3=1;contador3<=20;contador3++){
                           copia3=contador3;
                           if(quantum*contador1<time1){
                             rb2=1;
                             rb3=1;
                             rb1=1;
                             delay_ms(quantum);
                             rb2=0;
                             rb3=0;
                             rb1=0;
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

                 if(contador1==10 && copia1<10) do_proceso1();                
                 if(contador2==16 && copia2<16) do_proceso2();
                 if(contador3==20 )do_proceso3();

                  contador1++;
                  contador2++;
                
              } //
                          }
             
             
             else
                 {
                     for (contador2=1;contador2<=16;contador2++){
                           copia2=contador2;
                           if(quantum*contador1<time1){
                           if(quantum*contador3<time3){
                             rb2=1;
                             rb3=1;
                             rb1=1;
                             delay_ms(quantum);
                             rb2=0;
                             rb3=0;
                             rb1=0;
                             delay_ms(quantum);
                             }
                             else{
                             rb2=1;
                             rb1=1;
                             delay_ms(quantum);
                             rb2=0;
                             rb1=0;
                             delay_ms(quantum);
                             }
                             
                        
                                               }                                             
                   else  {
                   
                          if(quantum*contador2<time2){
                               rb2=1;
                               delay_ms(quantum);
                               rb2=0;
                               delay_ms(quantum);
                                                    } 
                         }

                 if(contador1==10 && copia1<10) do_proceso1();                
                 if(contador2==16 ) do_proceso2();
                 if(contador3==20 )do_proceso3();

                  contador1++;
                  contador3++;
                
              } //
         
         
                 }
         }  
         
         
     }  
     //      
         else{
         
          if(tecla_pulsada=='2'){
               if(copia3<=4){//
               for (contador3=1;contador3<=20;contador3++){
                    copia3=contador3;
                    if(quantum*contador2<time2){
                     
                      rb3=1;
                      rb2=1;
                      delay_ms(quantum);
                      rb3=0;
                      rb2=0;
                     
                      delay_ms(quantum);
                                               }
                                               
                   else  {
                   
                          if(quantum*contador3<=time3){
                               
                               rb3=1;
                               delay_ms(quantum);
                               rb3=0;
                               delay_ms(quantum);
                                                     } 
                         }

                 if(contador2==16 && copia2<16) do_proceso2();
                 if(contador3==20 )do_proceso3();
                 
                 if(tecla_pulsada=='1'){
                      break;
                  }
                  contador2++;

                 }
                 if(tecla_pulsada=='1'){
                         if(copia3<=10){
                         for (contador3=copia3;contador3<=20;contador3++){
                              copia3=contador3;
                    if(quantum*contador1<=time1){
                    if(quantum*contador2<=time2){
                             rb2=1;
                             rb3=1;
                             rb1=1;
                             delay_ms(quantum);
                             rb2=0;
                             rb3=0;
                             rb1=0;
                             delay_ms(quantum);
                    }
                    else{  
                             rb3=1;
                             rb1=1;
                             delay_ms(quantum);
                             rb3=0;
                             rb1=0;
                             delay_ms(quantum);
                    }
                                               }
                                               
                   else  {
                   
                          if(quantum*contador2<=time2){
                               rb2=1;
                               rb3=1;
                               delay_ms(quantum);
                               rb2=0;
                               rb3=0;
                               delay_ms(quantum);
                                                     } 
                             else{
                                        if(quantum*contador3<=time3){
                               rb3=1;
                               delay_ms(quantum);
                               rb3=0;
                              
                               delay_ms(quantum);
                                                     }               
                                                     
                                                     }
                         }

                 if(contador1==10 ) do_proceso1();
                 if(contador3==20 )do_proceso3();
                 if(contador2==16 )do_proceso2();
                  contador1++;
                  contador2++;

                         }/////
                     }
                 ///
                 else  {///////////////
                        for (contador1=copia1;contador1<=10;contador1++){
                      copia1=contador1;
                    if(quantum*contador2<=time2){
                    if(quantum*contador3<=time3){
                             rb2=1;
                             rb3=1;
                             rb1=1;
                             delay_ms(quantum);
                             rb2=0;
                             rb3=0;
                             rb1=0;
                             delay_ms(quantum);
                    }
                    else{   
                             rb2=1;
                             rb1=1;
                             delay_ms(quantum);
                             rb2=0;
                             rb1=0;
                             delay_ms(quantum);
                    }
                                               }
                                               
                   else  {       if(quantum*contador1<=time1){ 
                               rb1=1;
                               delay_ms(quantum);
                               rb1=0;                           
                               delay_ms(quantum);  }    
                         }

                 if(contador1==10 ) do_proceso1();
                 if(contador3==20 )do_proceso3();
                 if(contador2==16 )do_proceso2();
                  contador3++;
                  contador2++;

                         }/////
                 
                 
                 }
                         
                        
                 
                                       }
               } /////
               
               ///
               else{////////////////////////////kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk
                    for (contador2=1;contador2<=16;contador2++){
                    copia2=contador2;
                    if(quantum*contador3<time3){
                     
                      rb3=1;
                      rb2=1;
                      delay_ms(quantum);
                      rb3=0;
                      rb2=0;
                     
                      delay_ms(quantum);
                                               }
                                               
                   else  {
                   
                          if(quantum*contador2<=time2){
                               
                               rb2=1;
                               delay_ms(quantum);
                               rb2=0;
                               delay_ms(quantum);
                                                     } 
                         }

                 if(contador2==16 ) do_proceso2();
                 if(contador3==20 )do_proceso3();
                 
                 if(tecla_pulsada=='1'){
                      break;
                  }
                  contador3++;

                 }
                 if(tecla_pulsada=='1'){
                         if(copia3<=10){
                         for (contador2=copia2;contador2<=16;contador2++){
                              copia2=contador2;
                    if(quantum*contador1<=time1){
                    if(quantum*contador3<=time3){
                             rb2=1;
                             rb3=1;
                             rb1=1;
                             delay_ms(quantum);
                             rb2=0;
                             rb3=0;
                             rb1=0;
                             delay_ms(quantum);
                    }
                    else{  
                             rb2=1;
                             rb1=1;
                             delay_ms(quantum);
                             rb2=0;
                             rb1=0;
                             delay_ms(quantum);
                    }
                                               }
                                               
                   else  {
                              if(quantum*contador2<=time2){
                               rb2=1;
                               delay_ms(quantum);
                               rb2=0;
                               delay_ms(quantum);
                                                     }               
                                                     
                                                  
                         }

                 if(contador1==10 ) do_proceso1();
                 if(contador3==20 )do_proceso3();
                 if(contador2==16 )do_proceso2();
                  contador3++;
                  contador1++;

                         }/////
                     }
                 ///
                 else  {
                        for (contador2=copia2;contador2<=16;contador2++){
                      copia2=contador2;
                    if(quantum*contador1<=time1){
                    if(quantum*contador3<=time3){
                             rb2=1;
                             rb3=1;
                             rb1=1;
                             delay_ms(quantum);
                             rb2=0;
                             rb3=0;
                             rb1=0;
                             delay_ms(quantum);
                    }
                    else{   
                             rb2=1;
                             rb1=1;
                             delay_ms(quantum);
                             rb2=0;
                             rb1=0;
                             delay_ms(quantum);
                    }
                                               }
                                               
                   else  {       
                   if(quantum*contador2<=time2){
                               rb2=1;
                               delay_ms(quantum);
                               rb2=0;                           
                               delay_ms(quantum); 
                               
                               }
                         }

                 if(contador1==10 ) do_proceso1();
                 if(contador3==20 )do_proceso3();
                 if(contador2==16 )do_proceso2();
                  contador1++;
                  contador3++;

                         }/////
                 
                 
                                   }
                         
                        
                 
                      }
               
                  }
              }
       }   
   }
///////////////////////////////////////
void main(){
setup_timer_0(rtcc_internal | rtcc_div_16);//quantun de 250 ms
set_timer0(0x01);
enable_interrupts(global);
tris_b=0;
port_b=0;
//
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
pcb[0].id=0;
pcb[1].id=1;
pcb[2].id=2;
contador1=0;
contador2=0;
contador3=0;
enable_interrupts(int_rda);
enable_interrupts(int_timer0);
   while(true){            
         if(mensaje_recibido==1){
                  lcd_putc("\f");
                  
               if(tecla_pulsada=='1'){
               do_proceso11();
                  }
               else {
               
                  if(tecla_pulsada=='2')do_proceso22();
                   
                   else{
                    if(tecla_pulsada=='3') do_proceso33(); 
                  }
               }
                
                if(tecla_pulsada=='a'){
                contador1=0;
                copia1=0;
                descargar_proceso1();
                  }
                if(tecla_pulsada=='b'){
                contador2=0;
                copia2=0;
                descargar_proceso2();
                  }
                if(tecla_pulsada=='c'){
                contador3=0;
                copia3=0;
                descargar_proceso3();
                  }
                  mensaje_recibido=0;
                  }
               
             }
        }

