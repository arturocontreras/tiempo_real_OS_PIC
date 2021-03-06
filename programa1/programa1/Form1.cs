﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;

namespace programa1
{
    public partial class Form_principal : Form
    {   //utilizaremos un string como buffer de transmision
        string recibidos;
        byte[] mp1buffer = new byte[1];
        byte[] mp2buffer = new byte[1];
        int proceso;
        int[] indicador = new int[4];
        int[] proceso1=new int[4];
        int[] proceso2=new int[4];
        int[] proceso3=new int[4];
        int[] proceso4=new int[4];
        int[] tmuestreos = new int[4];
        int[] tduraciones = new int[4];
        int[] tdesordenado = new int[4];
        int[] tordenado = new int[4];
        int[] dordenado = new int[4];
        int[] calendario = new int[10000];


        public Form_principal()
        {
            InitializeComponent();
            //abrir puerto misntras se ejecuta la aplicacion
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                }
                catch (System.Exception ex) 
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            //ejecutar la funcion recepcion por disparo del evento 'DataReceived'
            serialPort1.DataReceived += new
            System.IO.Ports.SerialDataReceivedEventHandler(recepcion);
        }
        // al recibir datos

        private void recepcion(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) 
        { 
               //acumular los caracteres recibidos a nuestro 'buffer'(string)
            recibidos += serialPort1.ReadExisting(); 
            //invocar o llamar al proceso de tramas
            this.Invoke(new EventHandler(actualizar));
        }

        private void actualizar(object s,EventArgs e)
        {
            //asignar el valor de la trama al textbox
            textBox_visualizar_mensaje.Text=recibidos;
        }

        private void button_t_Click(object sender, EventArgs e)
        {
            byte[] mbuffer = new byte[1];
            mbuffer[0]=0x74 ;//ascii letra't'.
            serialPort1.Write(mbuffer,0, mbuffer.Length);
        }

        private void button_b_Click(object sender, EventArgs e)
        {
            byte[] mbuffer = new byte[1];
            mbuffer[0] = 0x62;//ascii letra'b'.
            serialPort1.Write(mbuffer, 0, mbuffer.Length);
        }

        private void button_a_Click(object sender, EventArgs e)
        {
            byte[] mbuffer = new byte[1];
            mbuffer[0] = 0x61;//ascii letra'a'.
            serialPort1.Write(mbuffer, 0, mbuffer.Length);
        }

        private void button_l_Click(object sender, EventArgs e)
        {
            byte[] mbuffer = new byte[1];
            mbuffer[0] = 0x6c;//ascii letra'l'.
            serialPort1.Write(mbuffer, 0, mbuffer.Length);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            byte[] mbuffer = new byte[1];
            mbuffer[0] = 115;//ascii letra's'.
            serialPort1.Write(mbuffer, 0, mbuffer.Length);
        }
        private void button_espacio_Click(object sender, EventArgs e)
        {
            serialPort1.Write(mp2buffer, 0, mp1buffer.Length);
            serialPort1.Write(mp2buffer, 0, mp1buffer.Length);
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = DateTime.Now.ToLongTimeString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
                mp1buffer[0] = 49;//1
                mp2buffer[0] = 97;//a
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Write(mp1buffer, 0, mp1buffer.Length);
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
           

                mp1buffer[0] = 50;//2
                mp2buffer[0] = 98;//b
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            

                mp1buffer[0] = 51;//3
                mp2buffer[0] = 99;//c
             
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            

                mp1buffer[0] = 52;//4
                mp1buffer[0] = 100;//d
           
        }

        private void label_mensaje_pic_Click(object sender, EventArgs e)
        {

        }

