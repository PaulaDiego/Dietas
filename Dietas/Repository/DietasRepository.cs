using Dietas;
using Dietas.Models;
using Dietas.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dietas.Repository
{
    public class PacientesRepository : IPacientesRepository
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        public Paciente Create(Paciente _Paciente)
        {
            return ApplicationDbContext.applicationDbContext.Pacientes.Add(_Paciente);
        }

        public Paciente Delete(long id)
        {
            Paciente Paciente = this.Read(id);
            if(Paciente == null)
            {
                throw new NoEncontradoException("No se ha encontrado la Paciente  a eliminar");
            }
            return ApplicationDbContext.applicationDbContext.Pacientes.Remove(Paciente);

        }

        public void PutPaciente(Paciente Paciente)
        {
            ApplicationDbContext.applicationDbContext.Entry(Paciente).State = EntityState.Modified;
        }

        public Paciente Read(long id)
        {
            return ApplicationDbContext.applicationDbContext.Pacientes.Find(id);
        }

        public IQueryable<Paciente> ReadPacientes()
        {
            IList<Paciente> lista = new List<Paciente>(ApplicationDbContext.applicationDbContext.Pacientes);
            return lista.AsQueryable();
        }
    }
}