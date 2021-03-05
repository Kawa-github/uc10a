using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using escolauc10a.Class;

namespace escolauc10a.Forms
{
    public partial class FrmProfessor : Form
    {
        public FrmProfessor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Professor professor= new Professor(txtNome.Text,txtCpf.Text, txtEmail.Text, txtTelefone.Text);
            professor.Inserir();
            txtId.Text = professor.Id_prof.ToString();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {

            Professor professor = new Professor();
            var lista = professor.ObterProfessor();
            foreach (var professores in lista)
            {
                listBox1.Items.Add(professores.Nome_prof + " ----- " + professores.Cpf_prof + " ----- " + professores.Email_prof + " ----- " + professores.Tel_prof);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (btnBuscar.Text == "...")
            {
                txtId.ReadOnly = false;
                txtId.Focus();
                btnBuscar.Text = "Buscar";
                btnInserir.Enabled = false;

            }
            else if (btnBuscar.Text == "Buscar")
            {
                txtId.ReadOnly = true;
                btnBuscar.Text = "...";
                btnEditar.Enabled = true;
                //consultar por id 
                Professor professor = new Professor();
                professor.BuscarPorId(int.Parse(txtId.Text));
                txtNome.Text = professor.Nome_prof;
                txtEmail.Text = professor.Email_prof;
                txtEmail.Enabled = false;
                txtCpf.Text = professor.Cpf_prof;
                txtCpf.Enabled = false;
                txtTelefone.Text = professor.Tel_prof;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (true)
            {

            }
        }
    }
}
