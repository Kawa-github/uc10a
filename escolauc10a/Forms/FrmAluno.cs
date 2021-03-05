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
    public partial class FrmAluno : Form //herança
    {
        public FrmAluno()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmAluno_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void chkAtivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(txtNome.Text,txtEmail.Text,txtSenha.Text);
            aluno.Inserir();
            txtId.Text = aluno.Id.ToString();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            var lista = aluno.ObterAlunos();
            foreach (var item in lista)
            {
                if (item.Ativo)
                {
                    listBox1.Items.Add(item.Id + " ----- " + item.Nome + " ----- " + item.Email);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (btnBuscar.Text=="...")
            {
                txtId.ReadOnly = false;
                txtId.Focus();
                btnBuscar.Text = "Buscar";
                btnInserir.Enabled = false;

            }else if (btnBuscar.Text =="Buscar")
            {
                txtId.ReadOnly = true;
                btnBuscar.Text = "...";
                btnEditar.Enabled = true;
                //consultar por id 
                Aluno aluno = new Aluno();
                aluno.BuscarPorId(int.Parse(txtId.Text));
                txtNome.Text = aluno.Nome;
                txtEmail.Text = aluno.Email;
                txtEmail.Enabled = false;
                chkAtivo.Checked = aluno.Ativo;
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
