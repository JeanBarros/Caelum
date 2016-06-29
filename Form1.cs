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
        // Array de contas
        private Conta[] contas;

        // Armazena o número de contas que já foram cadastradas
        private int numeroDeContas;

        // Armazena o índice da conta selecionada no ComboBox de contas
        int contaSelecionada = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // criando o array para guardar as contas
            contas = new Conta[3];

            // Nova instância de Conta.
            this.contas[0] = new Conta();
            this.contas[0].Titular = new Cliente("Jão");
            this.contas[0].Numero = 1;
            
            // Nova instância de Conta Poupança
            this.contas[1] = new ContaPoupanca();
            this.contas[1].Titular = new Cliente("Zé");
            this.contas[1].Numero = 2;
            
            // Nova instância de Conta Corrente
            this.contas[2] = new ContaCorrente();
            this.contas[2].Titular = new Cliente("Ana");
            this.contas[2].Numero = 3;

            // Popula ComboBox com nome dos titulares de cada conta
            foreach (Conta conta in contas)
            {
                cbxContas.Items.Add(conta.Titular.Nome);
            }
        }

        /// <summary>
        /// método utilizado para depositar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepositar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtValor.Text))
                MessageBox.Show("Informe um valor");
            else
            {
                if (rdbCorrente.Checked == true)
                {
                    contas[contaSelecionada].Depositar(Convert.ToDouble(txtValor.Text));  // converte para string             
                    txtSaldo.Text = contas[contaSelecionada].Saldo.ToString(); // outra forma de converter para string
                    MessageBox.Show("Operação realizada com sucesso");
                    txtValor.Clear();
                }

                if (rdbPoupanca.Checked == true)
                {
                    // chama o método escrito na classe pai "Conta"
                    contas[contaSelecionada].Depositar(Convert.ToDouble(txtValor.Text));  // converte para string             
                    txtSaldo.Text = contas[contaSelecionada].Saldo.ToString(); // outra forma de converter para string
                    MessageBox.Show("Operação realizada com sucesso");
                    txtValor.Clear();
                }

                if (rdbPoupanca.Checked == false && rdbCorrente.Checked == false)
                    MessageBox.Show("Selecione o tipo da conta");
            }
        }

        /// <summary>
        /// Método utilizado para sacar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSacar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtValor.Text))
                MessageBox.Show("Informe um valor");
            else
            {
                if (rdbPoupanca.Checked == true)
                {
                    // chama o método "Sacar" escrito na classe filha "conta"
                    contas[contaSelecionada].Sacar(Convert.ToDouble(txtValor.Text));

                    if (contas[contaSelecionada].resultado)
                    {
                        txtSaldo.Text = contas[contaSelecionada].Saldo.ToString();
                        txtValor.Clear();
                    }
                }

                if (rdbCorrente.Checked == true)
                {
                    contas[contaSelecionada].Sacar(Convert.ToDouble(txtValor.Text));

                    if (contas[contaSelecionada].resultado)
                    {
                        txtSaldo.Text = contas[contaSelecionada].Saldo.ToString();
                        txtValor.Clear();
                    }
                }

                if (rdbPoupanca.Checked == false && rdbCorrente.Checked == false)
                    MessageBox.Show("Selecione o tipo da conta");
            }
        }        

        private void cbxContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cbxContas.SelectedIndex;
            Conta selecionada = contas[indice];
            txtTitular.Text = selecionada.Titular.Nome;
            txtSaldo.Text = Convert.ToString(selecionada.Saldo);
            txtNumero.Text = Convert.ToString(selecionada.Numero);

            contaSelecionada = indice;
        }

        /// <summary>
        /// Método utilizado para criar uma conta nova
        /// </summary>
        /// <param name="conta"></param>
        public void AdicionarConta(Conta conta)
        {
            this.contas[this.numeroDeContas] = conta;
            this.numeroDeContas++;
            cbxContas.Items.Add(conta.Titular.Nome);
        }

        private void btnNovaConta_Click(object sender, EventArgs e)
        {
            // this representa a instância de Form1 que está sendo utilizada pelo Windows Form
            FormCadastroConta formularioDeCadastro = new FormCadastroConta(this);

            // Para mostrar o formulário, utilizar o método ShowDialog do FormCadastroConta
            formularioDeCadastro.ShowDialog();
        }
    }
}

// Messagem de erro: Object reference not set to an instance of an object.
// Referência de objeto não definida > para uma instância de um objeto.
      // ClasseQualquer variavelQualquer = new ClasseQualquer();

// Siginifica que: a variável/objeto "variavelQualquer" ainda não foi criada como uma instância da classe "ClasseQualquer".
// O objeto ainda não existe.