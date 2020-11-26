using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Entity
{
    class Pagamento
    {
        public int IdVenda { get; set; }
        public decimal Debito { get; private set; }
        public decimal Credito { get; private set; }
        public decimal Dinheiro { get; private set; }
        public decimal Crediario { get; private set; }

        public Pagamento(decimal debito = 0, decimal credito= 0, decimal dinheiro=0, decimal crediario=0)
        {
            Debito = debito;
            Credito = credito;
            Dinheiro = dinheiro;
            Crediario = crediario;
        }
    }
}
