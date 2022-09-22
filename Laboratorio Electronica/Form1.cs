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
        private SqlConnection conexion = new SqlConnection("Server=HPLAPTOP\\SQLEXPRESS;" + "Database=Laboratorio;" + "Integrated Security=true;");
        public Form1()
        {
            InitializeComponent();
        }
        private void muestraVista()
        {
            string query = String.Concat("SELECT * FROM Persona.Empleado");
            string query1 = String.Concat("SELECT * FROM Persona.Responsable");
            string query2 = String.Concat("SELECT * FROM Persona.Becario");
            string query3 = String.Concat("SELECT * FROM Persona.Colaborador");

            cargarTabla(query, dgridVistaEmpleado);
            cargarTabla(query1, dgridVistaResponsable);
            cargarTabla(query2, dgridVistaBecario);
            cargarTabla(query3, dgridVistaColaborador);
          
        }
        private void cargarTabla(string query, DataGridView destinyTable)
        {
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable registros = new DataTable();
            adapter.Fill(registros);
            destinyTable.DataSource = null;
            destinyTable.DataSource = registros;
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
                string consulta = "INSERT INTO Persona.Empleado(RPE_Empleado,Nombre,Domicilio,Correo,Celular,EmpleadoDesde,Antiguedad,TipoEmpleado) VALUES ('" + RPE_Empleado.Text + "','" + nombre.Text + "', '" + domicilio.Text + "', '" + correo.Text + "', '" + celular.Text + "','" + EmpleadoDesde.Value.ToString("MM/dd/yyyy") + "','" + Antiguedad.Text + "','" + tipoempleado.SelectedItem + "')";
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                cmd.ExecuteNonQuery();
                switch (tipoempleado.SelectedIndex)
                {
                    case 0:
                        consulta = "INSERT INTO Persona.Colaborador(RPE_Colaborador,Desc_act,Hrs_sem) VALUES ('" + RPE_Empleado.Text + "','" + Desc_act.Text + "', '" + Hrssm.Text + "')";
                        cmd = new SqlCommand(consulta, conexion);
                        cmd.ExecuteNonQuery();
                        break;
                    case 1:
                        consulta = "INSERT INTO Persona.Becario(RPE_Becario,Fecha_nac,Hrs_sem,Generacion) VALUES ('" + RPE_Empleado.Text + "','" + Fechanac.Value.ToString("MM/dd/yyyy") + "', '" + Hrs_sem.Text + "', '" + Generacion.Text + "')";
                        cmd = new SqlCommand(consulta, conexion);
                        cmd.ExecuteNonQuery();
                        break;
                    case 2:
                        consulta = "INSERT INTO Persona.Responsable(RPE_Responsable,Antiguedad,Grado,Fecha_Inicio,Fecha_Fin) VALUES ('" + RPE_Empleado.Text + "','" + antiguedadResponsable.Value.ToString("MM/dd/yyyy") + "', '"+Grado.Text +"', '"+ Fechainicio.Value.ToString("MM/dd/yyyy") + "', '" + fechafin.Value.ToString("MM/dd/yyyy") + "')";
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


       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Mostrar ocultar paneles
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            dgridVistaEmpleado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgridVistaEmpleado.MultiSelect = false;
            dgridVistaEmpleado.EditMode = DataGridViewEditMode.EditProgrammatically;

            dgridVistaBecario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgridVistaBecario.MultiSelect = false;
            dgridVistaBecario.EditMode = DataGridViewEditMode.EditProgrammatically;

            dgridVistaColaborador.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgridVistaColaborador.MultiSelect = false;
            dgridVistaColaborador.EditMode = DataGridViewEditMode.EditProgrammatically;

            dgridVistaResponsable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgridVistaResponsable.MultiSelect = false;
            dgridVistaResponsable.EditMode = DataGridViewEditMode.EditProgrammatically;

            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Visible = false;
            conectaBD();
            dgridVistaEmpleado.ClearSelection();
            dgridVistaBecario.ClearSelection();
            dgridVistaResponsable.ClearSelection();
            dgridVistaColaborador.ClearSelection();
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
            clearALL();

        }
        private int cargarDatosEmpleado()
        {
            int selectedRowCount = dgridVistaEmpleado.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var cultureInfo = new System.Globalization.CultureInfo("de-DE");
                DataGridViewRow row = dgridVistaEmpleado.SelectedRows[0];

                RPE_Empleado.Text = row.Cells[0].Value.ToString();
                nombre.Text = row.Cells[1].Value.ToString();
                domicilio.Text = row.Cells[2].Value.ToString();
                correo.Text = row.Cells[3].Value.ToString();
                celular.Text = row.Cells[4].Value.ToString();
                var empleadoDesde = row.Cells[5].Value.ToString();
                Antiguedad.Text = row.Cells[6].Value.ToString();
                tipoempleado.SelectedIndex = tipoempleado.Items.IndexOf(row.Cells[7].Value.ToString()); 
                /*tipoempleado.Items[tipoempleado.Items.IndexOf(int.Parse(row.Cells[7].Value.ToString()))];                               */
                empleadoDesde = empleadoDesde.Substring(0, empleadoDesde.IndexOf(" "));
                var dateTime = DateTime.ParseExact(empleadoDesde, "dd/MM/yyyy", cultureInfo);
                EmpleadoDesde.Value = dateTime;

                cargarDatosSecundarios(int.Parse(RPE_Empleado.Text));

                //En base al rpe y al tipo empleado cargar la tabla resp/col/bec con sus datos

                return int.Parse(RPE_Empleado.Text);
            }
            return -1;
        }
        private void cargarDatosSecundarios(int rpe)
        {
            switch (tipoempleado.SelectedIndex)
            {
                case 0://colaborador
                    string query = String.Concat("SELECT * FROM Persona.Colaborador WHERE RPE_Colaborador="+rpe);
                    fillColaboradorPanel(query);
                    mostrarPanelColab();
                    break;
                case 1://becario
                    string query1 = String.Concat("SELECT * FROM Persona.Becario WHERE RPE_Becario=" + rpe);
                    fillBecarioPanel(query1);
                    mostrarPanelBecario();
                    break;
                case 2://responsable
                    string query2 = String.Concat("SELECT * FROM Persona.Responsable WHERE RPE_Responsable=" + rpe);
                    fillResponsablePanel(query2);
                    mostrarPanelResp();
                    break;
            }
        }
        private void fillColaboradorPanel(string query)
        {
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable registros = new DataTable();
            adapter.Fill(registros);
            var items = registros.Rows[0].ItemArray;
            Desc_act.Text = items[1].ToString();
            Hrssm.Text = items[2].ToString();
        }
        private void fillBecarioPanel(string query)
        {
            var cultureInfo = new System.Globalization.CultureInfo("de-DE");
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable registros = new DataTable();
            adapter.Fill(registros);
            var items = registros.Rows[0].ItemArray;
            string fecha = items[1].ToString();
            fecha = fecha.Substring(0, fecha.IndexOf(" "));
            var dateTime = DateTime.ParseExact(fecha, "dd/MM/yyyy", cultureInfo);
            Fechanac.Value = dateTime;
            Hrs_sem.Text = items[2].ToString();
            Generacion.Text = items[3].ToString();
        }
        private void fillResponsablePanel(string query)
        {
            var cultureInfo = new System.Globalization.CultureInfo("de-DE");
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable registros = new DataTable();
            adapter.Fill(registros);
            var items = registros.Rows[0].ItemArray;
            string fecha = items[1].ToString();
            fecha = fecha.Substring(0, fecha.IndexOf(" "));
            antiguedadResponsable.Value = DateTime.ParseExact(fecha, "dd/MM/yyyy", cultureInfo);
            Grado.Text = items[2].ToString();
            fecha = items[3].ToString();
            fecha = fecha.Substring(0, fecha.IndexOf(" "));
            Fechainicio.Value= DateTime.ParseExact(fecha, "dd/MM/yyyy", cultureInfo);
            fecha = items[4].ToString();
            fecha = fecha.Substring(0, fecha.IndexOf(" "));
            fechafin.Value= DateTime.ParseExact(fecha, "dd/MM/yyyy", cultureInfo);

        }
        private void dgridVista_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = cargarDatosEmpleado(); //obtener id de tupla seleccionada
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnNuevo.Visible = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                try
                {
                    conexion.Open();
                    string consulta = "UPDATE Persona.Empleado SET  WHERE RPE_Empleado=" + id + ";";
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
            clearALL();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                try
                {
                    conexion.Open();
                    string consulta = "DELETE FROM Persona.Empleado WHERE RPE_Empleado=" + id + ";";
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
            clearALL();
        }
        private void mostrarPanelColab()
        {
            Becario.Visible = false;
            Responsable.Visible = false;
            Colaborador.Visible = true;
        }
        private void mostrarPanelBecario()
        {
            Colaborador.Visible = false;
            Becario.Visible = true;
            Responsable.Visible = false;
        }
        private void mostrarPanelResp()
        {
            Colaborador.Visible = false;
            Becario.Visible = false;
            Responsable.Visible = true;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(tipoempleado.SelectedItem.ToString());
            switch (tipoempleado.SelectedIndex)
            {
                case 0:
                    mostrarPanelColab();
                    break;
                case 1:
                    mostrarPanelBecario();
                    break;
                case 2:
                    mostrarPanelResp();
                    break;
               
            }
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
        private void clearALL()
        {
            RPE_Empleado.Clear();
            nombre.Clear(); //limpiar textbox
            domicilio.Clear();
            correo.Clear();
            celular.Clear();
            Antiguedad.Clear();
            Desc_act.Clear();
            Hrssm.Clear();
            Hrs_sem.Clear();
            Generacion.Clear();
            Grado.Clear();
            Becario.Visible = false;
            Responsable.Visible = false;
            Colaborador.Visible = false;
            dgridVistaEmpleado.ClearSelection();
            dgridVistaBecario.ClearSelection();
            dgridVistaResponsable.ClearSelection();
            dgridVistaColaborador.ClearSelection();
            id = -1;
            btnNuevo.Visible = false;
            tipoempleado.SelectedIndex = -1;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            clearALL();
        }
    }
}
