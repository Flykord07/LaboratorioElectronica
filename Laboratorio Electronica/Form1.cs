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
        SqlConnection conexion = new SqlConnection("Server=DESKTOP-O0MDQRH\\SQLEXPRESS;" + "Database=Laboratorio;" + "Integrated Security=true;");
        public Form1()
        {
            InitializeComponent();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void colaboradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
