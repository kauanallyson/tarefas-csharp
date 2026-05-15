using Microsoft.EntityFrameworkCore;
using Tarefas.Data;
using Tarefas.Models;

namespace Tarefas.Services
{
    public class TarefaService
    {
        private readonly AppDbContext _db;

        public TarefaService(AppDbContext db) { _db = db; }

        public async Task<List<Tarefa>> ListarTodos()
        {
            return await _db.Tarefas.ToListAsync();
        }

        public async Task<Tarefa?> BuscarPorId(int id)
        {
            return await _db.Tarefas.FindAsync(id);
        }

        public async Task<Tarefa> Criar(TarefaDto dto)
        {
            var tarefa = new Tarefa { Desc = dto.Desc, Terminado = dto.Terminado };
            _db.Tarefas.Add(tarefa);
            await _db.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa?> Atualizar(int id, TarefaDto dto)
        {
            var tarefa = await _db.Tarefas.FindAsync(id);
            if (tarefa is null) return null;

            tarefa.Desc = dto.Desc;
            tarefa.Terminado = dto.Terminado;

            await _db.SaveChangesAsync();
            return tarefa;
        }

        public async Task<bool> Deletar(int id)
        {
            var tarefa = await _db.Tarefas.FindAsync(id);
            if (tarefa is null) return false;

            _db.Tarefas.Remove(tarefa);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
