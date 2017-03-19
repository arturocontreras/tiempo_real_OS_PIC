using System;
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
        #region Local Variables
        private SerialPort serialPort1 = new SerialPort();
        #endregion

        string recibidos;
        byte[] mp1buffer = new byte[1];
        byte[] mp2buffer = new byte[1];
        byte[] mp3buffer = new byte[1];
        int[] arreglo1 = new int[8];
        int[] arreglo2 = new int[8];
        int[] arreglo3 = new int[8];
        int[] arreglo4 = new int[8];

        //private SerialPort serialPort1 = new SerialPort();

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

        private void Form_principal_Load(object sender, EventArgs e)
        {


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            //serialPort1.Write(mp3buffer, 0, mp3buffer.Length);
            if (mp3buffer[0] == 65){

                int num1;
                int num2;
                              
                num1 = int.Parse(textBox1.Text);
                num2 = int.Parse(textBox2.Text);
                arreglo1[1] = num1;
                arreglo1[2] = num2;

            }

            if (mp3buffer[0] == 66)
            {

                int num3;
                int num4;
                
                num3 = int.Parse(textBox1.Text);
                num4 = int.Parse(textBox2.Text);
                arreglo2[1] = num3;
                arreglo2[2] = num4;

            }

            if (mp3buffer[0] == 67)
            {

                int num5;
                int num6;
                
                num5 = int.Parse(textBox1.Text);
                num6 = int.Parse(textBox2.Text);
                arreglo3[1] = num5;
                arreglo3[2] = num6;

            }

            if (mp3buffer[0] == 68)
            {

                int num7;
                int num8;
             
                num7 = int.Parse(textBox1.Text);
                num8 = int.Parse(textBox2.Text);
                arreglo4[1] = num7;
                arreglo4[2] = num8;

            }
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            
            mp3buffer[0] = 65;//A
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            mp3buffer[0] = 66;//B
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            mp3buffer[0] = 67;//C
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            mp3buffer[0] = 68;//D
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_3(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
        static int MCM(params int[] numeros)//funcion para sacar el minimo comun multiplo
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
        private void button6_Click(object sender, EventArgs e)
        {
            /*int num1;
            int num2;
            int num3;
            int[] valores = new int[8];*/
        

          /*  num1 = int.Parse(textBox1.Text);
            num2 = int.Parse(textBox2.Text);
                
            //num3 = num1 + num2;

            num3 = MCM(num1, num2);

            valores[1] = num1;//asignando valores al vector
            valores[2] = num2;
            valores[3] = num3;


            textBox4.Multiline = true; //activar para poder bajar de linea
           // textBox4.Text = string.Format(valores[3].ToString() + "\r\n"); //se pone en la primera linea*/

          //  textBox4.Text = string.Format("\r\n");

            for (int i = 1; i <= 2; i++)
            {

                textBox4.Text += arreglo1[i].ToString();          //se concatena la cadena con los demas elementos
                           
            }

            textBox4.Text = string.Format("\r\n");

            for (int i = 1; i <= 2; i++)
            {

                textBox4.Text += arreglo2[i].ToString();          //se concatena la cadena con los demas elementos

            }

            textBox4.Text = string.Format("\r\n");

            for (int i = 1; i <= 2; i++)
            {

                textBox4.Text += arreglo3[i].ToString();          //se concatena la cadena con los demas elementos

            }

            textBox4.Text = string.Format("\r\n");

            for (int i = 1; i <= 2; i++)
            {

                textBox4.Text += arreglo4[i].ToString();          //se concatena la cadena con los demas elementos

            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
       
    }
}
