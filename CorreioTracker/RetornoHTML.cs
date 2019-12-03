using System;

namespace CorreioTracker
{
    public struct RetornoHTML
    {

        public DateTime Data { get; private set; }
        public string Local { get; private set; }
        public string Descricao { get; private set; }

        public RetornoHTML(DateTime data, string local, string descricao)
        {
            this.Data = data;
            this.Local = local;
            this.Descricao = descricao;
        }
    }
}
