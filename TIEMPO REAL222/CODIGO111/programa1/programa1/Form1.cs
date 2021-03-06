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

       
    }
}
