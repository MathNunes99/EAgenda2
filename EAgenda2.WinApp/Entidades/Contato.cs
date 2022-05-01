using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda2.WinApp.Entidades
{
    [Serializable]
    public class Contato : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public int DDD { get; set; }
        public string Empresa { get; set; }
        public int cargo { get; set; }
        public bool compromisso { get; set; }
        public override string ToString()
        {
            return $"Contato {Numero} - Nome: {Nome} / Cargo: {CargoToStr()}";
        }
        private string CargoToStr()
        {
            string cargostr = "";
            if (cargo == 3)
            {
                cargostr = "Diretor";
            }
            if (cargo == 2)
            {
                cargostr = "Gerente";
            }
            if (cargo == 1)
            {
                cargostr = "Assistente";
            }
            return cargostr;
        }
    }
}
