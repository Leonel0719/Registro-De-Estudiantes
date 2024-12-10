using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Registro_de_estudiantes
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //Boton de guardar registro
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();

            alumno.Nombre = txtName.Text;
            alumno.Apellido = txtLastName.Text;
            alumno.Edad = Convert.ToInt32(txtAge.Text);
            alumno.Direccion = txtAddress.Text;
            alumno.Responsable = txtResponsible.Text;
            alumno.Telefono = txtphone.Text;


            int result = AlumnoDAL.AgregarAlumno(alumno);

            if (result > 0)
            {
                MessageBox.Show("Exito al guardar");

            }
            else
            {
                MessageBox.Show("Error al guardar");
            }


            RefreshPantalla();
            
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            RefreshPantalla();
            txtId.Enabled = false;
        }

        //Función para refrecar la pantalla y mostrar los datos
        public void RefreshPantalla()
        {
            dataGridView1.DataSource = AlumnoDAL.PresentarRegistro();
        }

        //Boton para regresar al login
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form1 ir = new Form1();
            ir.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Mostrar registros en el formulario
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtId.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Id"].Value);
            txtName.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre"].Value);
            txtLastName.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Apellido"].Value);
            txtAge.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Edad"].Value);
            txtAddress.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Direccion"].Value);
            txtResponsible.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Responsable"].Value);
            txtphone.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Telefono"].Value);
        }

        //Boton para limpiar los campos
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtLastName.Text = "";
            txtAge.Text = "";
            txtAddress.Text = "";
            txtResponsible.Text = "";
            txtphone.Text = "";
        }

        //Boton para eliminar el registro
        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                int resultado = AlumnoDAL.EliminarAlumno(id);

                if(resultado > 0)
                {
                    MessageBox.Show("Registro Eliminado Con Exito");
                }
                else
                {
                    MessageBox.Show("Error al eliminar");
                }
            }
            RefreshPantalla();
        }
    }
}
