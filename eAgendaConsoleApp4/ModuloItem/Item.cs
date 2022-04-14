using eAgendaConsoleApp4.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaConsoleApp4.Item
{
    public class Item : EntidadeBase
    {
        public bool terminado;
        public string falarsobre;

        public Item(string descricao)
        {
            this.falarsobre = falarsobre;
            terminado = false;
        }
        public override string ToString()
        {
            return $"Id : {id}\n" +
                $"Descrição : {falarsobre}\n" +
                $"concluido : {terminado}";
        }
    }



}

