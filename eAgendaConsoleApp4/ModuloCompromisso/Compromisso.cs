using eAgendaConsoleApp4.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaConsoleApp4.Compromisso
{


    public class Compromisso : EntidadeBase
    {
        DateTime horaQueTermina;
        DateTime horadeinicio;
        int contato;
        string assunto;
        string local;
        private DateTime dataCompromisso;





        public Compromisso(string assunto, string local, DateTime horadeinicio, DateTime horaQueTermina, int contato, DateTime dataCompromisso)
        {
            this.horaQueTermina = horaQueTermina;
            this.horadeinicio = horadeinicio;
            this.assunto = assunto;
            this.local = local;
            this.contato = contato;
            this.dataCompromisso = dataCompromisso;
        }

        public string Assunto { get; }
        public string Local { get; }
        public string Link { get; }
        public DateTime Data { get; }
        public TimeSpan DatadoInicio { get; }
        public TimeSpan DatadoFim { get; }
        public DateTime DataCompromisso { get; }


        public override string ToString()
        {
            return "ID: " + id + Environment.NewLine +
                "Assunto: " + Assunto + Environment.NewLine +
                "Local: " + Local + Environment.NewLine +
                "Contato: " + contato + Environment.NewLine +
                "Data do Compromisso: " + DataCompromisso + Environment.NewLine +
                "Hora de Inicio: " + horadeinicio + Environment.NewLine +
                "Hora de Termino: " + horaQueTermina + Environment.NewLine;

        }
} }   
    
