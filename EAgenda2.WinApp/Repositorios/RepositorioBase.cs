using EAgenda2.WinApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda2.WinApp.Repositorios
{
    public class RepositorioBase<T> where T : EntidadeBase
    {
        protected readonly List<T> registros = new List<T>();
        private int contador = 0;

        public void Inserir(T entidade)
        {
            entidade.Numero = ++contador;
            registros.Add(entidade);
        }
        public virtual void Editar(T entidade)
        {

        }
        public virtual void Excluir(T entidade)
        {

        }
        
        
    }
}
