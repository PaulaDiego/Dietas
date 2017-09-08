using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietas.Service
{
    public interface IPacientesService
    {
        Paciente Create(Paciente Paciente);
        Paciente Delete(long id);
        Paciente GetPaciente(long id);
        void PutPaciente(Paciente Paciente);
        IQueryable<Paciente> ReadPacientes();
    }
}
