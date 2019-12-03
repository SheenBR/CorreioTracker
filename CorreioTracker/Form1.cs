using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Web;

namespace CorreioTracker
{
    public partial class Form1 : Form
    {
        ManualResetEvent working = new ManualResetEvent(false);
        BackgroundWorker bgWorker = new BackgroundWorker();
        List<InformacaoObjeto> lstLastInfo = new List<InformacaoObjeto>();
        NotifyIcon notifyIcon = new NotifyIcon();

        int Counter = 1;
        int Total = 0;
        bool tip = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
            bgWorker.DoWork += BgWorker_DoWork;
            notifyIcon.MouseClick += NotifyIcon_MouseClick;
            notifyIcon.MouseDoubleClick += NotifyIcon_MouseClick;
            notifyIcon.Icon = this.Icon;

            GridController.Iniciar(ref tblGrids);
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            notifyIcon.Visible = false;            WindowState = FormWindowState.Normal;
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
           
            foreach (var codigo in (string[])e.Argument)
            {
                this.Invoke((MethodInvoker)delegate {
                    lblProgresso.Text = $"{Counter}/{Total}";
                    if (lblProgresso.Visible == false) lblProgresso.Visible = true;

                    webBrowser1.Navigate($"http://sro.micropost.com.br/consulta.php?objetos={codigo}");
                });
                
                working.WaitOne();
                working.Reset();
            }

            this.Invoke(new Action(AtualizaLista));
        }



        private void button1_Click(object sender, EventArgs e)
        {
            pbTrabalhando.Visible = true;

            var codigos = rtbCodigos.Text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Total = codigos.Length;

            bgWorker.RunWorkerAsync(codigos);
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var resultTable = webBrowser1.Document.GetElementsByTagName("table")[0];

            var rows = resultTable.GetElementsByTagName("tr");
            int count = 1;
            var codigo = HttpUtility.ParseQueryString(webBrowser1.Url.Query).Get("objetos");

            var temp = new InformacaoObjeto(codigo);

            for (var i = 1; i < rows.Count; i++)
            {
                var tds = rows[i].GetElementsByTagName("td");
                if (tds.Count >= 3)
                {
                    var data = DateTime.Parse(tds[0].InnerText);
                    var local = tds[1].InnerText;
                    var descricao = tds[2].InnerText;

                    if(temp.dataUltimaAtualizacao == null)
                    {
                        temp.AtualizaUltimosValores(data, descricao);
                    }

                    temp.AdicionarRetorno(new RetornoHTML(data, local, descricao));

                    if (i == 1)
                    {
                        lstLastInfo.Add(temp);
                    }
                    count++;
                }
            }

            GridController.AdicionarInformacaoObjeto(temp);
            
            Counter++;
            working.Set();
        }

        private void AtualizaLista()
        {
            GridController.CriarDataGrids();

            pbTrabalhando.Visible = false;
            lblProgresso.Visible = false;

            lstInformacoes.Items.Clear();
            foreach(var p in GridController.GetObjetos())
            {
                lstInformacoes.Items.Add($"Codigo {p.codigo} - {p.dataUltimaAtualizacao.ToString()} - {p.ultimaAtualizacao}");
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
                if (tip)
                {
                    notifyIcon.ShowBalloonTip(2000, "Atenção", "Rodando em segundo plano!", ToolTipIcon.Info);
                    tip = false;
                }
            }
        }
    }
}