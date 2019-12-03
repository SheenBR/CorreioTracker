using System.Collections.Generic;
using System.Windows.Forms;

namespace CorreioTracker
{


    public static class GridController
    {
        static List<InformacaoObjeto> objetos = null;
        static List<GridObjeto> _grids = new List<GridObjeto>();

        static TabControl _owner;

        public static void AdicionarInformacaoObjeto(InformacaoObjeto objeto)
        {
            if (objetos == null)
                objetos = new List<InformacaoObjeto>();

            // Verifica se o objeto ja existe. Caso exista pode ser um objeto mais atualizado.

            if (objetos.Contains(objeto))
            {
                var objIndex = objetos.IndexOf(objeto);
                objetos[objIndex] = objeto;
            }
            else
            {
                objetos.Add(objeto);
            }
        }

        public static void Iniciar(ref TabControl sowner)
        {
            _owner = sowner;
        }

        public static List<InformacaoObjeto> GetObjetos()
        {
            return objetos;
        }

        static bool ExisteGrid(string codigo)
        {
            foreach(var grid in _grids)
            {
                if (grid.objeto.codigo == codigo)
                    return true;
            }
            return false;
        }
        static void AtualizaGrid(string codigo, InformacaoObjeto obj)
        {
            foreach (var grid in _grids)
            {
                if (grid.objeto.codigo == codigo)
                {
                    grid.AtualizarObjeto(obj);
                }
            }
        }

        public static void CriarDataGrids()
        {
            foreach (var obj in objetos)
            {
                // verifica se a grid ja existe.
                if (ExisteGrid(obj.codigo))
                {
                    AtualizaGrid(obj.codigo, obj);
                }
                else
                {
                    _grids.Add(new GridObjeto(_owner, obj));
                    _grids[_grids.Count - 1].CriarPagina();
                } }
        }
    }
}
