using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using umfg.venda.app.Abstracts;
using umfg.venda.app.Commands;
using umfg.venda.app.Interfaces;

namespace umfg.venda.app.ViewModels
{
    internal sealed class MainWindowViewModel : AbstractViewModel, IObserver
    {
        private UserControl _userControl;

        public UserControl UserControl
        {
            get => _userControl;
            set => SetField(ref _userControl, value);
        }

        public ListarProdutosCommand ListarProdutos { get; private set; } = new();

        public MainWindowViewModel() : base("UMFG - Tela Pricipal")
        {
            Add(this);
        }

        public void Update(ISubject subject)
        {
            if (subject is ListarProdutosViewModel)
                UserControl = (subject as ListarProdutosViewModel).UserControl;


            //verificar condição pois a uc de receber pedido pode ser tanto receber pedido ou pode ser o home como verificar o tipo do uc e mandar
            if (subject is ReceberPedidoViewModel)
                if((subject as ReceberPedidoViewModel).UserControl==)
                UserControl = (subject as ReceberPedidoViewModel).UserControl;

        }
    }
}
