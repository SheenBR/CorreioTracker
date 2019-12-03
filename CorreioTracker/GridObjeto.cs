using System.Data;
using System.Windows.Forms;

namespace CorreioTracker
{
    public class GridObjeto
    {
        TabControl owner;
        TabPage page;
        public InformacaoObjeto objeto { get; private set; }
        DataGridView gridObjeto;
        DataTable gridData;

        public GridObjeto(TabControl owner, InformacaoObjeto objeto)
        {
            this.owner = owner;
            this.objeto = objeto;
            gridObjeto = new DataGridView();
            gridObjeto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            this.page = new TabPage();
            this.page.Text = objeto.codigo;

            gridData = new DataTable();

            // Colunas
            gridData.Columns.Add("ID"); ;
            gridData.Columns.Add("Data");
            gridData.Columns.Add("Local");
            gridData.Columns.Add("Descricao");
        }

        public void AtualizarObjeto(InformacaoObjeto objeto)
        {
            this.objeto = objeto;
            this.gridData.Rows.Clear();
            CriarDataTable();
        }

        void CriarDataTable()
        {
            int Counter = 1;
            foreach (var retorno in objeto.html)
            {
                gridData.Rows.Add(new object[] { Counter, retorno.Data.ToString(), retorno.Local, retorno.Descricao });
                Counter++;
            }
        }

        public void CriarPagina()
        {
            owner.TabPages.Add(this.page);

            CriarDataTable();

            // Add Grid
            gridObjeto.Dock = DockStyle.Fill;
            gridObjeto.DataSource = gridData;

            this.page.Controls.Add(gridObjeto);
        }
    }
}
