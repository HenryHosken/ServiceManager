using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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

            FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imagem_byte = br.ReadBytes((int)fs.Length);
            return imagem_byte;
        }

        // Função para listar os funcionários no grid
        private void listar()
        {
            Conect.AbrirConexao();
            sql = "SELECT * FROM funcionarios ORDER BY nome ASC";
            cmd = new MySqlCommand(sql, Conect.conec);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            Conect.FecharConexao();
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
            cmd = new MySqlCommand(sql, Conect.conec);
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

            // Inserir dados no banco de dados
            Conect.AbrirConexao();
            sql = "INSERT INTO funcionarios(nome, cpf, telefone, cargo, endereco, data, imagem) VALUES(@nome, @cpf, @telefone, @cargo, @endereco, now(), @imagem)";
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

            MessageBox.Show("Registro salvo com sucesso!", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Information);

            limparCampos();
            desabilitarCampos();
        }

        private void SalvarEdicao()
        {
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
                sql = "UPDATE funcionarios SET nome = @nome, cpf = @cpf, telefone = @telefone, cargo = @cargo, endereco = @endereco WHERE id = @id";
                cmd = new MySqlCommand(sql, Conect.conec);
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
                cmdVerificar = new MySqlCommand("SELECT * FROM funcionarios WHERE cpf = @cpf", Conect.conec);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                cmdVerificar.Parameters.AddWithValue("@cpf", txtCpf.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("CPF já registrado", "Cadastro de funcionários", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                cmd.ExecuteNonQuery();
                Conect.FecharConexao();
                listar();
            }

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
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            txtNome.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
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
        private void btnImagen_Click(object sender, EventArgs e)
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

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    byte[] imagem = (byte[])grid.Rows[e.RowIndex].Cells[7].Value;
                    MemoryStream ms = new MemoryStream(imagem);
                    imgFuncionario.Image = Image.FromStream(ms);
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
            btnEditar.Enabled = false;
            ModoEdicao = true;
            habilitarCampos();
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            alterouImagem = false;
            ModoEdicao = false;
            desabilitarCampos();
            limparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Deseja realmente excluir o registro", "Cadastro funcionarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Conect.AbrirConexao();
                sql = "DELETE FROM funcionarios WHERE id = @id";
                cmd = new MySqlCommand(sql, Conect.conec);
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
            Conect.AbrirConexao();
            sql = "SELECT * FROM cargos ORDER BY nomeCargo asc";
            cmd = new MySqlCommand(sql, Conect.conec);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbCargo.DataSource = dt;
            // cbCargo.ValueMember = "ID";
            cbCargo.DisplayMember = "nomeCargo";
            Conect.FecharConexao();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlterarImagemBd();
        }
    }
}
        
    

