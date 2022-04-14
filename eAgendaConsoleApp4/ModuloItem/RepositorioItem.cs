using eAgendaConsoleApp4.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaConsoleApp4.Item
{
    public class RepositorioItem : RepositorioBase<Item>
    {
        public bool Concluir(int id)
        {
            if (registros.Find(x => x.id == id) == default)
                return false;
            else
            {
                registros.Find(x => x.id == id).terminado = true;
                return true;
            }
        }






    }
}
