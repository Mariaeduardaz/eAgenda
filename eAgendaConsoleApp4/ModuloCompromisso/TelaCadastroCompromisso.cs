using eAgendaConsoleApp4.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaConsoleApp4.Compromisso
{
    
    

        public class TelaCadastroCompromisso : TelaBase<RepositorioCompromisso, Compromisso>
        {
            private readonly RepositorioCompromisso _repositorioCompromisso;
            private readonly Notificador _notificador;
           


            public TelaCadastroCompromisso(RepositorioCompromisso repositorioCompromisso, Notificador notificador)
                : base("Cadastro de Compromisso")
            {
                _repositorioCompromisso = repositorioCompromisso;
                _notificador = notificador;
            }

            public void Inserir()
            {
                MostrarTitulo("Cadastro de compromisso");

                Compromisso novocompromisso = ObterCompromisso();

                _repositorioCompromisso.Inserir(novocompromisso);

                _notificador.ApresentarMensagem("compromisso cadastrado com sucesso!", Mensagem.Sucesso);
            }

            public void Editar()
            {
                MostrarTitulo("Editando Compromisso");

                bool temCompromissosCadastrados = VisualizarRegistros("Pesquisando");

                if (temCompromissosCadastrados == false)
                {
                    _notificador.ApresentarMensagem("Nenhum compromisso cadastrado para editar.", Mensagem.Atencao);
                    return;
                }

                int numeroCompromisso = ObterNumeroRegistro();

                Compromisso compromissoAtualizado = ObterCompromisso();

                bool conseguiuEditar = _repositorioCompromisso.Editar(numeroCompromisso, compromissoAtualizado);

                if (!conseguiuEditar)
                    _notificador.ApresentarMensagem("Não foi possível editar.", Mensagem.Erro);
                else
                    _notificador.ApresentarMensagem("compromisso editado com sucesso!", Mensagem.Sucesso);
            }

            public void Excluir()
            {
                MostrarTitulo("Excluindo compromisso");

                bool temCompromissosRegistrados = VisualizarRegistros("Pesquisando");

                if (temCompromissosRegistrados == false)
                {
                    _notificador.ApresentarMensagem("Nenhum compromisso cadastrado para excluir.", Mensagem.Atencao);
                    return;
                }

                int numeroCompromisso = ObterNumeroRegistro();

                bool conseguiuExcluir = _repositorioCompromisso.Excluir(numeroCompromisso);

                if (!conseguiuExcluir)
                    _notificador.ApresentarMensagem("Não foi possível excluir.", Mensagem.Erro);
                else
                    _notificador.ApresentarMensagem("compromisso excluído com sucesso1", Mensagem.Sucesso);
            }

            public bool VisualizarRegistros(string tipoVisualizacao)
            {
                if (tipoVisualizacao == "Tela")
                    MostrarTitulo("Visualização de compromissos");

                List<Compromisso> compromisso = _repositorioCompromisso.SelecionarTodos();

                if (compromisso.Count == 0)
                {
                    _notificador.ApresentarMensagem("Nenhum compromisso disponível.", Mensagem.Atencao);
                    return false;
                }

                foreach (Compromisso funcionario in compromisso)
                    Console.WriteLine(funcionario.ToString());

                Console.ReadLine();

                return true;
            }

            private Compromisso ObterCompromisso()
            {
                Console.Write("Digite o assunto do seu compromisso: ");
                string assunto = Console.ReadLine();

                Console.Write("Digite o local: ");
                string local = Console.ReadLine();

                Console.Write("Digite o contato: ");
                int contato = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Qual é a data do seu compromisso?: ");
                DateTime dataCompromisso = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Qual é a hora do inicio do seu compromisso?");
                DateTime horadeinicio = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Qual é a hora que termina seu compromisso");
                  DateTime horaQueTermina = Convert.ToDateTime(Console.ReadLine());


                return new Compromisso (assunto, local, horadeinicio, horaQueTermina, contato, dataCompromisso);
            }

            public int ObterNumeroRegistro()
            {
                int numeroRegistro;
                bool numeroRegistroEncontrado;

                do
                {
                    Console.Write("Digite o ID do compromisso que deseja editar: ");
                    numeroRegistro = Convert.ToInt32(Console.ReadLine());

                    numeroRegistroEncontrado = _repositorioCompromisso.ExisteRegistro(numeroRegistro);

                    if (numeroRegistroEncontrado == false)
                        _notificador.ApresentarMensagem("ID do Funcionário não foi encontrado, digite novamente", Mensagem.Erro);

                } while (numeroRegistroEncontrado == false);

                return numeroRegistro;
            }
        }

    
}
