using eAgendaConsoleApp4.Compartilhado;
using eAgendaConsoleApp4.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaConsoleApp4.Tarefas
{
    
    
        public class RepositorioTarefa : RepositorioBase<Tarefa>
        {

            public void AtualizarPercentual(int index)
            {
                int contador = 0;
                foreach (var item in registros[index].Items)
                {
                    if (item.concluido)
                        contador++;
                }
                registros[index].porcentualConclusao = (double)contador / (double)registros[index].Items.Count;
            }

            internal bool AtualizarItems(int numeroId, List<Item> items)
            {
                int index = registros.FindIndex(x => x.id == numeroId);

                if (index == -1)
                    return false;
                registros[index].Items = items;
                AtualizarPercentual(index);

                return true;
            }

            public TelaCadastroItem PegarTela(int id)
            {
                return registros.Find(x => x.id == id)._telaCadastroItem;
            }

            public override bool Excluir(int id)
            {
                int index = registros.FindIndex(x => x.id == id);

                if (index == -1 || registros[index].porcentualConclusao != 1)
                    return false;
                registros.RemoveAt(index);
                return true;
            }
            public void Ordenar()
            {
                registros.Sort();
            }
            public override bool Editar(int numeroId, Tarefa entidadeNova)
            {

                int index = registros.FindIndex(x => x.id == numeroId);

                if (index == -1)
                    return false;
                entidadeNova.id = registros[index].id;
                entidadeNova.DataFim = registros[index].DataFim;
                registros[index] = entidadeNova;
                return true;
            }
        



    }
}

