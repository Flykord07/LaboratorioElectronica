using System;
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
        private int id,NumInv, Adeudo,IdPrestamo;
        string cu;
        string RPE_Antiguo;
        DataTable dt;
        DataTable dato;
        private SqlConnection conexion = new SqlConnection("Server=DESKTOP-O0MDQRH\\SQLEXPRESS;" + "Database=Laboratorio;" + "Integrated Security=true;");
        public Form1()
        {
            InitializeComponent();
            
            dato=LlenaRPEEmpleado();
            llenaCamposCombo(dato);
            LlenaClavesAsistencia();
            LlenaClaveMateria();
            LlenaNumInv();
            muestraVistaEquipo(); 
            muestraVistaAlumno();
            //Antiguedad.Visible = false;
            Antiguedad.Enabled = false;
        }

        private void muestraVista()
        {
            string query = String.Concat("SELECT * FROM Persona.Empleado");
            string query1 = String.Concat("SELECT * FROM Persona.Responsable");
            string query2 = String.Concat("SELECT * FROM Persona.Becario");
            string query3 = String.Concat("SELECT * FROM Persona.Colaborador");
            string query4 = String.Concat("SELECT * FROM Aula.Prestamo");
            cargarTabla(query, dgridVistaEmpleado);
            cargarTabla(query1, dgridVistaResponsable);
            cargarTabla(query2, dgridVistaBecario);
            cargarTabla(query3, dgridVistaColaborador);
            cargarTabla(query4, DatosPrestamo);


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
                muestraVistaAlumno();
                muestraVistaPrestamo();
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
                int añodesde = EmpleadoDesde.Value.Year;
                int actual = DateTime.Today.Year;
                string antiguedad = (actual - añodesde).ToString();
                
                string consulta = "INSERT INTO Persona.Empleado(RPE_Empleado,Nombre,Domicilio,Correo,Celular,EmpleadoDesde,Antiguedad,TipoEmpleado) VALUES ('" + RPE_Empleado.Text + "','" + nombre.Text + "', '" + domicilio.Text + "', '" + correo.Text + "', '" + celular.Text + "','" + EmpleadoDesde.Value.ToString("MM/dd/yyyy") + "','" + antiguedad + "','" + tipoempleado.SelectedItem + "')";
               
               
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
            //Asistencia.Visible = false;
            Materia.Visible = false;
           
            Sancion.Visible = false;
            Prestamo.Visible = true;
            BitacoraEntrega.Visible = false;
                                   
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            insertarRegistro();
            conectaBD();
            clearALL();

        }

        private void llenaCamposCombo(DataTable datos)
        {
            foreach (DataRow dr in datos.Rows)
            {
                //nombres.Add(dr["Usuario"].ToString());
                RPE_Asist.Items.Add(dr[0].ToString());
                RPEPrestamo.Items.Add(dr[0].ToString());
            }
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
                    string consulta = "";
                    SqlCommand cmd;
                    consulta = "UPDATE Persona.Empleado SET RPE_Empleado='" + RPE_Empleado.Text + "', Nombre='" + nombre.Text + "',Domicilio='" + domicilio.Text + "',Correo='" + correo.Text + "',Celular='" + celular.Text + "',EmpleadoDesde='" + EmpleadoDesde.Value.ToString("MM/dd/yyyy") + "',Antiguedad='" + Antiguedad.Text + "',TipoEmpleado='" + tipoempleado.SelectedItem + "' WHERE RPE_Empleado='" + RPE_Antiguo + "'";
                    cmd = new SqlCommand(consulta, conexion);
                    cmd.ExecuteNonQuery();
                    switch (tipoempleado.SelectedIndex)
                    {
                        case 0:
                            consulta = "UPDATE Persona.Colaborador SET RPE_Colaborador='"+RPE_Empleado.Text+"', Desc_act='" + Desc_act.Text + "',Hrs_sem= '" + Hrssm.Text + "' WHERE RPE_Colaborador="+RPE_Antiguo;
                            cmd = new SqlCommand(consulta, conexion);
                            cmd.ExecuteNonQuery();
                            break;
                        case 1:
                            consulta = "UPDATE Persona.Becario SET  RPE_Becario='" + RPE_Empleado.Text + "',Fecha_nac='" + Fechanac.Value.ToString("MM/dd/yyyy") + "',Hrs_sem= '" + Hrs_sem.Text + "',Generacion= '" + Generacion.Text + "'WHERE RPE_Becario=" + RPE_Antiguo;
                            cmd = new SqlCommand(consulta, conexion);
                            cmd.ExecuteNonQuery();
                            break;
                        case 2:
                            consulta = "UPDATE Persona.Responsable SET RPE_Responsable='" + RPE_Empleado.Text + "', Antiguedad='" + antiguedadResponsable.Value.ToString("MM/dd/yyyy") + "',Grado= '" + Grado.Text + "',Fecha_Inicio= '" + Fechainicio.Value.ToString("MM/dd/yyyy") + "',Fecha_Fin='" + fechafin.Value.ToString("MM/dd/yyyy")+"'WHERE RPE_Responsable="+RPE_Antiguo;
                            cmd = new SqlCommand(consulta, conexion);
                            cmd.ExecuteNonQuery();
                            break;
                    }
                  
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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        //Esta funcion se usa para mostrar en el combobox los alumnos que puede agregar
        private void LlenaClavesAsistencia()
        {
            string consulta = "SELECT Clave_Unica,Nombre FROM Persona.Alumno";
            conexion.Open();
           
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dt = new DataTable();
                if (reader.HasRows)
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    reader.Dispose();
                    da.Fill(dt);
                }
            }
            conexion.Close();
            foreach (DataRow dr in dt.Rows)
            {
                //nombres.Add(dr["Usuario"].ToString());
                Datos.Items.Add(dr[0].ToString());
                clavesPrestamo.Items.Add(dr[0].ToString()+","+dr[1].ToString());
                
            }
        }

        private void LlenaNumInv()
        {
            string consulta = "SELECT NumInv,Nombre FROM Aula.Equipo";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(consulta, conexion);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dt = new DataTable();
                if (reader.HasRows)
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    reader.Dispose();
                    da.Fill(dt);
                }
            }
            conexion.Close();
            foreach (DataRow dr in dt.Rows)
            {
                //nombres.Add(dr["Usuario"].ToString());
                NumInvPrestamo.Items.Add(dr[0].ToString()+","+ dr[1].ToString());
              

            }
        }

        private DataTable LlenaRPEEmpleado()
        {
            string consulta = "SELECT RPE_Empleado,Nombre FROM Persona.Empleado";
            conexion.Open();
            DataTable dt;
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dt = new DataTable();
                if (reader.HasRows)
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    reader.Dispose();
                    da.Fill(dt);
                }
            }
            conexion.Close();
            foreach (DataRow dr in dt.Rows)
            {
                //nombres.Add(dr["Usuario"].ToString());
                //NumInvPrestamo.Items.Add(dr[0].ToString() + "," + dr[1].ToString());
                RPEPrestamo.Items.Add(dr[0].ToString() + "," + dr[1].ToString());


            }
            return dt;
        }

        private void LlenaClaveMateria()
        {
            string consulta = "SELECT ClaveMateria FROM Aula.Materia";
            conexion.Open();
            DataTable dt;
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dt = new DataTable();
                if (reader.HasRows)
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    reader.Dispose();
                    da.Fill(dt);
                }
            }
            conexion.Close();
            foreach (DataRow dr in dt.Rows)
            {
                //nombres.Add(dr["Usuario"].ToString());
                Materia_Asist.Items.Add(dr[0].ToString());
            }
            
        }
        private void Datos_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //cmd.ExecuteNonQuery();
     
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

        private void muestraVistaEquipo()
        {
            string query = String.Concat("SELECT * FROM Aula.Equipo");

            SqlCommand cmd = new SqlCommand(query, conexion);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable registros = new DataTable();

            adapter.Fill(registros);

            dataGridEquipo.DataSource = null;

            dataGridEquipo.DataSource = registros;
        }

        private void muestraVistaPrestamo()
        {
            string query = String.Concat("SELECT * FROM Aula.Prestamo");

            SqlCommand cmd = new SqlCommand(query, conexion);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable registros = new DataTable();

            adapter.Fill(registros);

            DatosPrestamo.DataSource = null;

            DatosPrestamo.DataSource = registros;
        }

        private int modificarRegistroEquipo()
        {
            try
            {
                conexion.Open();

                string consulta = "UPDATE Aula.Equipo SET Nombre='" + nombreEquipo.Text + "',Modelo='" + Modelo.Text + "',Descripcion='" + descEquipo.Text + "',UbicacionEnLab='" + ubiLab.Text + "',Marca='" + marca.Text + "',TipoEquipo='" + tipoEquipo.Text + "' WHERE NumInv=" + NumInv;

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
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
        
        private int eliminaRegistroEquipo()
        {
            try
            {
                conexion.Open();

                string consulta = "DELETE FROM Aula.Equipo WHERE NumInv=" + NumInv;
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
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

        private int eliminaRegistroPrestamo()
        {
            try
            {
                conexion.Open();
                
                string consulta = "DELETE FROM Aula.Prestamo WHERE Id_Prestamo=" + IdPrestamo;
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
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
        private int conectaBDEquipo()
        {
            try
            {
                conexion.Open();
                muestraVistaEquipo();
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
        
        private int insertarRegistroEquipo()
        {
            try
            {
                conexion.Open();
                string consulta = "INSERT INTO Aula.Equipo(Nombre,Modelo,Descripcion,UbicacionEnLab,Marca,TipoEquipo) VALUES ('" + nombreEquipo.Text + "', '" + Modelo.Text + "', '" + descEquipo.Text + "', '" + ubiLab.Text + "','" + marca.Text + "','" + tipoEquipo.Text + "')";
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                cmd.ExecuteNonQuery();


                conexion.Close();
                return 0;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show("Error de conexion: No se pueden agregar equipos de ese tipo");
                //MessageBox.Show("ee" + ex.);
                return 1;
            }
        }

        private int insertarRegistroPrestamo()
        {
            try
            {
                conexion.Open();
                string[] claveP = clavesPrestamo.SelectedItem.ToString().Split(',');
                string[] numinvP = NumInvPrestamo.SelectedItem.ToString().Split(',');
                string[] rpeP = RPEPrestamo.SelectedItem.ToString().Split(',');
                string consulta = "INSERT INTO Aula.Prestamo(NumInv,Clave_Unica,RPE_Empleado) VALUES ('" +Convert.ToInt32(numinvP[0]) + "', '" + Convert.ToInt32(claveP[0]) + "', '" + Convert.ToInt32(rpeP[0]) + "')";
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                cmd.ExecuteNonQuery();


                conexion.Close();
                return 0;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show("Error de conexion: No se pueden agregar equipos de ese tipo");
                //MessageBox.Show("ee" + ex.);
                return 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            insertarRegistroEquipo();
            conectaBDEquipo();
            //nombre.Clear(); //limpiar textbox
            dataGridEquipo.ClearSelection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            modificarRegistroEquipo();
            conectaBDEquipo();
        }

        private void dataGridEquipo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            nombreEquipo.Text = dataGridEquipo.Rows[dataGridEquipo.CurrentRow.Index].Cells[1].Value.ToString();
            Modelo.Text = dataGridEquipo.Rows[dataGridEquipo.CurrentRow.Index].Cells[2].Value.ToString();
            descEquipo.Text = dataGridEquipo.Rows[dataGridEquipo.CurrentRow.Index].Cells[3].Value.ToString();
            ubiLab.Text = dataGridEquipo.Rows[dataGridEquipo.CurrentRow.Index].Cells[4].Value.ToString();
            marca.Text = dataGridEquipo.Rows[dataGridEquipo.CurrentRow.Index].Cells[5].Value.ToString();
            tipoEquipo.Text = dataGridEquipo.Rows[dataGridEquipo.CurrentRow.Index].Cells[6].Value.ToString();
            NumInv = Convert.ToInt32(dataGridEquipo.Rows[dataGridEquipo.CurrentRow.Index].Cells[0].Value);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            eliminaRegistroEquipo();
            conectaBDEquipo();
        }

        private int insertaAlumno()
        {
            try
            {
                conexion.Open();
                string consulta = "INSERT INTO Persona.Alumno (Clave_Unica, Nombre, Generacion, Carrera,Adeudo) VALUES ('" + Convert.ToInt32(txtBoxClaveAlum.Text) + "','" + txtBoxNomAlum.Text + "', '" + txtBoxGeneracion.Text + "', '" + txtBoxCarrera.Text + "','"+0+"')";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();

                txtBoxClaveAlum.Text = "";
                txtBoxNomAlum.Text = "";
                txtBoxGeneracion.Text = "";
                txtBoxCarrera.Text = "";

                return 0;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show("Error de conexión (inserta alumno): " + ex.Message);
                return 1;
            }
        }

        private int eliminaAlumno()
        {
            try
            {
                conexion.Open();
                string elimina = "DELETE FROM Persona.Alumno WHERE nombre='" + txtBoxNomAlum.Text + "'";
                SqlCommand comando = new SqlCommand(elimina, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();

                txtBoxClaveAlum.Text = "";
                txtBoxNomAlum.Text = "";
                txtBoxGeneracion.Text = "";
                txtBoxCarrera.Text = "";

                return 0;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show("Error de conexión (elimina alumno): " + ex.Message);
                return 1;
            }
        }

        private void dgvAlumno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnElimAlum_Click(object sender, EventArgs e)
        {
            eliminaAlumno();
            conectaBD();
        }

        private void btnAgregarAlum_Click_1(object sender, EventArgs e)
        {
            insertaAlumno();
            conectaBD();
        }

        private void btnModifAlum_Click(object sender, EventArgs e)
        {
            modificaAlumno();
            conectaBD();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabAlumno_Click(object sender, EventArgs e)
        {

        }

        private void dgvAlumno_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtBoxClaveAlum.Text = dgvAlumno.CurrentRow.Cells[0].Value.ToString();
            txtBoxNomAlum.Text = dgvAlumno.CurrentRow.Cells[1].Value.ToString();
            txtBoxGeneracion.Text = dgvAlumno.CurrentRow.Cells[2].Value.ToString();
            txtBoxCarrera.Text = dgvAlumno.CurrentRow.Cells[3].Value.ToString();
            Adeudo = Convert.ToInt32(dgvAlumno.Rows[dgvAlumno.CurrentRow.Index].Cells[4].Value);
             cu= txtBoxClaveAlum.Text;
        }

        private void DatosPrestamo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = DatosPrestamo.SelectedRows[0];
            //IdPrestamo = Convert.ToInt32(row.Cells[0].Value);
            IdPrestamo=Convert.ToInt32 (DatosPrestamo.Rows[DatosPrestamo.CurrentRow.Index].Cells[0].Value.ToString());
            NumInvPrestamo.Text = DatosPrestamo.Rows[DatosPrestamo.CurrentRow.Index].Cells[1].Value.ToString();
            clavesPrestamo.Text = DatosPrestamo.Rows[DatosPrestamo.CurrentRow.Index].Cells[2].Value.ToString();
            RPEPrestamo.Text = DatosPrestamo.Rows[DatosPrestamo.CurrentRow.Index].Cells[3].Value.ToString();
            //NumInv = Convert.ToInt32(DatosPrestamo.Rows[DatosPrestamo.CurrentRow.Index].Cells[4].Value);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            insertarRegistroPrestamo();
            conectaBD();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void DatosPrestamo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            eliminaRegistroPrestamo();
            conectaBD();
        }

        private void Asistencia_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            modificaPrestamo();
            conectaBD();
        }

        private void dgridVistaEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RPE_Antiguo = dgridVistaEmpleado.Rows[dgridVistaEmpleado.CurrentRow.Index].Cells[0].Value.ToString();
        }

        private int modificaPrestamo()
        {
       
            try
            {
                conexion.Open();
                string[] claveP = clavesPrestamo.SelectedItem.ToString().Split(',');
                string[] numinvP = NumInvPrestamo.SelectedItem.ToString().Split(',');
                string[] rpeP = RPEPrestamo.SelectedItem.ToString().Split(',');
                MessageBox.Show(claveP[0] + " " + numinvP[0] + " " + rpeP[0]);
                string consulta = "UPDATE Aula.Prestamo SET NumInv = '" + Convert.ToInt32(numinvP[0]) + "', Clave_Unica='" + Convert.ToInt32(claveP[0]) + "', RPE_Empleado='" + Convert.ToInt32(rpeP[0])+ "' WHERE Id_Prestamo=" + IdPrestamo;
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
                return 0;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show("Error de conexion: " + ex.Message+" Prestamo" );
                return 1;
            }
        }
        private int modificaAlumno()
        {
            try
            {
                conexion.Open();

                string consulta = "UPDATE Persona.Alumno SET Clave_Unica = '" + txtBoxClaveAlum.Text + "', Nombre='" + txtBoxNomAlum.Text + "', Generacion='" + txtBoxGeneracion.Text.ToString() + "', Carrera='" + txtBoxCarrera.Text + "' WHERE Clave_Unica=" + cu;
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
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

        private void muestraVistaAlumno()
        {
            string query = String.Concat("SELECT * FROM Persona.Alumno");
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable registros = new DataTable();
            adapter.Fill(registros);
            dgvAlumno.DataSource = null;
            dgvAlumno.DataSource = registros;
        }
    }
}
