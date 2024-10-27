using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBOL
{
    //Clase que contiene la lógica de objetos de negocio relacionada a alumnos
    public class AlumnoBOL
    {
        public int IDAlumno { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidoMat { get; set; }
        public string Email { get; set; }
        public string NumMatricula { get; set; }
    }
}
