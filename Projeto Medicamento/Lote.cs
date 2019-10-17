using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Medicamento
{
    public class Lote
    {
        public int id;
        public int qtd;
        DateTime venc;

        public Lote()
        {
            id = 0;
            qtd = 0;
        }

        public int quantidade()
        {
            return qtd;
        }

        public Lote(int id, int qtd, DateTime venc)
        {
            this.id = id;
            this.qtd = qtd;
            this.venc = venc;
        }

        public string toString()
        {
            return ("\n" + id + " - " + qtd + " - " + venc.ToShortDateString());
        }
    }
}
