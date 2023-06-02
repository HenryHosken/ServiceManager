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
        //Inicio metodos       
        Conexao Conect = new Conexao();
        string sql;
        MySqlCommand cmd;
        string foto;
        string id;
        string cpfAntigo;
       
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

        private void listar()
        {
            Conect.AbrirConexao();
            sql = "SELECT * FROM funcionarios ORDER BY nome asc";
            cmd = new MySqlCommand(sql, Conect.conec);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            Conect.FecharConexao();
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
            btnCancelar.Enabled = false;
            cbCargo.Enabled = false;
            txtCpf.Enabled = false;
            txtTelefone.Enabled = false;
            txtEndereco.Enabled = false;
            txtNome.Enabled = false;
        }

        private void habilitarCampos()
        {
            btnCancelar.Enabled = true;
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
       
        private void FormatarGD()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Nome";
            grid.Columns[2].HeaderText = "CPF";
            grid.Columns[3].HeaderText = "Telefone";
            grid.Columns[4].HeaderText = "Cargo";
            grid.Columns[5].HeaderText = "Endereço";
            grid.Columns[6].HeaderText = "Data";
            grid.Columns[7].HeaderText = "Imagem";


            grid.Columns[0].Visible = false;
            grid.Columns[7].Visible = false;
        }
        string alterouImagem = "nao";


        //Final metodos

        public FrmFuncionario()
        {
            InitializeComponent();            
        }
        private void FrmFuncionario_Load(object sender, EventArgs e)
        {
            LimparFoto();
            listar();
            FormatarGD();
            alterouImagem = "nao";
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {

            habilitarCampos();
            txtNome.Focus();
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
            if (txtTelefone.Text == "(  )     -" || txtTelefone.Text.Length < 14)
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
            listar();

            MessageBox.Show("Resgistro salvo com sucesso!", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Information);

            limparCampos();
            desabilitarCampos();           
        }
        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Imagens(*.jpg; *.png) | *.jpg;*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foto = dlg.FileName.ToString();
                imgFuncionario.ImageLocation = foto;
                alterouImagem = "sim";
            }
            
        }
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                desabilitarCampos();                
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = false;
                btnNovo.Enabled = false;
                btnCancelar.Enabled = true;
                
                id = grid.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
                txtCpf.Text = grid.CurrentRow.Cells[2].Value.ToString();
                cpfAntigo = grid.CurrentRow.Cells[2].Value.ToString();
                txtTelefone.Text = grid.CurrentRow.Cells[3].Value.ToString();
                cbCargo.Text = grid.CurrentRow.Cells[4].Value.ToString();
                txtEndereco.Text = grid.CurrentRow.Cells[5].Value.ToString();

                if (grid.CurrentRow.Cells[7].Value != DBNull.Value)
                {
                    byte[] imagem = (byte[])grid.Rows[e.RowIndex].Cells[7].Value;
                    MemoryStream ms = new MemoryStream(imagem);
                    imgFuncionario.Image =Image.FromStream(ms);
                }
                else
                {
                    imgFuncionario.Image = Properties.Resources.camera;
                }
            }
            else
            {
                return;
            }

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo nome", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            if (txtNome.Text == "   ,   ,   -" || txtCpf.Text.Length < 14)
            {
                MessageBox.Show("Preencha o campo CPF", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpf.Focus();
                return;
            }

            //botao editar
            Conect.AbrirConexao();
            if(alterouImagem == "sim")
            {
                sql = "UPDATE funcionarios SET nome = @nome, cpf = @cpf, telefone = @telefone, cargo = @cargo, endereco = @endereco, data = @data, imagem = @imagem WHERE id= @id";

                cmd = new MySqlCommand(sql, Conect.conec);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                cmd.Parameters.AddWithValue("@cargo", cbCargo.Text);
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@imagem", img());
            } 
            else if (alterouImagem == "nao")
            {
              sql = "UPDATE funcionarios SET nome = @nome, cpf = @cpf, telefone = @telefone, cargo = @cargo, endereco = @endereco, data = @data, imagem = @imagem WHERE id= @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                cmd.Parameters.AddWithValue("@cargo", cbCargo.Text);
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);                
            }

            //Verificar se CPF já existe

            if (txtCpf.Text != cpfAntigo)
            {
                MySqlCommand cmdVerificar;
                cmdVerificar = new MySqlCommand ("SLECT * FROM funcionarios WHERE cpf = @cpf", Conect.conec);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                cmdVerificar.Parameters.AddWithValue("@cpf", txtCpf.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("CPF já registrado", "Casdastro de funcionários", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    txtCpf.Text = "";
                    txtCpf.Focus();
                    return;
                }
            }

            cmd.ExecuteNonQuery();
            Conect.FecharConexao();
            listar();

            MessageBox.Show("Registro Editado com Sucesso!", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            btnEditar.Enabled = false;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            desabilitarCampos();
            limparCampos();
            LimparFoto();
            alterouImagem = "nao"; // p uso de editar imagem
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
           
            desabilitarCampos();
            limparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Conect.AbrirConexao();
            sql = "DELETE FROM funcionarios WHERE id = @id";
            cmd = new MySqlCommand(sql, Conect.conec);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Conect.FecharConexao();

            desabilitarCampos();
            listar();
            limparCampos();
            MessageBox.Show("Registro Apagado com Sucesso!", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
