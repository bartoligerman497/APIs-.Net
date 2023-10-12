﻿using ProyectoEF.Models;
using ProyectoEF;

namespace webapi.Services
{
    public class TareaService : ITareaService
    {
        TareasContext context;

        public TareaService(TareasContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Tarea> Get()
        {
            return context.Tareas;
        }

        public async Task Save(Tarea tarea)
        {
            context.Add(tarea);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Tarea tarea)
        {
            var tareaActual = context.Tareas.Find(id);

            if (tareaActual == null)
            {
                tareaActual.Titulo = tarea.Titulo;
                tareaActual.Descripcion = tarea.Descripcion;
                    

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var categoriaActual = context.Categorias.Find(id);

            if (categoriaActual == null)
            {
                context.Remove(categoriaActual);

                await context.SaveChangesAsync();
            }
        }
    }

    public interface ITareaService
    {
        IEnumerable<Tarea> Get();
        Task Save(Tarea tarea);
        Task Update(Guid id, Tarea categoriatarea);
        Task Delete(Guid id);
    }
}
