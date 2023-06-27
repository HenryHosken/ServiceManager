using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static ServiceManager.MainFrm;

namespace ServiceManager.Cadastros
{
    public partial class FrmFuncionario : Form
    {
        // Declaração de variáveis e objetos
        Conexao Conect = new Conexao();
        string sql;
        MySqlCommand cmd;
        string foto;
        string id;
        string cpfAntigo;
        bool alterouImagem = false;
        bool ModoEdicao = false;
        // Função para converter a imagem selecionada em um array de bytes

        private byte[] img()
        {
            byte[] imagem_byte = null;
            if (foto == "")
            {
                return null;
            }

            try
            {
                FileStream fstream = new FileStream(foto, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imagem_byte = br.ReadBytes((int)fstream.Length);
                return imagem_byte;
            }
            catch (Exception ex)
            {
                // Tratamento de exceção ao ler a imagem
                MessageBox.Show("Erro ao ler a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Função para listar os funcionários no grid
        private void listar()
        {
            try
            {
                Conect.AbrirConexao();
                sql = "SELECT * FROM funcionarios ORDER BY nome ASC";
                cmd = new MySqlCommand(sql, Conect.connection);
                MySqlDataAdapter data = new MySqlDataAdapter(cmd);
                data.SelectCommand = cmd;
                DataTable dt = new DataTable();
                data.Fill(dt);
                grid.DataSource = dt;
                Conect.FecharConexao();
            }
            catch (Exception ex)
            {
                // Tratamento de exceção ao listar funcionários
                MessageBox.Show("Erro ao listar funcionários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Função para limpar a foto do funcionário
        private void LimparFoto()
        {
            imgFuncionario.Image = Properties.Resources.camera;
            foto = "img/camera.png";
        }        

        // Função para desabilitar os campos do formulário
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

        // Função para habilitar os campos do formulário
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

        // Função para limpar os campos do formulário
        private void limparCampos()
        {
            txtCpf.Text = "";
            txtEndereco.Text = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
            cbCargo.Text = "";
        }

        // Função para formatar as colunas do grid
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

        private void AlterarImagemBd()
        {
            Conect.AbrirConexao();

            sql = "UPDATE funcionarios SET  imagem = @imagem ";
            cmd = new MySqlCommand(sql, Conect.connection);
            cmd.Parameters.AddWithValue("@imagem", img());
            cmd.ExecuteNonQuery();
            Conect.FecharConexao();
            listar();
        }

        private void SalvarNovo()
        {
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
            if (cbCargo.Text == "Selecione o cargo")
            {
                MessageBox.Show("Selecione o cargo do funcionário", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbCargo.Focus();
                return;
            }

            // Inserir dados no banco de dados
            Conect.AbrirConexao();
            sql = "INSERT INTO funcionarios(nome, cpf, telefone, cargo, endereco, data, imagem) VALUES(@nome, @cpf, @telefone, @cargo, @endereco, now(), @imagem)";
            cmd = new MySqlCommand(sql, Conect.connection);
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

            MessageBox.Show("Registro salvo com sucesso!", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Information);

            limparCampos();
            desabilitarCampos();
        }

        private void SalvarEdicao()
        {
            Conect.AbrirConexao();
            cmd = new MySqlCommand(sql, Conect.connection);

            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Prencha o campo nome", "Cadastro funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            if (txtCpf.Text.ToString().Trim() == "   ,   ,   -" || txtCpf.Text.Length < 14)
            {
                MessageBox.Show("Preencher o campo CPF", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpf.Focus();
                return;
            }
            if (ModoEdicao == true)
            {
                sql = "UPDATE funcionarios SET  nome = @nome, cpf = @cpf, telefone = @telefone, cargo = @cargo, endereco = @endereco WHERE id = @id ";
                cmd = new MySqlCommand(sql, Conect.connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                cmd.Parameters.AddWithValue("@cargo", cbCargo.Text);
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);

            }
            if (alterouImagem == true)
            {
                AlterarImagemBd();
            }
            if (txtCpf.Text != cpfAntigo)
            {
                MySqlCommand cmdVerificar;
                cmdVerificar = new MySqlCommand("SELECT * FROM funcionarios WHERE cpf = @cpf", Conect.connection);
                MySqlDataAdapter data = new MySqlDataAdapter();
                data.SelectCommand = cmdVerificar;
                cmdVerificar.Parameters.AddWithValue("@cpf", txtCpf.Text);
                DataTable dt = new DataTable();
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("CPF já registrado", "Cadastro de funcionários", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            cmd.ExecuteNonQuery();
            Conect.FecharConexao();
            listar();
            MessageBox.Show("Registro Editado com Sucesso!", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnEditar.Enabled = false;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            desabilitarCampos();
            limparCampos();
            LimparFoto();
            ModoEdicao = false;
            alterouImagem = false; // Para uso de editar imagem
        }

        public FrmFuncionario()
        {
            InitializeComponent();
        }

        private void FrmFuncionario_Load(object sender, EventArgs e)
        {            
            ListarCargos();
            LimparFoto();
            listar();
            FormatarGD();
            cbCargo.Text = "Selecione o cargo";
        }

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            habilitarCampos();
            btnNovo.Enabled = false;
            txtNome.Focus();
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            if (ModoEdicao == false)
            {
                SalvarNovo();
            }
            else
            {
                SalvarEdicao();
            }
        }
        private void btnImagen_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Imagens(*.jpg; *.png) | *.jpg;*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foto = dlg.FileName.ToString();
                imgFuncionario.ImageLocation = foto;
                alterouImagem = true;
            }

        }

        private void grid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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
                txtTelefone.Text = grid.CurrentRow.Cells[3].Value.ToString();
                cbCargo.Text = grid.CurrentRow.Cells[4].Value.ToString();
                txtEndereco.Text = grid.CurrentRow.Cells[5].Value.ToString();

                // Captura de dados
                cpfAntigo = grid.CurrentRow.Cells[2].Value.ToString();
                //

                if (grid.CurrentRow.Cells[7].Value != DBNull.Value)
                {
                    string imagemPath = grid.CurrentRow.Cells[7].Value.ToString();
                    if (File.Exists(imagemPath))
                    {
                        imgFuncionario.Image = Image.FromFile(imagemPath);
                    }
                    else
                    {
                        imgFuncionario.Image = Properties.Resources.camera;
                    }
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

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            ModoEdicao = true;
            habilitarCampos();
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            alterouImagem = false;
            ModoEdicao = false;
            desabilitarCampos();
            limparCampos();
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Deseja realmente excluir o registro", "Cadastro funcionarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Conect.AbrirConexao();
                sql = "DELETE FROM funcionarios WHERE id = @id";
                cmd = new MySqlCommand(sql, Conect.connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Conect.FecharConexao();
                listar();
                MessageBox.Show("Registro Excluido com Sucesso!", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                limparCampos();
                LimparFoto();
                desabilitarCampos();
                btnNovo.Enabled = true;
            }
        }

        private void ListarCargos()
        {
            try
            {
                Conect.AbrirConexao();
                sql = "SELECT * FROM cargos ORDER BY nomeCargo asc";
                cmd = new MySqlCommand(sql, Conect.connection);
                MySqlDataAdapter data = new MySqlDataAdapter();
                data.SelectCommand = cmd;
                DataTable dt = new DataTable();
                data.Fill(dt);
                cbCargo.DataSource = dt;
                cbCargo.DisplayMember = "nomeCargo";
                Conect.FecharConexao();
            }
            catch (Exception ex)
            {
                // Tratamento de exceção ao listar cargos
                MessageBox.Show("Erro ao listar cargos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }    

       
    }
}



