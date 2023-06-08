using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ServiceManager
{
    internal class Conexao
    {
        // String de conexão com o banco de dados MySQL
        public string conect = "SERVER=localhost; DATABASE=managerservices; UID=root; PWP=; PORT=;";

        // Objeto de conexão com o banco de dados
        public MySqlConnection conec = null;

        // Método para abrir a conexão com o banco de dados
        public void AbrirConexao()
        {
            try
            {
                // Criação de um novo objeto MySqlConnection usando a string de conexão
                conec = new MySqlConnection(conect);
                // Abre a conexão com o banco de dados
                conec.Open();
            }
            catch (Exception ex)
            {
                // Exibe uma caixa de mensagem com o erro de conexão
                MessageBox.Show("Erro de conexão ao banco de dados " + ex);
            }

        }

        // Método para fechar a conexão com o banco de dados
        public void FecharConexao()
        {
            try
            {
                // Criação de um novo objeto MySqlConnection usando a string de conexão
                conec = new MySqlConnection(conect);
                // Fecha a conexão com o banco de dados
                conec.Close();
                // Libera os recursos associados à conexão
                conec.Dispose();
                // Limpa todos os pools de conexão assincronamente
                conec.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                // Exibe uma caixa de mensagem com o erro de conexão
                MessageBox.Show("Erro de conexão com o banco de dados " + ex);
            }
        }
    }
}
