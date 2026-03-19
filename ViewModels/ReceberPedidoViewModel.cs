using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using umfg.venda.app.Abstracts;
using umfg.venda.app.Commands;
using umfg.venda.app.Interfaces;
using umfg.venda.app.Models;
using umfg.venda.app.UserControls;

namespace umfg.venda.app.ViewModels
{
    internal sealed class ReceberPedidoViewModel : AbstractViewModel
    {
        public List<int> OpcoesDeMes { get; private set; }=Enumerable.Range(1,12).ToList();
        public List<int> OpcoesDeAno { get; private set; } = Enumerable.Range(DateTime.Now.Year, 50).ToList();    

        private PedidoModel _pedido = new();
        private string _numeroCartao;
        private string _cvv ;
        private int _mesSelecionado;
        private int _anoSelecionado;
        private DateTime _dataValidade = DateTime.Now;
        private string _nomeCartao;

        public bool IsPedidoRecebido { get; private set; }=false;

        public int MesSelecionado
        {
            get=> _mesSelecionado;
            set=>SetField(ref _mesSelecionado, value);
        }

        public int AnoSelecionado
        {
            get => _anoSelecionado;
            set => SetField(ref _anoSelecionado, value);
        }


        public string NumeroCartao 
        {
            get => _numeroCartao;
            set => SetField(ref _numeroCartao, value);
        }

        public string CVV
        {
            get => _cvv;
            set => SetField(ref _cvv, value);
        }

        public DateTime DataValidade
        {
            get => _dataValidade;
            set => SetField(ref _dataValidade, value);
        }

        public string NomeCartao
        {
            get => _nomeCartao;
            set => SetField(ref _nomeCartao, value);
        }

        public PedidoModel Pedido
        {
            get => _pedido;
            set => SetField(ref _pedido, value);
        }

        public FinalizarPagamentoCommand FinalizarPagamento { get; set; } = new();
        public ReceberPedidoViewModel(UserControl userControl, IObserver observer, PedidoModel pedido) 
            : base("Receber Pedido")
        {
            UserControl = userControl ?? throw new ArgumentNullException(nameof(userControl));
            MainWindow = observer ?? throw new ArgumentNullException(nameof(observer));
            Pedido = pedido ?? throw new ArgumentNullException(nameof(pedido));
            int mesAtual = DateTime.Now.Month;
            MesSelecionado = OpcoesDeMes[mesAtual-1];
            AnoSelecionado = OpcoesDeAno[0];
            Add(observer);
        }

        public void voltarTelaPrincipal()
        {
            IsPedidoRecebido=true;
            Notify();
        }
    }
}
