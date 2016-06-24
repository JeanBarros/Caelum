using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Banco
{
    // Classe Conta Poupança herdando da classe Conta
    public class ContaPoupanca : Conta
    {
        const double taxtaSaquePoupanca = 0.10;
        
        public override bool Sacar(double valorOperacao)
        {
            // Permite invocar o método sacar da classe base/pai mas com um comportamento levemente modificado
            base.Sacar(valorOperacao + taxtaSaquePoupanca);

            // A variavél "resultado" está na classe pai
            return resultado;
        }
    }
}
