using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaConsoleApp4.Compartilhado
{
    public interface ITelaCadastros
    {
        void Inserir();
        void Editar();
        void Excluir();
        bool VisualizarRegistros(string tipoVisualizacao);


    }
}
