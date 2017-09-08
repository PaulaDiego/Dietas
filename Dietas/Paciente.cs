using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dietas
{
    public class Paciente
    {
        public long Id { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Peso { get; set; }
        public int Altura { get; set; }
        public int NivelActividad { get; set; }
        public String Dieta { get; set; }
    }
}