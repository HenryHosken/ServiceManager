using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManager
{
    internal class Conexao
    {
        public string conect = "SERVER=localhost; DATABASE=managerservices; UID=root; PWP=; PORT=;";

        public MySqlConnection conec = null;

        public void AbrirConexao()
        {
            try 
            {
                conec = new MySqlConnection(conect);
                conec.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão ao banco de dados " + ex);
            }

        }
        public void FecharConexao()
        {
            try
            {
                conec = new MySqlConnection(conect);
                conec.Close();
                conec.Dispose(); //Fecha conexãoes abertas
                conec.ClearAllPoolsAsync(); //Limpeza de metodos
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Erro de conexão com o banco de dados " + ex );
            }
        }
    }
}
