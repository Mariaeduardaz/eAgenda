using eAgendaConsoleApp4.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaConsoleApp4.Contatos
{
    
    
        public class TelaCadastroContatos : TelaBase <RepositorioContato, Contatos>
        {
            private readonly RepositorioContato _repositorioContatos;
            private readonly Notificador _notificador;


            public TelaCadastroContatos(RepositorioContato repositorioContatos, Notificador notificador)
                : base("Cadastro de Contatos")
            {
                _repositorioContatos = repositorioContatos;
                _notificador = notificador;
            }

            public void Inserir()
            {
                MostrarTitulo("Cadastro de Contato");

                Contatos novocontato = ObterContatos();

                _repositorioContatos.Inserir(novocontato);

                _notificador.ApresentarMensagem("Contato cadastrado com sucesso!", Mensagem.Sucesso);
            }

            public void Editar()
            {
                MostrarTitulo("Editando Contatos");

                bool temContatossCadastrados = VisualizarRegistros("Pesquisando");

                if (temContatossCadastrados == false)
                {
                    _notificador.ApresentarMensagem("Nenhum funcionário cadastrado para editar.", Mensagem.Atencao);
                    return;
                }

                int numeroContatos = ObterNumeroRegistro();

                Contatos contatoAtualizado = ObterContatos();

                bool conseguiuEditar = _repositorioContatos.Editar(numeroContatos, contatoAtualizado);

                if (!conseguiuEditar)
                    _notificador.ApresentarMensagem("Não foi possível editar.", Mensagem.Erro);
                else
                    _notificador.ApresentarMensagem("Contato editado com sucesso!", Mensagem.Sucesso);
            }

            public void Excluir()
            {
                MostrarTitulo("Excluindo Contato");

                bool temContatossRegistrados = VisualizarRegistros("Pesquisando");

                if (temContatossRegistrados == false)
                {
                    _notificador.ApresentarMensagem("Nenhum funcionário cadastrado para excluir.", Mensagem.Atencao);
                    return;
                }

                int numeroContatos = ObterNumeroRegistro();

                bool conseguiuExcluir = _repositorioContatos.Excluir(numeroContatos);

                if (!conseguiuExcluir)
                    _notificador.ApresentarMensagem("Não foi possível excluir.", Mensagem.Erro);
                else
                    _notificador.ApresentarMensagem("Contato excluído com sucesso1", Mensagem.Sucesso);
            }

            public bool VisualizarRegistros(string tipoVisualizacao)
            {
                if (tipoVisualizacao == "Tela")
                    MostrarTitulo("Visualização de Contatos");

                List<Contatos> contatos = _repositorioContatos.SelecionarTodos();

                if (contatos.Count == 0)
                {
                    _notificador.ApresentarMensagem("Nenhum funcionário disponível.", Mensagem.Atencao);
                    return false;
                }

                foreach (Contatos contato in contatos)
                    Console.WriteLine(contato.ToString());

                Console.ReadLine();

                return true;
            }

            private Contatos ObterContatos()
            {
                Console.Write("Digite o nome do seu contato: ");
                string nome = Console.ReadLine();

                Console.Write("Digite a empresa: ");
                string empresa = Console.ReadLine();

                Console.Write("Digite o telefone: ");
                string telefone = Console.ReadLine();

                Console.WriteLine("Qual seu cargo?: ");
                string cargo = Console.ReadLine();

               Console.WriteLine("Qual seu email");
                string email = Console.ReadLine();
                

                return new Contatos(nome, empresa, telefone, email, cargo);
            }

            public int ObterNumeroRegistro()
            {
                int numeroRegistro;
                bool numeroRegistroEncontrado;

                do
                {
                    Console.Write("Digite o ID do Contato que deseja editar: ");
                    numeroRegistro = Convert.ToInt32(Console.ReadLine());

                    numeroRegistroEncontrado = _repositorioContatos.ExisteRegistro(numeroRegistro);

                    if (numeroRegistroEncontrado == false)
                        _notificador.ApresentarMensagem("ID do Contato não foi encontrado, digite novamente", Mensagem.Atencao);

                } while (numeroRegistroEncontrado == false);

                return numeroRegistro;
            }
        }
    
}
