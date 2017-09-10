using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace practicando.DAL
{
    public class Consultas
    {
        private SqlConnection iniciarConexion()
        {
            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = ConfigurationManager.ConnectionStrings["Usuario"].ConnectionString;
            return conection;
        }

        public void CrearNuevoUsuario(Usuario objUsuario)
        {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("InsertarNuevoUsuario", conection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Nombre", objUsuario.nombre));
            comando.Parameters.Add(new SqlParameter("@Contrasena", objUsuario.contrasena));
            comando.Parameters.Add(new SqlParameter("@Habilitar", objUsuario.habilitar));
            conection.Open();
            comando.ExecuteNonQuery();
            conection.Close();
        }

        public List<Usuario> ListarDatosUsuario()
        {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("ListarDatosUsuario", conection);
            comando.CommandType = CommandType.StoredProcedure;
            conection.Open();
            SqlDataReader lectorDatos = comando.ExecuteReader();
            List<Usuario> objUsuarios = new List<Usuario>();
            while (lectorDatos.Read())
            {
                Usuario objUsuario = new Usuario();
                objUsuario.id = lectorDatos.GetInt32(0);
                objUsuario.nombre = lectorDatos.GetString(1);
                objUsuario.contrasena = lectorDatos.GetString(2);
                objUsuario.habilitar = lectorDatos.GetBoolean(3);
                objUsuarios.Add(objUsuario);
            }
            conection.Close();
            return objUsuarios;
        }

        public void EliminarUsuario(int id)
        {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("EliminarUsuario", conection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@ID", id));
            conection.Open();
            comando.ExecuteNonQuery();
            conection.Close();
        }
    }
}
