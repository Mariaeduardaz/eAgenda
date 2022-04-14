using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaConsoleApp4.Compartilhado
{
    public class Notificador
    {
        public void ApresentarMensagem(string mensagem, Mensagem tipoMensagem)
        {
            switch (tipoMensagem)
            {
                case Mensagem.Sucesso:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case Mensagem.Atencao:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                case Mensagem.Erro:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
