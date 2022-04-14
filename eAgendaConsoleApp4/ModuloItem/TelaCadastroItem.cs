using eAgendaConsoleApp4.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaConsoleApp4.Item
{
    public class TelaCadastroItem : TelaBase<RepositorioItem, Item>
    {
      
        
            private readonly RepositorioItem _repositorioItem;
            private readonly Notificador _notificador;


            public TelaCadastroItem(RepositorioItem repositoriodoItem, Notificador notificador)
                : base("Cadastro de item")
            {
                _repositorioItem = repositoriodoItem;
                _notificador = notificador;
            }

            public void Inserir()
            {
                MostrarTitulo("Cadastro de Item");

               Item novoitem = ObterItem();
                base.Inserir(novoitem);
            }

            public void Editar()
            {
                MostrarTitulo("EditandoItem");

                int id = ObterNumeroRegistro();
                base.Editar(ObterItem(), id);
            }

            public new void Excluir()
            {
                MostrarTitulo("ExcluindoItem");

                base.Excluir();

            }

            public bool VisualizarRegistros(string tipoVisualizacao)
            {
                if (tipoVisualizacao == "Tela")
                    MostrarTitulo("Visualização de Items");

                List<Item> itens = _repositorioItem.SelecionarTodos();

                if (itens.Count == 0)
                {
                    _notificador.ApresentarMensagem("Nenhum Item disponível.", Mensagem.Atencao);
                    return false;
                }

                foreach (Item funcionario in itens)
                    Console.WriteLine(funcionario.ToString());

                Console.ReadLine();

                return true;
            }

            private Item ObterItem()
            {
                Console.Write("Fale a descricao: ");
                string falarsobre = Console.ReadLine();

                

                return new Item(falarsobre);
            }

            
            
        
    }
}
