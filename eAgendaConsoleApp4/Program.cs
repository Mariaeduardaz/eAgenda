using eAgendaConsoleApp4.Compartilhado;
using eAgendaConsoleApp4.Compromisso;
using eAgendaConsoleApp4.Tarefas;
using System;

namespace eAgendaConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            internal class Program
        {
            static void Main(string[] args)
            {
                Notificador notificador = new Notificador();
                TelaMenu menuPrincipal = new TelaMenu(notificador);

                while (true)
                {
                    TelaBase telaSelecionada = menuPrincipal.ObterTela();

                    if (telaSelecionada is null)
                        return;

                    string opcaoSelecionada = telaSelecionada.MostrarOpcoes();

                    if (telaSelecionada is ItelaCadastro)
                    {
                        ItelaCadastro telaCadastravel = (ItelaCadastro)telaSelecionada;

                        if (opcaoSelecionada == "1")
                            telaCadastravel.Inserir();

                        else if (opcaoSelecionada == "2")
                            telaCadastravel.Editar();

                        else if (opcaoSelecionada == "3")
                            telaCadastravel.Excluir();


                        else if (opcaoSelecionada == "4")
                            telaCadastravel.VisualizarRegistros("Tela");
                    }
                    else if (telaSelecionada is TelaCadastroTarefa)
                        GerenciarCadastroTarefa(telaSelecionada, opcaoSelecionada);
                    else if (telaSelecionada is TelaCadastroCompromisso)
                        GerenciarCadastroCompromisso(telaSelecionada, opcaoSelecionada);
                }
            }

            private static void GerenciarCadastroTarefa(TelaBase telaSelecionada, string opcaoSelecionada)
            {
                TelaCadastroTarefa telaCadastroTarefa = telaSelecionada as TelaCadastroTarefas;

                if (telaCadastroTarefa is null)
                    return;

                if (opcaoSelecionada == "1")
                    telaCadastroTarefa.Inserir();

                else if (opcaoSelecionada == "2")
                    telaCadastroTarefa.Editar();

                else if (opcaoSelecionada == "3")
                    telaCadastroTarefa.Excluir();

                else if (opcaoSelecionada == "4")
                    telaCadastroTarefa.VisualizarRegistros("Tela");

                else if (opcaoSelecionada == "5")
                    telaCadastroTarefa.AlterarStatusItens();

             

            private static void GerenciarCadastroCompromisso(TelaBase telaSelecionada, string opcaoSelecionada)
            {
                TelaCadastroCompromisso telaCadastroCompromisso = telaSelecionada as TelaCadastroCompromisso;

                if (telaCadastroCompromisso is null)
                    return;

                if (opcaoSelecionada == "1")
                    telaCadastroCompromisso.Inserir();

                else if (opcaoSelecionada == "2")
                    telaCadastroCompromisso.Editar();

                else if (opcaoSelecionada == "3")
                    telaCadastroCompromisso.Excluir();

                else if (opcaoSelecionada == "4")
                    telaCadastroCompromisso.VisualizarRegistros("Tela");

               

        }
    }
}
