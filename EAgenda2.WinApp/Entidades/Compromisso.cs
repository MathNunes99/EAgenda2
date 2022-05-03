using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda2.WinApp.Entidades
{
    [Serializable]
    public class Compromisso : EntidadeBase
    {
        public string Assunto { get; set; }
        public string Local { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Inicio { get; set; }
        public int Termino { get; set; }
        public Contato contato { get; set; }

        public override string ToString()
        {
            return $"Compromisso {Numero} - Assunto: {Assunto} / Local: {Local} / Dia {Dia}/{Mes} / " +
                $"Hora: {Inicio}:00h a {Termino}:00h / Contato: {contato.Nome}";
        }        
    }
}
