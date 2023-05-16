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

        //Inicio metodos
        private byte[] img()
        {
            byte[] imagem_byte = null;
            if (foto == "")
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
            imgFuncionario.Image = Properties.Resources.camera;
            foto = "img/camera.png";
        }

        private void desabilitarCampos()
        {
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnImagen.Enabled = false;
            cbCargo.Enabled = false;
            txtCpf.Enabled = false;
            txtTelefone.Enabled = false;
            txtEndereco.Enabled = false;
            txtNome.Enabled = false;
        }

        private void habilitarCampos()
        {
            btnSalvar.Enabled = true;
            txtCpf.Enabled = true;
            txtEndereco.Enabled = true;
            txtNome.Enabled = true;
            txtTelefone.Enabled = true;
            btnImagen.Enabled = true;
            cbCargo.Enabled = true;
        }
        private void limparCampos()
        {
            txtCpf.Text = "";
            txtEndereco.Text = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
            cbCargo.Text = "";
        }
        private void listar()
        {
            Conect.AbrirConexao();
            sql = "SELECT * FROM funcionarios ORDER BY nome asc";
            cmd = new MySqlCommand(sql, Conect.conec);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            Conect.FecharConexao();
        }
        //Final metodos

        public FrmFuncionario()
        {
            InitializeComponent();            
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //tratamento de dados
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo NOME", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }
            if (txtCpf.Text == "   ,   ,   -" || txtCpf.Text.Length < 14)
            {
                MessageBox.Show("Preencha o campo CPF", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpf.Focus();
                return;
            }
            if (txtTelefone.Text == "(  )      -" || txtTelefone.Text.Length < 15)
            {
                MessageBox.Show("Preencha o campo TELEFONE", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefone.Focus();
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

            LimparFoto();            

            MessageBox.Show("Resgistro salvo com sucesso!", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Information);

            desabilitarCampos();
            limparCampos();
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


        private void FrmFuncionario_Load(object sender, EventArgs e)
        {
            LimparFoto();
            listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
