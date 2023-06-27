namespace ServiceManager
{
    partial class MainFrm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFuncionariosCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClientesCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUsuariosCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFornecedoresCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProdutosProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEstoqueProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentaçôesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFluxoCaixaMovimentacoes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLancamentoVendasMovimentacoes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEntradasSaidasMovimentacoes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDespesasMovimentacoes = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProdutosRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVendasRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMovimentacoesRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEntradasSaidasRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDespesasRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Img04 = new System.Windows.Forms.PictureBox();
            this.Img02 = new System.Windows.Forms.PictureBox();
            this.Img03 = new System.Windows.Forms.PictureBox();
            this.Img01 = new System.Windows.Forms.PictureBox();
            this.cargosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Img04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img01)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.produtosToolStripMenuItem,
            this.movimentaçôesToolStripMenuItem,
            this.relatóriosToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1490, 25);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFuncionariosCadastros,
            this.MenuClientesCadastros,
            this.cargosToolStripMenuItem,
            this.MenuUsuariosCadastros,
            this.MenuFornecedoresCadastros});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // MenuFuncionariosCadastros
            // 
            this.MenuFuncionariosCadastros.Name = "MenuFuncionariosCadastros";
            this.MenuFuncionariosCadastros.Size = new System.Drawing.Size(180, 22);
            this.MenuFuncionariosCadastros.Text = "Funcionários";
            this.MenuFuncionariosCadastros.Click += new System.EventHandler(this.MenuFuncionariosCadastros_Click);
            // 
            // MenuClientesCadastros
            // 
            this.MenuClientesCadastros.Name = "MenuClientesCadastros";
            this.MenuClientesCadastros.Size = new System.Drawing.Size(180, 22);
            this.MenuClientesCadastros.Text = "Clientes";
            // 
            // MenuUsuariosCadastros
            // 
            this.MenuUsuariosCadastros.Name = "MenuUsuariosCadastros";
            this.MenuUsuariosCadastros.Size = new System.Drawing.Size(180, 22);
            this.MenuUsuariosCadastros.Text = "Usuários";
            // 
            // MenuFornecedoresCadastros
            // 
            this.MenuFornecedoresCadastros.Name = "MenuFornecedoresCadastros";
            this.MenuFornecedoresCadastros.Size = new System.Drawing.Size(180, 22);
            this.MenuFornecedoresCadastros.Text = "Fornecedores";
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuProdutosProdutos,
            this.MenuEstoqueProdutos});
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(69, 21);
            this.produtosToolStripMenuItem.Text = "Produtos";
            // 
            // MenuProdutosProdutos
            // 
            this.MenuProdutosProdutos.Name = "MenuProdutosProdutos";
            this.MenuProdutosProdutos.Size = new System.Drawing.Size(125, 22);
            this.MenuProdutosProdutos.Text = "Produtos";
            // 
            // MenuEstoqueProdutos
            // 
            this.MenuEstoqueProdutos.Name = "MenuEstoqueProdutos";
            this.MenuEstoqueProdutos.Size = new System.Drawing.Size(125, 22);
            this.MenuEstoqueProdutos.Text = "Estoques";
            // 
            // movimentaçôesToolStripMenuItem
            // 
            this.movimentaçôesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFluxoCaixaMovimentacoes,
            this.MenuLancamentoVendasMovimentacoes,
            this.MenuEntradasSaidasMovimentacoes,
            this.MenuDespesasMovimentacoes});
            this.movimentaçôesToolStripMenuItem.Name = "movimentaçôesToolStripMenuItem";
            this.movimentaçôesToolStripMenuItem.Size = new System.Drawing.Size(106, 21);
            this.movimentaçôesToolStripMenuItem.Text = "Movimentaçôes";
            // 
            // MenuFluxoCaixaMovimentacoes
            // 
            this.MenuFluxoCaixaMovimentacoes.Name = "MenuFluxoCaixaMovimentacoes";
            this.MenuFluxoCaixaMovimentacoes.Size = new System.Drawing.Size(188, 22);
            this.MenuFluxoCaixaMovimentacoes.Text = "Fluxo Caixa";
            // 
            // MenuLancamentoVendasMovimentacoes
            // 
            this.MenuLancamentoVendasMovimentacoes.Name = "MenuLancamentoVendasMovimentacoes";
            this.MenuLancamentoVendasMovimentacoes.Size = new System.Drawing.Size(188, 22);
            this.MenuLancamentoVendasMovimentacoes.Text = "Lançamento Vendas";
            // 
            // MenuEntradasSaidasMovimentacoes
            // 
            this.MenuEntradasSaidasMovimentacoes.Name = "MenuEntradasSaidasMovimentacoes";
            this.MenuEntradasSaidasMovimentacoes.Size = new System.Drawing.Size(188, 22);
            this.MenuEntradasSaidasMovimentacoes.Text = "Entradas / Saidas";
            // 
            // MenuDespesasMovimentacoes
            // 
            this.MenuDespesasMovimentacoes.Name = "MenuDespesasMovimentacoes";
            this.MenuDespesasMovimentacoes.Size = new System.Drawing.Size(188, 22);
            this.MenuDespesasMovimentacoes.Text = "Despesas";
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuProdutosRelatorios,
            this.MenuVendasRelatorios,
            this.MenuMovimentacoesRelatorios,
            this.MenuEntradasSaidasRelatorios,
            this.MenuDespesasRelatorios});
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // MenuProdutosRelatorios
            // 
            this.MenuProdutosRelatorios.Name = "MenuProdutosRelatorios";
            this.MenuProdutosRelatorios.Size = new System.Drawing.Size(172, 22);
            this.MenuProdutosRelatorios.Text = "Produtos";
            // 
            // MenuVendasRelatorios
            // 
            this.MenuVendasRelatorios.Name = "MenuVendasRelatorios";
            this.MenuVendasRelatorios.Size = new System.Drawing.Size(172, 22);
            this.MenuVendasRelatorios.Text = "Vendas";
            // 
            // MenuMovimentacoesRelatorios
            // 
            this.MenuMovimentacoesRelatorios.Name = "MenuMovimentacoesRelatorios";
            this.MenuMovimentacoesRelatorios.Size = new System.Drawing.Size(172, 22);
            this.MenuMovimentacoesRelatorios.Text = "Movimentações";
            // 
            // MenuEntradasSaidasRelatorios
            // 
            this.MenuEntradasSaidasRelatorios.Name = "MenuEntradasSaidasRelatorios";
            this.MenuEntradasSaidasRelatorios.Size = new System.Drawing.Size(172, 22);
            this.MenuEntradasSaidasRelatorios.Text = "Entradas / Saidas";
            // 
            // MenuDespesasRelatorios
            // 
            this.MenuDespesasRelatorios.Name = "MenuDespesasRelatorios";
            this.MenuDespesasRelatorios.Size = new System.Drawing.Size(172, 22);
            this.MenuDespesasRelatorios.Text = "Despesas";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.sairToolStripMenuItem.Text = "Sair";
           
            // 
            // Img04
            // 
            this.Img04.Image = global::ServiceManager.Properties.Resources.wallet;
            this.Img04.Location = new System.Drawing.Point(859, 353);
            this.Img04.Name = "Img04";
            this.Img04.Size = new System.Drawing.Size(197, 153);
            this.Img04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Img04.TabIndex = 4;
            this.Img04.TabStop = false;
            // 
            // Img02
            // 
            this.Img02.Image = global::ServiceManager.Properties.Resources.dollar;
            this.Img02.Location = new System.Drawing.Point(859, 127);
            this.Img02.Name = "Img02";
            this.Img02.Size = new System.Drawing.Size(197, 153);
            this.Img02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Img02.TabIndex = 3;
            this.Img02.TabStop = false;
            // 
            // Img03
            // 
            this.Img03.Image = global::ServiceManager.Properties.Resources.expenses;
            this.Img03.Location = new System.Drawing.Point(510, 353);
            this.Img03.Name = "Img03";
            this.Img03.Size = new System.Drawing.Size(197, 153);
            this.Img03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Img03.TabIndex = 2;
            this.Img03.TabStop = false;
            // 
            // Img01
            // 
            this.Img01.ErrorImage = null;
            this.Img01.Image = global::ServiceManager.Properties.Resources.shopping_cart;
            this.Img01.InitialImage = null;
            this.Img01.Location = new System.Drawing.Point(510, 127);
            this.Img01.Name = "Img01";
            this.Img01.Size = new System.Drawing.Size(197, 153);
            this.Img01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Img01.TabIndex = 1;
            this.Img01.TabStop = false;
            // 
            // cargosToolStripMenuItem
            // 
            this.cargosToolStripMenuItem.Name = "cargosToolStripMenuItem";
            this.cargosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cargosToolStripMenuItem.Text = "Cargos";
            this.cargosToolStripMenuItem.Click += new System.EventHandler(this.cargosToolStripMenuItem_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1490, 804);
            this.Controls.Add(this.Img04);
            this.Controls.Add(this.Img02);
            this.Controls.Add(this.Img03);
            this.Controls.Add(this.Img01);
            this.Controls.Add(this.MainMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainFrm";
            this.Text = "Service Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Img04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img01)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimentaçôesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.PictureBox Img01;
        private System.Windows.Forms.PictureBox Img03;
        private System.Windows.Forms.PictureBox Img04;
        private System.Windows.Forms.PictureBox Img02;
        private System.Windows.Forms.ToolStripMenuItem MenuFuncionariosCadastros;
        private System.Windows.Forms.ToolStripMenuItem MenuClientesCadastros;
        private System.Windows.Forms.ToolStripMenuItem MenuUsuariosCadastros;
        private System.Windows.Forms.ToolStripMenuItem MenuFornecedoresCadastros;
        private System.Windows.Forms.ToolStripMenuItem MenuProdutosProdutos;
        private System.Windows.Forms.ToolStripMenuItem MenuEstoqueProdutos;
        private System.Windows.Forms.ToolStripMenuItem MenuFluxoCaixaMovimentacoes;
        private System.Windows.Forms.ToolStripMenuItem MenuLancamentoVendasMovimentacoes;
        private System.Windows.Forms.ToolStripMenuItem MenuEntradasSaidasMovimentacoes;
        private System.Windows.Forms.ToolStripMenuItem MenuDespesasMovimentacoes;
        private System.Windows.Forms.ToolStripMenuItem MenuProdutosRelatorios;
        private System.Windows.Forms.ToolStripMenuItem MenuVendasRelatorios;
        private System.Windows.Forms.ToolStripMenuItem MenuMovimentacoesRelatorios;
        private System.Windows.Forms.ToolStripMenuItem MenuEntradasSaidasRelatorios;
        private System.Windows.Forms.ToolStripMenuItem MenuDespesasRelatorios;
        private System.Windows.Forms.ToolStripMenuItem cargosToolStripMenuItem;
    }
}

