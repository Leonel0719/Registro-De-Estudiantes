using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro_de_estudiantes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Este codigo es el del boton.
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Aqui se empieza a darle la funcionalidad al boton.
            
            string User = txtUser.Text;
            string Password = txtPassword.Text;

            //Aqui se inicia la estructura (SI y SINO).

            if (User == "Admin" && Password == "Admin2024")
            {
                this.DialogResult = DialogResult.OK;

                MessageBox.Show("Acceso Concedido, Bienvenido/a");

                //Este codigo de abajo es para que lo mande al sigueinte formulario

                Form2 ir = new Form2();
                ir.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Acceso Denegado, Usuario o contraseña incorrecta");

                txtUser.Text = "";
                txtPassword.Text = "";
            }
        }
    }
}
