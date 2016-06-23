using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Banco
{
    public partial class Form1 : Form
    {
        private Conta c;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            this.c = new Conta();
            c.Numero = 1;

            Cliente cliente = new Cliente("Jão");
            c.Titular = cliente;

            txtTitular.Text = c.Titular.Nome;
            txtNumero.Text = Convert.ToString(c.Numero);
            txtSaldo.Text = Convert.ToString(c.Saldo);
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            c.Depositar(Convert.ToDouble(txtValor.Text));  // converte para string             
            txtSaldo.Text = c.Saldo.ToString(); // outra forma de converter para string
            MessageBox.Show("Operação realizada com sucesso");
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            if (c.Sacar(Convert.ToDouble(txtValor.Text)) == true)
            { 
                txtSaldo.Text = c.Saldo.ToString();
            }            
        }
    }
}
