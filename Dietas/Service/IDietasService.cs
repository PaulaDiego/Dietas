using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietas.Service
{
    public interface IDietasService
    {
        Dieta Create(Dieta Dieta);
        Dieta Delete(long id);
        Dieta GetDieta(long id);
        void PutDieta(Dieta Dieta);
        IQueryable<Dieta> ReadDietas();
    }
}
