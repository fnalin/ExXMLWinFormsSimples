using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExXML
{
    public partial class Form1 : Form
    {
        private List<Pessoa> pessoas;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pessoas = Pessoa.ListarPessoas();
            gridPessoas.DataSource = pessoas;
        }

        private void gridPessoas_SelectionChanged(object sender, EventArgs e)
        {
            if (gridPessoas.SelectedRows.Count > 0)
            {
                int indice = gridPessoas.SelectedRows[0].Index;
                if (indice >= 0)
                {
                    txtCodigo.Text = pessoas[indice].Codigo.ToString();
                    txtNome.Text = pessoas[indice].Nome;
                    txtTelefone.Text = pessoas[indice].Telefone;
                }
            }


        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var p = new Pessoa()
                {
                    Codigo = Convert.ToInt32(txtCodigo.Text),
                    Nome = txtNome.Text,
                    Telefone = txtTelefone.Text
                };
            Pessoa.AdicionarPessoa(p);
            pessoas = Pessoa.ListarPessoas();
            gridPessoas.DataSource = pessoas;


        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gridPessoas.SelectedRows.Count > 0)
            {
                int indice = gridPessoas.SelectedRows[0].Index;
                Pessoa.ExcluirPessoa(pessoas[indice].Codigo);
                pessoas = Pessoa.ListarPessoas();
                gridPessoas.DataSource = pessoas;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa()
                {
                    Codigo = Convert.ToInt32(txtCodigo.Text),
                    Nome = txtNome.Text,
                    Telefone = txtTelefone.Text
                };
            Pessoa.EditarPessoa(p);
            pessoas = Pessoa.ListarPessoas();
            gridPessoas.DataSource = pessoas;

        }

    }
}
