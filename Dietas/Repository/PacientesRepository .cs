using Dietas;
using Dietas.Models;
using Dietas.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dietas.Repository
{
    public class DietasRepository : IDietasRepository
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        public Dieta Create(Dieta _Dieta)
        {
            return ApplicationDbContext.applicationDbContext.Dietas.Add(_Dieta);
        }

        public Dieta Delete(long id)
        {
            Dieta Dieta = this.Read(id);
            if(Dieta == null)
            {
                throw new NoEncontradoException("No se ha encontrado la Dieta  a eliminar");
            }
            return ApplicationDbContext.applicationDbContext.Dietas.Remove(Dieta);

        }

        public void PutDieta(Dieta Dieta)
        {
            ApplicationDbContext.applicationDbContext.Entry(Dieta).State = EntityState.Modified;
        }

        public Dieta Read(long id)
        {
            return ApplicationDbContext.applicationDbContext.Dietas.Find(id);
        }

        public IQueryable<Dieta> ReadDietas()
        {
            IList<Dieta> lista = new List<Dieta>(ApplicationDbContext.applicationDbContext.Dietas);
            return lista.AsQueryable();
        }
    }
}