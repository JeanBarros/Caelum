using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Banco
{
    public class Conta
    {
        public int Numero { get; set; }
        public double Saldo { get; private set; }

        public Cliente Titular { get; set; }

        public void Depositar(double valorOperacao)
        {
            this.Saldo += valorOperacao;    
        }

        public bool Sacar(double valorOperacao)
        {
            var resultado = false;

            if (this.Saldo > 0 && this.Saldo >= valorOperacao)
            {
                this.Saldo -= valorOperacao;
                MessageBox.Show("Saque no valor de R$ " + valorOperacao + " realizado com sucesso.");

                resultado = true;
            }
            else
                MessageBox.Show("Saldo insuficiente");

            return resultado;
        }
    }
}
