using Senai.Gerir.Api.Contextos;
using Senai.Gerir.Api.Dominios;
using Senai.Gerir.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gerir.Api.Repositorios
{
    public class TarefasRepositorio : ITarefasRepositorio

    {
        //Declaro um objeto do tipo GerirContext que será
        //a representação do banco de dados
        private readonly GerirContext _context;

        public TarefasRepositorio()
        {
            //Cria uma instância de GerirContext
            _context = new GerirContext();
        }

        public Tarefa AlterarStatus(Guid IdTarefa)
        {
            throw new NotImplementedException();
        }

        public Tarefa BuscarPorId(Guid IdTarefa)
        {
            try
            {
                //Busca o usuario pelo seu Id usando o Find
                var tarefa = _context.Tarefas.Find(IdTarefa);

                return tarefa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Tarefa Cadastrar(Tarefa tarefa)
        {
            try
            {
                //adiciona um usuario ao DbSet Usuarios do contexto
                _context.Tarefas.Add(tarefa);
                //Salva as alterações do contexto
                _context.SaveChanges();

                return tarefa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    

        public Tarefa Editar(Tarefa tarefa)
        {
            try
            {
                //Busca a tarefa no banco
                var tarefaexiste = BuscarPorId(tarefa.Id);

                //Verifica se o usuário existe
                if (tarefaexiste == null)
                    throw new Exception("Tarefa não encontrada");

                //Altera os valores da tarefa
                tarefaexiste.Categoria = tarefa.Categoria;
                tarefaexiste.Descricao = tarefa.Descricao;

               
                _context.Tarefas.Update(tarefaexiste);
                _context.SaveChanges();

                return tarefaexiste;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Tarefa> ListarTodos(Guid IdUsuarios)
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid IdTarefa)
        {
            try
            {
                var tarefa = BuscarPorId(IdTarefa);

                _context.Tarefas.Remove(tarefa);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
