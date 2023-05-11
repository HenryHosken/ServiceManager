using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ServiceManager.Cadastros
{
    public partial class FrmFuncionario : Form
    {
        Conexao Conect = new Conexao();
        string sql;
        MySqlCommand cmd;
        string foto;
        
       
        public FrmFuncionario()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {

        }       

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //tratamento de dados
            if ( txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo NOME", "Cadastro funcionaários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }
            if (txtCpf.Text == "   .   .   -" || txtCpf.Text.Length < 14)
            {
                MessageBox.Show("Preencha o campo CPF", "Cadastro funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpf.Focus();
                return;
            }

            //Subir dados para db
            Conect.AbrirConexao();

            sql = "INSERT INTO funcionarios(nome, cpf, telefone, cargo,	endereco, data, imagem) VALUES(@nome, @cpf, @telefone, @cargo, @endereco, now(), @imagem)";

            cmd = new MySqlCommand(sql, Conect.conec);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
            cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
            cmd.Parameters.AddWithValue("@cargo", cbCargo.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
            cmd.Parameters.AddWithValue("@imagem", img());

            cmd.ExecuteNonQuery();
            Conect.FecharConexao();
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Imagens(*.jpg; *.png) | *.jpg;*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foto = dlg.FileName.ToString();
                imgFuncionario.ImageLocation = foto;
            }
        }
        private byte[] img()
        {
            byte[] imagem_byte = null;
            if ( foto == "")
            {
                return null;
            }

            FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);            
            imagem_byte = br.ReadBytes((int)fs.Length);
            return imagem_byte;
        }
        private void LimparFoto()
        {
            imgFuncionario.Image = Properties.Resources.camerapng_parspng_com_2;
            foto = "img/perfil.jpg";
        }
    }
}
