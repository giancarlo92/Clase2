using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicando.DAL
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string contrasena { get; set; }
        public bool habilitar { get; set; }
    }
}
