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
        private Conta contaCorrente;
        private ContaPoupanca contaPoupanca;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Instancia uma nova Conta Corrente
            this.contaCorrente = new Conta();
            contaCorrente.Numero = 1;

            Cliente cliente = new Cliente("Jão");
            contaCorrente.Titular = cliente;

            txtTitular.Text = contaCorrente.Titular.Nome;
            txtNumero.Text = Convert.ToString(contaCorrente.Numero);
            txtSaldo.Text = Convert.ToString(contaCorrente.Saldo);

            // Instancia uma nova Conta Poupança
            this.contaPoupanca = new ContaPoupanca();
            contaPoupanca.Numero = 1;

            Cliente clientePop = new Cliente("Maria");
            contaPoupanca.Titular = clientePop;

            txtTitular.Text = contaPoupanca.Titular.Nome;
            txtNumero.Text = Convert.ToString(contaPoupanca.Numero);
            txtSaldo.Text = Convert.ToString(contaPoupanca.Saldo);
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            if (rdbCorrente.Checked == true)
            {
                contaCorrente.Depositar(Convert.ToDouble(txtValor.Text));  // converte para string             
                txtSaldo.Text = contaCorrente.Saldo.ToString(); // outra forma de converter para string
                MessageBox.Show("Operação realizada com sucesso");
            }

            if (rdbPoupanca.Checked == true)
            {
                // chama o método escrito na classe pai "Conta"
                contaPoupanca.Depositar(Convert.ToDouble(txtValor.Text));  // converte para string             
                txtSaldo.Text = contaPoupanca.Saldo.ToString(); // outra forma de converter para string
                MessageBox.Show("Operação realizada com sucesso");
            }

            if (rdbPoupanca.Checked == false && rdbCorrente.Checked == false)
                MessageBox.Show("Selecione o tipo da conta");
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            if (rdbPoupanca.Checked == true)
            {
                // chama o método "Sacar" escrito na classe filha "ContaPoupanca"
                contaPoupanca.Sacar(Convert.ToDouble(txtValor.Text));

                if (contaPoupanca.resultado)
                txtSaldo.Text = contaPoupanca.Saldo.ToString();
            }

            if (rdbCorrente.Checked == true)
            {
                contaCorrente.Sacar(Convert.ToDouble(txtValor.Text));
                
                if(contaCorrente.resultado)
                txtSaldo.Text = contaCorrente.Saldo.ToString();
            }
            
            if (rdbPoupanca.Checked == false && rdbCorrente.Checked == false)
                MessageBox.Show("Selecione o tipo da conta");
        }
    }
}

// Messagem de erro: Object reference not set to an instance of an object.
// Referência de objeto não definida > para uma instância de um objeto.
      // ClasseQualquer variavelQualquer = new ClasseQualquer();

// Siginifica que: a variável/objeto "variavelQualquer" ainda não foi criada como uma instância da classe "ClasseQualquer".
// O objeto ainda não existe.