using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dietas
{
    public class Dieta
    {
        public long Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public int CaloriasDia { get; set; }
        public int Dureza { get; set; }

    }
}