using System;
using System.Collections.Generic;

namespace CorreioTracker
{
    public struct InformacaoObjeto
    {
        public string codigo { get; private set; }
        public string ultimaAtualizacao { get; private set; }
        public DateTime? dataUltimaAtualizacao { get; private set; }

        public List<RetornoHTML> html { get; private set; }

        public InformacaoObjeto(string codigo)
        {
            this.codigo = codigo;

            this.ultimaAtualizacao = "";
            this.dataUltimaAtualizacao = null;

            this.html = new List<RetornoHTML>();
        }

        public void AtualizaUltimosValores(DateTime data, string desc)
        {
            this.ultimaAtualizacao = desc;
            this.dataUltimaAtualizacao = data;
        }

        public void AdicionarRetorno(RetornoHTML value)
        {
            this.html.Add(value);
        }
    }
}
