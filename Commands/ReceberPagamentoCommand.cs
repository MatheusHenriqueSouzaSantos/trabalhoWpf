using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using umfg.venda.app.Abstracts;
using umfg.venda.app.ViewModels;

namespace umfg.venda.app.Commands
{
    internal class ReceberPagamento : AbstractCommand
    {
        public override void Execute(object? parameter)
        {
            ReceberPedidoViewModel vm= (ReceberPedidoViewModel)parameter;

            if (vm.NomeCartao == null)
            {
                MessageBox.Show("O Campo nome no cartão é obrigatório!");
                return;
            }
            if(vm.NumeroCartao== null)
            {
                MessageBox.Show("O Campo Numero no cartão é obrigatório!");
                return;
            }
            if (!VerificarSeCartaoEhValido(vm.NumeroCartao))
            {
                MessageBox.Show("Numero de cartão Inválido");
                return;
            }
            if (vm.DataValidade == null)
            {
                MessageBox.Show("Data de validade não pode ser null");
                return;
            }
            if (!vm.CVV.All(char.IsDigit))
            {
                MessageBox.Show("O Cvv deve apenas numeros");
                return;
            }
            if (vm.CVV.Length != 3)
            {
                MessageBox.Show("O Cvv deve conter 3 numeros");
                return;
            }
            if (vm.DataValidade < DateTime.Today)
            {
                MessageBox.Show("A Data de Validade do cartão deve ser maior ou igual a atual");
                return;
            }
            MessageBox.Show("Pedido Finalizado com sucesso");
            new MainWindow().Show();
        }



        private bool VerificarSeCartaoEhValido(string numeroCartao)
        {
            if (!numeroCartao.All(char.IsDigit))
            {
                MessageBox.Show("O Numero do cartão deve conter somente numeros");
                return false;
            }

            if (numeroCartao.Length!=16)
            {
                MessageBox.Show("O Numero do cartão deve conter 16 numeros");
                return false;
            }

            int soma = 0;
            bool numeroADobrarValor=false;

            for(int i = numeroCartao.Length - 1; i >= 0; i--)
            {
                int numero = int.Parse(numeroCartao[i].ToString());

                if (numeroADobrarValor)
                {
                    numero = numero * 2;
                    if (numero > 9)
                    {
                        numero = numero - 9;
                    }
                }
                soma += numero;
                numeroADobrarValor = !numeroADobrarValor;
            }
            return soma%10==0;
        }
    }
}
