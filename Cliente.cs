using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco
{
    public class Cliente
    {
        public Cliente(string nomeCliente)
        {
            this.Nome = nomeCliente;
        }

        public string Nome { get; set; }
    }
}
