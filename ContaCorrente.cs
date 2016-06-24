using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco
{
    class ContaCorrente:Conta
    {
        const double taxaSaqueCorrente = 0.05;
        const double taxaDepositoCorrente = 0.10;

        public override void Sacar(double valorOperacao)
        {
            // Permite invocar o método sacar da classe base/pai mas com um comportamento levemente modificado
            base.Sacar(valorOperacao + taxaSaqueCorrente);
        }

        public override void Depositar(double valorOperacao)
        {
            base.Depositar(valorOperacao - taxaDepositoCorrente);
        }
    }
}
