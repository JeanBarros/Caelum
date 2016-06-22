using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exercicio01
{
    class Conta
    {
        public double saldo;
        public string titular;
        public int numero;

        /// <summary>
        /// Deposita o valor informado no parâmetro no objeto "conta" que executa o método.
        /// </summary>
        /// <param name="valor"></param>
        public void Depositar(double valor)
        {
            this.saldo += valor;
        }

        /// <summary>
        /// Saca o valor informado no parâmetro no objeto "conta" que executa o método.
        /// </summary>
        /// <param name="valor"></param>
        public void Sacar(double valorSaque)
        {
            if (this.saldo > 0 && this.saldo >= valorSaque)
            {
                this.saldo -= valorSaque;
                MessageBox.Show("Saque no valor de R$ " + valorSaque + " realizado com sucesso.");
            }
            else
                MessageBox.Show("Saldo insuficiente");
        }
    }
}