        private void textBox_visualizar_mensaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] mbuffer = new byte[1];
            mbuffer[0] = 118;//ascii letra'v'.
            serialPort1.Write(mbuffer, 0, mbuffer.Length);
            serialPort1.Write(mbuffer, 0, mbuffer.Length);
        }

        private void textBox1_TextChanged(object sender1, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            byte[] mbuffer = new byte[1];
            mbuffer[0] = 112;//ascii letra'p'.
            serialPort1.Write(mbuffer, 0, mbuffer.Length);
            serialPort1.Write(mbuffer, 0, mbuffer.Length);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {

                Process.Start("manual visual c#.pdf");
                Process.Start("manual picc.pdf");
                
                
            
            }

            catch(Win32Exception) 
                       {
                   MessageBox.Show("no se encuntra el archivo "+ 
                   " o los archivos \"manual visual c#.pdf y manual picc.pdf\" + y .\n"   +
                   " asegurate si se llama(n) con el/los mismo(s) nombre(s) y/o \n"+
                   " se encuentra(n) en la misma ubicacion de esta aplicacion.","aviso:",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         }


            

        }
        

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        static int MCM(params int[] numeros)
        {
            int maximo = 1;
            int tmp = 0;
            foreach (int b in numeros)
            {
                numeros[tmp] = Math.Abs(b);
                maximo = maximo * numeros[tmp];
                tmp++;
            }
            int resultado = 1;
            for (int i = 2; i <= maximo; i++)
            {
                bool a = true;
                foreach (int b in numeros)
                {
                    if (i % b != 0)
                    {
                        a = false;
                    }
                }
                if (a == true)
                {
                    resultado = i;
                    break;
                }
            }
            return resultado;
        }

        ///algoritmo para ordenamiento - de mayor a menor
        
        static int[] orden(params int[] numeros)
        {
        int Temp;
         for (int i = 0; i < numeros.Length- 1; i++){
            for (int j = i + 1; j <numeros.Length; ++j){
                //if (numeros[i] > numeros[j]){
                if (numeros[i] < numeros[j])
                {
                Temp = numeros [i];
                numeros[i] =numeros[j];
                numeros[j] = Temp;   
               }
             }
         }
            return numeros;
        }

      
      
        private void button6_Click(object sender, EventArgs e)
        {
            int comun = MCM(proceso1[2], proceso2[2], proceso3[2], proceso4[2]);
            //llenando el vector de tiempos de muestreos
            tmuestreos[0] = proceso1[2];
            tmuestreos[1] = proceso2[2];
            tmuestreos[2] = proceso3[2];
            tmuestreos[3] = proceso4[2];

            //guardando vector antiguo            
            tdesordenado[0] = proceso1[2];
            tdesordenado[1] = proceso2[2];
            tdesordenado[2] = proceso3[2];
            tdesordenado[3] = proceso4[2];

            //llenando el vector de tiempos de duraciones
            tduraciones[0] = proceso1[1];
            tduraciones[1] = proceso2[1];
            tduraciones[2] = proceso3[1];
            tduraciones[3] = proceso4[1];
            
            //ordenando de mayor a menor los tiempos de muestreo de los procesos
           
            tordenado=orden(tmuestreos);
            dordenado = tduraciones;

            //algoritmo para ordenar las duraciones de los procesos
            
            int Temp;
            int Temp1;
            for (int i = 0; i < tduraciones.Length - 1; i++)
            {
                for (int j = i + 1; j < tduraciones.Length; ++j)
                {
                    if (tdesordenado[i] < tdesordenado[j])
                    {
                        Temp = tdesordenado[i];
                        tdesordenado[i] = tdesordenado[j];
                        tdesordenado[j] = Temp;
                            
                        Temp1 = dordenado[i];
                        dordenado[i] = dordenado[j];
                        dordenado[j] = Temp1;
                    }
                 }
            }

                    
            
            //rellenar el calendario
           
            for(int j=0;j<comun;j+=tordenado[0]){
                for(int i=j;i<j+dordenado[0];i++){
                calendario[i]=1;
                }
            }
            
           for(int j=dordenado[0];j<comun;j+=tordenado[1]){
                for(int i=j;i<j+dordenado[1];i++){
                  if( calendario[i]==1){
                      indicador[1] = i;
                      textBox1.Text = "error ";
                      calendario[i] = 9;
                     }
                  else
                    calendario[i]=2;
                }
            }
          
            for(int j=dordenado[0]+dordenado[1];j<comun;j+=tordenado[2]){
                for(int i=j;i<j+dordenado[2];i++){
                  if( calendario[i]==1||calendario[i]==2){
                   textBox1.Text="error";
                   calendario[i] = 9;
                  }
                  else
                    calendario[i]=3;
                }
            }
            for (int j =dordenado[0] + dordenado[1] + dordenado[2]; j < comun; j += tordenado[3])
            {
                for (int i = j; i < j + dordenado[3]; i++)
                {
                    if (calendario[i] == 1 || calendario[i] == 2 || calendario[i] == 3)
                    {
                        textBox1.Text = "error";
                        calendario[i] = 9;
                    }
                    else
                        calendario[i] = 4;
                }
            }
            //MOSTRAR

            boxcalendario.Text = "Dur  Tm";
            boxcalendario.Text += "\r\n";
            //mostrar informacon de los procesos
            boxcalendario.Text += proceso1[1].ToString() + "   " + proceso1[2].ToString();
            boxcalendario.Text += "\r\n";
            boxcalendario.Text += proceso2[1].ToString() + "   " + proceso2[2].ToString();
            boxcalendario.Text += "\r\n";
            boxcalendario.Text += proceso3[1].ToString() + "   " + proceso3[2].ToString();
            boxcalendario.Text += "\r\n";
            boxcalendario.Text += proceso4[1].ToString() + "   " + proceso4[2].ToString();
            boxcalendario.Text += "\r\n";
            //mostrar mcm 
            boxcalendario.Text += "mcm";
            boxcalendario.Text += "\r\n";
            boxcalendario.Text += comun.ToString();
            boxcalendario.Text += "\r\n";
            //mostrar tiempo de muestreos ordenado
            
            boxcalendario.Text += "\r\n";
            for (int i = 0; i < tordenado.Length ; i++)
            {
               boxcalendario.Text += tordenado[i].ToString();
               boxcalendario.Text += " - ";
            }
            boxcalendario.Text += "\r\n";

            //tiempo de duracion en orden segun el tiempo de muestreo
            for (int i = 0; i < dordenado.Length; i++)
            {
                boxcalendario.Text += dordenado[i].ToString();
                boxcalendario.Text += " - ";
            }
            boxcalendario.Text += "\r\n";
            //mostrar calendario
            for (int i = 0; i < comun; i++)
            {
                boxcalendario.Text += calendario[i].ToString();
                
            }
         
        }
     

        private void calendarizar_Click(object sender, EventArgs e)
        {
            if(proceso==1){
                
                proceso1[1]=int.Parse(duracion.Text);
                proceso1[2]=int.Parse(tmuestreo.Text);

            }
            
            if(proceso==2){

                proceso2[1] = int.Parse(duracion.Text);
                proceso2[2] = int.Parse(tmuestreo.Text);

            }
            if(proceso==3){

                proceso3[1] = int.Parse(duracion.Text);
                proceso3[2] = int.Parse(tmuestreo.Text);

            }
            if(proceso==4){

                proceso4[1] = int.Parse(duracion.Text);
                proceso4[2] = int.Parse(tmuestreo.Text);

            }
            duracion.Text = " ";
            tmuestreo.Text = " ";
            procesoa.Checked = false;
            procesob.Checked = false;
            procesoc.Checked = false;
            procesod.Checked = false;
        } 


        private void procesoa_CheckedChanged(object sender, EventArgs e)
        {
            proceso=1;
        }

        private void Form_principal_Load(object sender, EventArgs e)
        {
        
        }

        private void procesob_CheckedChanged(object sender, EventArgs e)
        {
              proceso=2;
        }

        private void procesoc_CheckedChanged(object sender, EventArgs e)
        {
              proceso=3;
        }

        private void procesod_CheckedChanged(object sender, EventArgs e)
        {
              proceso=4;
        }

        private void duracion_TextChanged(object sender, EventArgs e)
        {
        
        }
       

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       
    }
}
