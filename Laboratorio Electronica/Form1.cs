﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Laboratorio_Electronica
{
    public partial class Form1 : Form
    {
        private int id;
        private SqlConnection conexion = new SqlConnection("Server=DESKTOP-O0MDQRH\\SQLEXPRESS;" + "Database=Laboratorio;" + "Integrated Security=true;");
        public Form1()
        {
            InitializeComponent();
        }
        private void muestraVista()
        {
            string query = String.Concat("SELECT * FROM Persona.Empleado");

            SqlCommand cmd = new SqlCommand(query, conexion);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable registros = new DataTable();

            adapter.Fill(registros);

            dgridVista.DataSource = null;

            dgridVista.DataSource = registros;
        }

        private int conectaBD()
        {
            try
            {
                conexion.Open();
                muestraVista();
                conexion.Close();
                return 0;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show("Error de conexion: " + ex.Message);
                return 1;
            }
        }

        private int insertarRegistro()
        {
            try
            {
                conexion.Open();
                string consulta = "INSERT INTO Persona.Empleado(RPE_Empleado,Nombre,Domicilio,Correo,Celular,EmpleadoDesde,Antiguedad,TipoEmpleado) VALUES ('"+RPE_Empleado.Text+"','" + nombre.Text + "', '" + domicilio.Text + "', '" + correo.Text + "', '" + celular.Text + "','" + EmpleadoDesde.Text + "','" + Antiguedad.Text + "','" + tipoempleado.SelectedItem+"')";
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                cmd.ExecuteNonQuery();
                switch (tipoempleado.SelectedIndex)
                {
                    case 0:
                        consulta = "INSERT INTO Persona.Colaborador(RPE_Colaborador,Desc_act,Hrs_sem) VALUES ('"+ RPE_Empleado.Text+"','" + Desc_act.Text + "', '" + Hrs_sem.Text + "')";
                        cmd = new SqlCommand(consulta, conexion);
                        cmd.ExecuteNonQuery();
                        break;
                    case 1:
                        consulta = "INSERT INTO Persona.Becario(RPE_Becario,Fecha_nac,Hrs_sem,Generacion) VALUES ('" + RPE_Empleado.Text + "','" + Fechanac.Text + "', '" + Hrssm.Text + "', '" + Hrssm.Text +"')";
                        cmd = new SqlCommand(consulta, conexion);
                        cmd.ExecuteNonQuery();
                        break;
                    case 2:
                        consulta = "INSERT INTO Persona.Responsable(RPE_Responsable,Antiguedad,Grado,Fecha_Inicio,Fecha_Fin) VALUES ('" + RPE_Empleado.Text + "','" + Antiguedad.Text + "', '" + Grado.Text + "', '" + Hrssm.Text + "')";
                        cmd = new SqlCommand(consulta, conexion);
                        cmd.ExecuteNonQuery();
                        break;

                }
               
                conexion.Close();
                return 0;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show("Error de conexion: " + ex.Message);
                return 1;
            }
        }



        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Mostrar ocultar paneles
        }
                

        private void Form1_Load(object sender, EventArgs e)
        {
            dgridVista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgridVista.MultiSelect = false;
            dgridVista.EditMode = DataGridViewEditMode.EditProgrammatically;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            conectaBD();
            dgridVista.ClearSelection();
            Colaborador.Visible = false;
            Becario.Visible = false;
            Responsable.Visible = false;
            Asistencia.Visible = false;
            Materia.Visible = false;
            Alumno.Visible = false;
            Sancion.Visible = false;
            Prestamo.Visible = false;
            BitacoraEntrega.Visible = false;
            Equipo.Visible = false;
            
            
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            insertarRegistro();
            conectaBD();
            //nombre.Clear(); //limpiar textbox
            dgridVista.ClearSelection();
        }
        private int cargarDatos()
        {
            int selectedRowCount = dgridVista.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                DataGridViewRow row = dgridVista.SelectedRows[0];
                var id = row.Cells[0].Value;
                var nombrePiloto = row.Cells[1];
                var cultureInfo = new System.Globalization.CultureInfo("de-DE");
                var fechaNacimiento = row.Cells[2].Value.ToString();
                nombre.Text = nombrePiloto.Value.ToString();
                fechaNacimiento = fechaNacimiento.Substring(0, fechaNacimiento.IndexOf(" "));
                var dateTime = DateTime.ParseExact(fechaNacimiento, "MM/dd/yyyy", cultureInfo);
                //fechaNac.Value = dateTime;

                return int.Parse(id.ToString());
            }
            return -1;
        }

        private void dgridVista_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = cargarDatos(); //obtener id de tupla seleccionada
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                try
                {
                    conexion.Open();
                    string consulta = "UPDATE Persona.Empleado SET  WHERE idPiloto=" + id + ";";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    conexion.Close();
                    MessageBox.Show("Error de conexion: " + ex.Message);
                }
            }
            id = -1;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            conectaBD();
            dgridVista.ClearSelection();
            nombre.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                try
                {
                    conexion.Open();
                    string consulta = "DELETE FROM Persona.Empleado WHERE idPiloto=" + id + ";";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    conexion.Close();
                    MessageBox.Show("Error de conexion: " + ex.Message);
                }
            }
            id = -1;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            conectaBD();
            dgridVista.ClearSelection();
            nombre.Clear();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(tipoempleado.SelectedItem.ToString());
            switch (tipoempleado.SelectedIndex)
            {
                case 0:
                    Becario.Visible = false;
                    Responsable.Visible = false;
                    Colaborador.Visible = true;
                    break;
                case 1:
                    Colaborador.Visible = false;
                    Becario.Visible = true;
                    Responsable.Visible = false;
                    break;
                case 2:
                    Colaborador.Visible = false;
                    Becario.Visible = false;
                    Responsable.Visible = true;
                    break;
               
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Datos_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Datos.SelectedIndex)
            {
                case 0:
                    Asistencia.Visible = true;
                    Materia.Visible = false;
                    Alumno.Visible = false;
                    Sancion.Visible = false;
                    Prestamo.Visible = false;
                    BitacoraEntrega.Visible = false;
                    Equipo.Visible = false;
                    break;
                case 1:
                    Asistencia.Visible = false;
                    Materia.Visible = true;
                    Alumno.Visible = false;
                    Sancion.Visible = false;
                    Prestamo.Visible = false;
                    BitacoraEntrega.Visible = false;
                    Equipo.Visible = false;
                    break;
                case 2:
                    Asistencia.Visible = false;
                    Materia.Visible = false;
                    Alumno.Visible = false;
                    Sancion.Visible = false;
                    Prestamo.Visible = false;
                    BitacoraEntrega.Visible = false;
                    Equipo.Visible = true;
                    break;
                case 3:
                    Asistencia.Visible = false;
                    Materia.Visible = false;
                    Alumno.Visible = true;
                    Sancion.Visible = false;
                    Prestamo.Visible = false;
                    BitacoraEntrega.Visible = false;
                    Equipo.Visible = false;
                    break;
                case 4:
                    Asistencia.Visible = false;
                    Materia.Visible = false;
                    Alumno.Visible = false;
                    Sancion.Visible = true;
                    Prestamo.Visible = false;
                    BitacoraEntrega.Visible = false;
                    Equipo.Visible = false;
                    break;
                case 5:
                    Asistencia.Visible = false;
                    Materia.Visible = false;
                    Alumno.Visible = false;
                    Sancion.Visible = false;
                    Prestamo.Visible = true;
                    BitacoraEntrega.Visible = false;
                    Equipo.Visible = false;
                    break;
                case 6:
                    Asistencia.Visible = false;
                    Materia.Visible = false;
                    Alumno.Visible = false;
                    Sancion.Visible = false;
                    Prestamo.Visible = false;
                    BitacoraEntrega.Visible = true;
                    Equipo.Visible = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
