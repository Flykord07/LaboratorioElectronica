namespace Laboratorio_Electronica
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Empleado = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgridVista = new System.Windows.Forms.DataGridView();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.Responsable = new System.Windows.Forms.Panel();
            this.fechafin = new System.Windows.Forms.DateTimePicker();
            this.Fechainicio = new System.Windows.Forms.DateTimePicker();
            this.antiguedadResponsable = new System.Windows.Forms.DateTimePicker();
            this.Colaborador = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.Desc_act = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Hrssm = new System.Windows.Forms.TextBox();
            this.Becario = new System.Windows.Forms.Panel();
            this.Fechanac = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Hrs_sem = new System.Windows.Forms.TextBox();
            this.Generacion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Grado = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EmpleadoDesde = new System.Windows.Forms.DateTimePicker();
            this.nombre = new System.Windows.Forms.TextBox();
            this.domicilio = new System.Windows.Forms.TextBox();
            this.Antiguedad = new System.Windows.Forms.TextBox();
            this.tipoempleado = new System.Windows.Forms.ComboBox();
            this.celular = new System.Windows.Forms.TextBox();
            this.correo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RPE_Empleado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.Empleado.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridVista)).BeginInit();
            this.Responsable.SuspendLayout();
            this.Colaborador.SuspendLayout();
            this.Becario.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1209, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Empleado
            // 
            this.Empleado.Controls.Add(this.tabPage1);
            this.Empleado.Controls.Add(this.tabPage2);
            this.Empleado.Location = new System.Drawing.Point(12, 12);
            this.Empleado.Name = "Empleado";
            this.Empleado.SelectedIndex = 0;
            this.Empleado.Size = new System.Drawing.Size(1184, 842);
            this.Empleado.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage1.Controls.Add(this.dgridVista);
            this.tabPage1.Controls.Add(this.btnAlta);
            this.tabPage1.Controls.Add(this.btnModificar);
            this.tabPage1.Controls.Add(this.Responsable);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(1176, 809);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Empleado";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // dgridVista
            // 
            this.dgridVista.AllowUserToAddRows = false;
            this.dgridVista.AllowUserToDeleteRows = false;
            this.dgridVista.AllowUserToResizeColumns = false;
            this.dgridVista.AllowUserToResizeRows = false;
            this.dgridVista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridVista.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgridVista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgridVista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridVista.Location = new System.Drawing.Point(28, 405);
            this.dgridVista.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgridVista.Name = "dgridVista";
            this.dgridVista.RowHeadersVisible = false;
            this.dgridVista.RowHeadersWidth = 20;
            this.dgridVista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgridVista.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgridVista.Size = new System.Drawing.Size(1120, 375);
            this.dgridVista.TabIndex = 41;
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(28, 22);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(88, 32);
            this.btnAlta.TabIndex = 40;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(28, 69);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(88, 32);
            this.btnModificar.TabIndex = 39;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // Responsable
            // 
            this.Responsable.Controls.Add(this.fechafin);
            this.Responsable.Controls.Add(this.Fechainicio);
            this.Responsable.Controls.Add(this.antiguedadResponsable);
            this.Responsable.Controls.Add(this.Colaborador);
            this.Responsable.Controls.Add(this.Becario);
            this.Responsable.Controls.Add(this.label17);
            this.Responsable.Controls.Add(this.label16);
            this.Responsable.Controls.Add(this.label15);
            this.Responsable.Controls.Add(this.Grado);
            this.Responsable.Controls.Add(this.label10);
            this.Responsable.Location = new System.Drawing.Point(804, 22);
            this.Responsable.Name = "Responsable";
            this.Responsable.Size = new System.Drawing.Size(345, 369);
            this.Responsable.TabIndex = 36;
            // 
            // fechafin
            // 
            this.fechafin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechafin.Location = new System.Drawing.Point(117, 129);
            this.fechafin.Name = "fechafin";
            this.fechafin.Size = new System.Drawing.Size(217, 26);
            this.fechafin.TabIndex = 43;
            // 
            // Fechainicio
            // 
            this.Fechainicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Fechainicio.Location = new System.Drawing.Point(117, 89);
            this.Fechainicio.Name = "Fechainicio";
            this.Fechainicio.Size = new System.Drawing.Size(217, 26);
            this.Fechainicio.TabIndex = 42;
            // 
            // antiguedadResponsable
            // 
            this.antiguedadResponsable.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.antiguedadResponsable.Location = new System.Drawing.Point(117, 6);
            this.antiguedadResponsable.Name = "antiguedadResponsable";
            this.antiguedadResponsable.Size = new System.Drawing.Size(217, 26);
            this.antiguedadResponsable.TabIndex = 41;
            // 
            // Colaborador
            // 
            this.Colaborador.Controls.Add(this.label9);
            this.Colaborador.Controls.Add(this.Desc_act);
            this.Colaborador.Controls.Add(this.label13);
            this.Colaborador.Controls.Add(this.Hrssm);
            this.Colaborador.Location = new System.Drawing.Point(0, 286);
            this.Colaborador.Name = "Colaborador";
            this.Colaborador.Size = new System.Drawing.Size(345, 89);
            this.Colaborador.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "Desc_act";
            // 
            // Desc_act
            // 
            this.Desc_act.Location = new System.Drawing.Point(100, 8);
            this.Desc_act.Name = "Desc_act";
            this.Desc_act.Size = new System.Drawing.Size(234, 26);
            this.Desc_act.TabIndex = 33;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "Hrs_sem";
            // 
            // Hrssm
            // 
            this.Hrssm.Location = new System.Drawing.Point(100, 49);
            this.Hrssm.Name = "Hrssm";
            this.Hrssm.Size = new System.Drawing.Size(234, 26);
            this.Hrssm.TabIndex = 31;
            // 
            // Becario
            // 
            this.Becario.Controls.Add(this.Fechanac);
            this.Becario.Controls.Add(this.label14);
            this.Becario.Controls.Add(this.label12);
            this.Becario.Controls.Add(this.Hrs_sem);
            this.Becario.Controls.Add(this.Generacion);
            this.Becario.Controls.Add(this.label11);
            this.Becario.Location = new System.Drawing.Point(0, 166);
            this.Becario.Name = "Becario";
            this.Becario.Size = new System.Drawing.Size(345, 122);
            this.Becario.TabIndex = 36;
            // 
            // Fechanac
            // 
            this.Fechanac.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Fechanac.Location = new System.Drawing.Point(129, 9);
            this.Fechanac.Name = "Fechanac";
            this.Fechanac.Size = new System.Drawing.Size(206, 26);
            this.Fechanac.TabIndex = 44;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(33, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 20);
            this.label14.TabIndex = 31;
            this.label14.Text = "Hrs_sem";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Fecha_nac";
            // 
            // Hrs_sem
            // 
            this.Hrs_sem.Location = new System.Drawing.Point(129, 46);
            this.Hrs_sem.Name = "Hrs_sem";
            this.Hrs_sem.Size = new System.Drawing.Size(206, 26);
            this.Hrs_sem.TabIndex = 29;
            // 
            // Generacion
            // 
            this.Generacion.Location = new System.Drawing.Point(129, 83);
            this.Generacion.Name = "Generacion";
            this.Generacion.Size = new System.Drawing.Size(206, 26);
            this.Generacion.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 20);
            this.label11.TabIndex = 26;
            this.label11.Text = "Generación";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 20);
            this.label17.TabIndex = 40;
            this.label17.Text = "Fecha_inicio";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 135);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 20);
            this.label16.TabIndex = 39;
            this.label16.Text = "Fecha_fin";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 20);
            this.label15.TabIndex = 38;
            this.label15.Text = "Grado";
            // 
            // Grado
            // 
            this.Grado.Location = new System.Drawing.Point(117, 48);
            this.Grado.Name = "Grado";
            this.Grado.Size = new System.Drawing.Size(217, 26);
            this.Grado.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Antiguedad";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.EmpleadoDesde);
            this.panel1.Controls.Add(this.nombre);
            this.panel1.Controls.Add(this.domicilio);
            this.panel1.Controls.Add(this.Antiguedad);
            this.panel1.Controls.Add(this.tipoempleado);
            this.panel1.Controls.Add(this.celular);
            this.panel1.Controls.Add(this.correo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RPE_Empleado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(136, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 369);
            this.panel1.TabIndex = 34;
            // 
            // EmpleadoDesde
            // 
            this.EmpleadoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EmpleadoDesde.Location = new System.Drawing.Point(144, 238);
            this.EmpleadoDesde.Name = "EmpleadoDesde";
            this.EmpleadoDesde.Size = new System.Drawing.Size(451, 26);
            this.EmpleadoDesde.TabIndex = 45;
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(141, 55);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(454, 26);
            this.nombre.TabIndex = 22;
            // 
            // domicilio
            // 
            this.domicilio.Location = new System.Drawing.Point(141, 100);
            this.domicilio.Name = "domicilio";
            this.domicilio.Size = new System.Drawing.Size(454, 26);
            this.domicilio.TabIndex = 21;
            // 
            // Antiguedad
            // 
            this.Antiguedad.Location = new System.Drawing.Point(144, 283);
            this.Antiguedad.Name = "Antiguedad";
            this.Antiguedad.Size = new System.Drawing.Size(454, 26);
            this.Antiguedad.TabIndex = 20;
            // 
            // tipoempleado
            // 
            this.tipoempleado.FormattingEnabled = true;
            this.tipoempleado.Items.AddRange(new object[] {
            "Colaborador",
            "Becario",
            "Responsable"});
            this.tipoempleado.Location = new System.Drawing.Point(144, 328);
            this.tipoempleado.Name = "tipoempleado";
            this.tipoempleado.Size = new System.Drawing.Size(451, 28);
            this.tipoempleado.TabIndex = 37;
            this.tipoempleado.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // celular
            // 
            this.celular.Location = new System.Drawing.Point(141, 188);
            this.celular.Name = "celular";
            this.celular.Size = new System.Drawing.Size(454, 26);
            this.celular.TabIndex = 18;
            // 
            // correo
            // 
            this.correo.Location = new System.Drawing.Point(141, 142);
            this.correo.Name = "correo";
            this.correo.Size = new System.Drawing.Size(454, 26);
            this.correo.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "RPE_Empleado";
            // 
            // RPE_Empleado
            // 
            this.RPE_Empleado.Location = new System.Drawing.Point(141, 11);
            this.RPE_Empleado.Name = "RPE_Empleado";
            this.RPE_Empleado.Size = new System.Drawing.Size(454, 26);
            this.RPE_Empleado.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Domicilio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Correo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Celular";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "EmpleadoDesde";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "TipoEmpleado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 288);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Antiguedad";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(28, 122);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(88, 32);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.menuStrip3);
            this.tabPage2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(1176, 809);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(152, 202);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // menuStrip3
            // 
            this.menuStrip3.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip3.Location = new System.Drawing.Point(3, 3);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(1170, 24);
            this.menuStrip3.TabIndex = 0;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 871);
            this.Controls.Add(this.Empleado);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Laboratorio Electronica";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Empleado.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgridVista)).EndInit();
            this.Responsable.ResumeLayout(false);
            this.Responsable.PerformLayout();
            this.Colaborador.ResumeLayout(false);
            this.Colaborador.PerformLayout();
            this.Becario.ResumeLayout(false);
            this.Becario.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl Empleado;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.TextBox RPE_Empleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Desc_act;
        private System.Windows.Forms.TextBox Generacion;
        private System.Windows.Forms.TextBox Hrssm;
        private System.Windows.Forms.TextBox Hrs_sem;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tipoempleado;
        private System.Windows.Forms.Panel Becario;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel Colaborador;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DateTimePicker Fechanac;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.TextBox domicilio;
        private System.Windows.Forms.TextBox Antiguedad;
        private System.Windows.Forms.TextBox celular;
        private System.Windows.Forms.TextBox correo;
        private System.Windows.Forms.DateTimePicker EmpleadoDesde;
        private System.Windows.Forms.DataGridView dgridVista;
        private System.Windows.Forms.Panel Responsable;
        private System.Windows.Forms.DateTimePicker fechafin;
        private System.Windows.Forms.DateTimePicker Fechainicio;
        private System.Windows.Forms.DateTimePicker antiguedadResponsable;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox Grado;
        private System.Windows.Forms.Label label10;
    }
}

