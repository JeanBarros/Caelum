using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exercicio01
{
    public partial class Form1 : Form
    {
        Conta contaVictor = new Conta(); 
        
        public Form1()
        {
            InitializeComponent();

            contaVictor.titular = "Victor Navowsky";
            contaVictor.numero = 001;
            contaVictor.saldo = 100.0;

            AtualizarDados();

            Conta mauricio = new Conta();
            mauricio.saldo = 2000.0;
            mauricio.titular = "Zé";

            Conta copia = mauricio;
            copia.saldo = 3000.0;

            MessageBox.Show("mauricio = " + mauricio.saldo);
            MessageBox.Show("copia = " + copia.saldo);
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            if (txtDeposito.Text != "")
                contaVictor.Depositar(Convert.ToDouble(txtDeposito.Text));
            else
                MessageBox.Show("Informe o valor que deseja depositar");
            
            AtualizarDados();
        }

        private void btnSaque_Click(object sender, EventArgs e)
        {
            if (txtSaque.Text != "") 
                contaVictor.Sacar(Convert.ToDouble(txtSaque.Text));
            else
                MessageBox.Show("Informe o valor que deseja sacar");

            AtualizarDados();
        }

        private void AtualizarDados()
        {
            txtDeposito.Clear();
            txtSaque.Clear();
            lbxDados.Items.Clear();

            // preenche o listBox com os valores dos atributos
            lbxDados.Items.Add("Número da conta: " + contaVictor.numero);
            lbxDados.Items.Add("Nome do cliente: " + contaVictor.titular);
            lbxDados.Items.Add("Saldo: " + contaVictor.saldo);
        }        
    }
}
