namespace CorreioTracker
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.pbTrabalhando = new System.Windows.Forms.ProgressBar();
            this.rtbCodigos = new System.Windows.Forms.RichTextBox();
            this.lstInformacoes = new System.Windows.Forms.ListBox();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.tblGrids = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Rastrear";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(716, 13);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(34, 25);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.Visible = false;
            // 
            // pbTrabalhando
            // 
            this.pbTrabalhando.Location = new System.Drawing.Point(13, 363);
            this.pbTrabalhando.MarqueeAnimationSpeed = 25;
            this.pbTrabalhando.Name = "pbTrabalhando";
            this.pbTrabalhando.Size = new System.Drawing.Size(138, 13);
            this.pbTrabalhando.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbTrabalhando.TabIndex = 5;
            this.pbTrabalhando.Visible = false;
            // 
            // rtbCodigos
            // 
            this.rtbCodigos.Location = new System.Drawing.Point(13, 43);
            this.rtbCodigos.Name = "rtbCodigos";
            this.rtbCodigos.Size = new System.Drawing.Size(237, 130);
            this.rtbCodigos.TabIndex = 6;
            this.rtbCodigos.Text = "PX455343142BR\nPX473731435BR";
            // 
            // lstInformacoes
            // 
            this.lstInformacoes.FormattingEnabled = true;
            this.lstInformacoes.Location = new System.Drawing.Point(257, 43);
            this.lstInformacoes.Name = "lstInformacoes";
            this.lstInformacoes.Size = new System.Drawing.Size(503, 134);
            this.lstInformacoes.TabIndex = 7;
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.Location = new System.Drawing.Point(158, 362);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(0, 13);
            this.lblProgresso.TabIndex = 8;
            this.lblProgresso.Visible = false;
            // 
            // tblGrids
            // 
            this.tblGrids.Location = new System.Drawing.Point(12, 179);
            this.tblGrids.Name = "tblGrids";
            this.tblGrids.SelectedIndex = 0;
            this.tblGrids.Size = new System.Drawing.Size(748, 178);
            this.tblGrids.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 382);
            this.Controls.Add(this.tblGrids);
            this.Controls.Add(this.lblProgresso);
            this.Controls.Add(this.lstInformacoes);
            this.Controls.Add(this.rtbCodigos);
            this.Controls.Add(this.pbTrabalhando);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rastreador";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ProgressBar pbTrabalhando;
        private System.Windows.Forms.RichTextBox rtbCodigos;
        private System.Windows.Forms.ListBox lstInformacoes;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.TabControl tblGrids;
    }
}

