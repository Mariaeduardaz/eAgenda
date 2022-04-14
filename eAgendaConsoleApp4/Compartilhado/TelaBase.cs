using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaConsoleApp4.Compartilhado
{

    public abstract class TelaBase <RepositorioBase, T>where T : EntidadeBase
    {
        protected string Titulo { get; set; }
        private RepositorioBase<T> repositorio;
        private readonly Notificador notificador = new Notificador();

        public TelaBase(string titulo)
        {
            Titulo = titulo;
        }


        public virtual string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        protected virtual void Excluir()
        {
            repositorio.Excluir(ObterNumeroRegistro());
            bool tementidadesRegistrados = VisualizarRegistros("pesquisando");
            if(tementidadesRegistrados == false)
            {
                notificador.ApresentarMensagem("Nenhum registro foi cadastrado para excluir", Mensagem.Atencao);
            }
        }
        protected virtual void Inserir(T entidade)
        {
            repositorio.Inserir(entidade);
            notificador.ApresentarMensagem("registro cadastrado com sucesso!", Mensagem.Sucesso);
        }

        public virtual bool VisualizarRegistros(string tipoVisualizacao)
        {

            List<T> registros = repositorio.SelecionarTodos();

            if (registros.Count == 0)
            {
                Notificador.ApresentarMensagem("Nenhum registro disponível.", Mensagem.Atencao);
                return false;
            }

            foreach (T registro in registros)
                Console.WriteLine(registro.ToString());

            Console.ReadLine();
            return true;

        }

        protected virtual void Editar(T entidade, int id)
        {
            VisualizarRegistros("pesquisando");
            repositorio.Editar(id, entidade);
            bool temEntidadesRegistrados = VisualizarRegistros("Pesquisando");

            if (temEntidadesRegistrados == false)
            {
                notificador.ApresentarMensagem("Nenhum cadastrado para editar.", Mensagem.Atencao);
                return;
            }
        }

        protected virtual int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {

                VisualizarRegistros("pesquisando");
                Console.Write("Digite o ID que deseja mexer: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = repositorio.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    notificador.ApresentarMensagem("ID não foi encontrado, digite novamente", Mensagem.Atencao);

            } while (numeroRegistroEncontrado == false);
            return numeroRegistro;
        }

        protected void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }
    }
}
