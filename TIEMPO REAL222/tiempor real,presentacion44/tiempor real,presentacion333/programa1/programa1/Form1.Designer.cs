namespace programa1
{
    partial class Form_principal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_espacio = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox_visualizar_mensaje = new System.Windows.Forms.TextBox();
            this.label_mensaje_pic = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.boxcalendario = new System.Windows.Forms.TextBox();
            this.replanificar = new System.Windows.Forms.Button();
            this.enviar = new System.Windows.Forms.Button();
            this.calendarizar = new System.Windows.Forms.Button();
            this.procesob = new System.Windows.Forms.CheckBox();
            this.procesoc = new System.Windows.Forms.CheckBox();
            this.procesod = new System.Windows.Forms.CheckBox();
            this.procesoa = new System.Windows.Forms.CheckBox();
            this.duracion = new System.Windows.Forms.TextBox();
            this.tmuestreo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_espacio
            // 
            this.button_espacio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_espacio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_espacio.Location = new System.Drawing.Point(300, 84);
            this.button_espacio.Name = "button_espacio";
            this.button_espacio.Size = new System.Drawing.Size(125, 23);
            this.button_espacio.TabIndex = 4;
            this.button_espacio.Text = "descargar";
            this.button_espacio.UseVisualStyleBackColor = false;
            this.button_espacio.Click += new System.EventHandler(this.button_espacio_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM2";
            this.serialPort1.StopBits = System.IO.Ports.StopBits.Two;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(970, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "mm:hh:ss";
            // 
            // textBox_visualizar_mensaje
            // 
            this.textBox_visualizar_mensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_visualizar_mensaje.Location = new System.Drawing.Point(40, 204);
            this.textBox_visualizar_mensaje.Multiline = true;
            this.textBox_visualizar_mensaje.Name = "textBox_visualizar_mensaje";
            this.textBox_visualizar_mensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_visualizar_mensaje.Size = new System.Drawing.Size(655, 239);
            this.textBox_visualizar_mensaje.TabIndex = 6;
            this.textBox_visualizar_mensaje.TabStop = false;
            this.textBox_visualizar_mensaje.TextChanged += new System.EventHandler(this.textBox_visualizar_mensaje_TextChanged);
            // 
            // label_mensaje_pic
            // 
            this.label_mensaje_pic.AutoSize = true;
            this.label_mensaje_pic.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mensaje_pic.Location = new System.Drawing.Point(37, 183);
            this.label_mensaje_pic.Name = "label_mensaje_pic";
            this.label_mensaje_pic.Size = new System.Drawing.Size(214, 18);
            this.label_mensaje_pic.TabIndex = 5;
            this.label_mensaje_pic.Text = "Estado del procesador y el S.O";
            this.label_mensaje_pic.Click += new System.EventHandler(this.label_mensaje_pic_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(300, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "cargar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "procesos ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(340, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "MULTITAREA";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(300, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "version del S.O";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(96, 48);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 20);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "proceso 1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(96, 87);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(87, 20);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.Text = "proceso 2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(96, 130);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(87, 20);
            this.checkBox3.TabIndex = 14;
            this.checkBox3.Text = "proceso 3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button.Location = new System.Drawing.Point(431, 84);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(125, 23);
            this.button.TabIndex = 17;
            this.button.Text = "Ver ";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(431, 46);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(125, 23);
            this.button5.TabIndex = 18;
            this.button5.Text = "Procesador";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(431, 127);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "Help";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(246, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(456, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "-- Visualizacion de estados,cola,cantidad de procesos y acumulador";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(695, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "CALENDARIZACION";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // boxcalendario
            // 
            this.boxcalendario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.boxcalendario.Location = new System.Drawing.Point(728, 204);
            this.boxcalendario.Multiline = true;
            this.boxcalendario.Name = "boxcalendario";
            this.boxcalendario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.boxcalendario.Size = new System.Drawing.Size(230, 239);
            this.boxcalendario.TabIndex = 23;
            this.boxcalendario.TabStop = false;
            // 
            // replanificar
            // 
            this.replanificar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.replanificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replanificar.Location = new System.Drawing.Point(728, 56);
            this.replanificar.Name = "replanificar";
            this.replanificar.Size = new System.Drawing.Size(119, 28);
            this.replanificar.TabIndex = 24;
            this.replanificar.Text = "REPLANIFICAR";
            this.replanificar.UseVisualStyleBackColor = false;
            this.replanificar.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // enviar
            // 
            this.enviar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.enviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviar.Location = new System.Drawing.Point(853, 56);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(99, 28);
            this.enviar.TabIndex = 24;
            this.enviar.Text = "ENVIAR";
            this.enviar.UseVisualStyleBackColor = false;
            this.enviar.Click += new System.EventHandler(this.button6_Click);
            // 
            // calendarizar
            // 
            this.calendarizar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.calendarizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendarizar.Location = new System.Drawing.Point(601, 56);
            this.calendarizar.Name = "calendarizar";
            this.calendarizar.Size = new System.Drawing.Size(121, 28);
            this.calendarizar.TabIndex = 24;
            this.calendarizar.Text = "CALENDARIZAR";
            this.calendarizar.UseVisualStyleBackColor = false;
            this.calendarizar.Click += new System.EventHandler(this.calendarizar_Click);
            // 
            // procesob
            // 
            this.procesob.AutoSize = true;
            this.procesob.Location = new System.Drawing.Point(695, 151);
            this.procesob.Name = "procesob";
            this.procesob.Size = new System.Drawing.Size(88, 17);
            this.procesob.TabIndex = 25;
            this.procesob.Text = "PROCESO B";
            this.procesob.UseVisualStyleBackColor = true;
            this.procesob.CheckedChanged += new System.EventHandler(this.procesob_CheckedChanged);
            // 
            // procesoc
            // 
            this.procesoc.AutoSize = true;
            this.procesoc.Location = new System.Drawing.Point(784, 151);
            this.procesoc.Name = "procesoc";
            this.procesoc.Size = new System.Drawing.Size(88, 17);
            this.procesoc.TabIndex = 26;
            this.procesoc.Text = "PROCESO C";
            this.procesoc.UseVisualStyleBackColor = true;
            this.procesoc.CheckedChanged += new System.EventHandler(this.procesoc_CheckedChanged);
            // 
            // procesod
            // 
            this.procesod.AutoSize = true;
            this.procesod.Location = new System.Drawing.Point(869, 151);
            this.procesod.Name = "procesod";
            this.procesod.Size = new System.Drawing.Size(89, 17);
            this.procesod.TabIndex = 26;
            this.procesod.Text = "PROCESO D";
            this.procesod.UseVisualStyleBackColor = true;
            this.procesod.CheckedChanged += new System.EventHandler(this.procesod_CheckedChanged);
            // 
            // procesoa
            // 
            this.procesoa.AutoSize = true;
            this.procesoa.Location = new System.Drawing.Point(601, 151);
            this.procesoa.Name = "procesoa";
            this.procesoa.Size = new System.Drawing.Size(88, 17);
            this.procesoa.TabIndex = 25;
            this.procesoa.Text = "PROCESO A";
            this.procesoa.UseVisualStyleBackColor = true;
            this.procesoa.CheckedChanged += new System.EventHandler(this.procesoa_CheckedChanged);
            // 
            // duracion
            // 
            this.duracion.Location = new System.Drawing.Point(645, 125);
            this.duracion.Name = "duracion";
            this.duracion.Size = new System.Drawing.Size(100, 20);
            this.duracion.TabIndex = 27;
            this.duracion.TextChanged += new System.EventHandler(this.duracion_TextChanged);
            // 
            // tmuestreo
            // 
            this.tmuestreo.Location = new System.Drawing.Point(818, 125);
            this.tmuestreo.Name = "tmuestreo";
            this.tmuestreo.Size = new System.Drawing.Size(100, 20);
            this.tmuestreo.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(664, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Duracion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(832, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "T muestreo";
            // 
            // Form_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 481);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tmuestreo);
            this.Controls.Add(this.duracion);
            this.Controls.Add(this.procesod);
            this.Controls.Add(this.procesoc);
            this.Controls.Add(this.procesoa);
            this.Controls.Add(this.procesob);
            this.Controls.Add(this.calendarizar);
            this.Controls.Add(this.enviar);
            this.Controls.Add(this.replanificar);
            this.Controls.Add(this.boxcalendario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_mensaje_pic);
            this.Controls.Add(this.textBox_visualizar_mensaje);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_espacio);
            this.Location = new System.Drawing.Point(0, 132);
            this.Name = "Form_principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "programa1";
            this.Load += new System.EventHandler(this.Form_principal_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_espacio;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox textBox_visualizar_mensaje;
        private System.Windows.Forms.Label label_mensaje_pic;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox boxcalendario;
        private System.Windows.Forms.Button replanificar;
        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.Button calendarizar;
        private System.Windows.Forms.CheckBox procesob;
        private System.Windows.Forms.CheckBox procesoc;
        private System.Windows.Forms.CheckBox procesod;
        private System.Windows.Forms.CheckBox procesoa;
        private System.Windows.Forms.TextBox duracion;
        private System.Windows.Forms.TextBox tmuestreo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

