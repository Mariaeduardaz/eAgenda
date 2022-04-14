using eAgendaConsoleApp4.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaConsoleApp4.Contatos
{
    public class Contatos : EntidadeBase, IComparable<Contatos>
    {
        string nome; string email;string telefone; string cargo; string empresa;
        

        public Contatos(string nome,string email,string empresa,string telefone,string cargo)
        {
           
            this.empresa = empresa;
            this.email = email;
            this.telefone = telefone;
            this.nome = nome;
            this.cargo = cargo;
        }

        public string Nome { get => nome; }
        public string Email { get => email; }
        public string Telefone { get => telefone; }
        public string Cargo { get => cargo; }
       public string Empresa { get => empresa; }
        

        public int CompareTo(Contatos other)
        {
            return cargo.CompareTo(other.cargo);
        }

        public override string ToString()
        {
            return $"Id : {id}\n" +
                $"email : {email}\n" +
                $"nome : {Nome}\n" +
                $"telefone : {telefone}\n" +
                $"empresa : {empresa}\n" +
                $"cargo : {cargo}\n";
        }
    }
} 

