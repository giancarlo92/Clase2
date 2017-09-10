using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practicando.DAL;

namespace practicando
{
    class Program
    {
        static void Main(string[] args)
        {
            Consultas objConsultas = new Consultas();
            Usuario objUsuario = new Usuario();
            //objUsuario.nombre = "Juan Perez";
            //objUsuario.contrasena = "123456";
            //objUsuario.habilitar = true;
            //objConsultas.CrearNuevoUsuario(objUsuario);

            objConsultas.ListarDatosUsuario().ForEach(usuario => Console.WriteLine(usuario.nombre));
            objConsultas.EliminarUsuario(2);
            Console.ReadKey();
        }
    }
}
