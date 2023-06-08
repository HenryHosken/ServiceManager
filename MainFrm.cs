using ServiceManager.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManager
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuFuncionariosCadastros_Click(object sender, EventArgs e)
        {
           FrmFuncionario frm = new FrmFuncionario();
            frm.ShowDialog();
        }
    }
}
