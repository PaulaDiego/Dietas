using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietas.Repository
{
    public interface IDietasRepository
    {
        Dieta Create(Dieta _Dieta);
        Dieta Delete(long id);
        void PutDieta(Dieta Dieta);
        Dieta Read(long id);
        IQueryable<Dieta> ReadDietas();
    }
}
