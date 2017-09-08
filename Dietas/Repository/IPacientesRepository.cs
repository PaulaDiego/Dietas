using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietas.Repository
{
    public interface IPacientesRepository
    {
        Paciente Create(Paciente _Paciente);
        Paciente Delete(long id);
        void PutPaciente(Paciente Paciente);
        Paciente Read(long id);
        IQueryable<Paciente> ReadPacientes();
    }
}
