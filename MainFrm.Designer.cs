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
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentaçôesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Img04 = new System.Windows.Forms.PictureBox();
            this.Img02 = new System.Windows.Forms.PictureBox();
            this.Img03 = new System.Windows.Forms.PictureBox();
            this.Img01 = new System.Windows.Forms.PictureBox();
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
            this.MainMenu.Size = new System.Drawing.Size(1067, 25);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(69, 21);
            this.produtosToolStripMenuItem.Text = "Produtos";
            // 
            // movimentaçôesToolStripMenuItem
            // 
            this.movimentaçôesToolStripMenuItem.Name = "movimentaçôesToolStripMenuItem";
            this.movimentaçôesToolStripMenuItem.Size = new System.Drawing.Size(106, 21);
            this.movimentaçôesToolStripMenuItem.Text = "Movimentaçôes";
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
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
            this.Img04.Location = new System.Drawing.Point(229, 284);
            this.Img04.Name = "Img04";
            this.Img04.Size = new System.Drawing.Size(197, 153);
            this.Img04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Img04.TabIndex = 4;
            this.Img04.TabStop = false;
            // 
            // Img02
            // 
            this.Img02.Image = global::ServiceManager.Properties.Resources.dollar;
            this.Img02.Location = new System.Drawing.Point(229, 111);
            this.Img02.Name = "Img02";
            this.Img02.Size = new System.Drawing.Size(197, 153);
            this.Img02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Img02.TabIndex = 3;
            this.Img02.TabStop = false;
            // 
            // Img03
            // 
            this.Img03.Image = global::ServiceManager.Properties.Resources.expenses;
            this.Img03.Location = new System.Drawing.Point(12, 284);
            this.Img03.Name = "Img03";
            this.Img03.Size = new System.Drawing.Size(197, 153);
            this.Img03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Img03.TabIndex = 2;
            this.Img03.TabStop = false;
            // 
            // Img01
            // 
            this.Img01.Image = global::ServiceManager.Properties.Resources.acquisition;
            this.Img01.Location = new System.Drawing.Point(12, 111);
            this.Img01.Name = "Img01";
            this.Img01.Size = new System.Drawing.Size(197, 153);
            this.Img01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Img01.TabIndex = 1;
            this.Img01.TabStop = false;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
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
    }
}

