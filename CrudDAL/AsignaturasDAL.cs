using CrudBOL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDAL
{
    //Clase que contiene la lógica de datos relacionada a asignaturas
    public class AsignaturasDAL
    {
        //Colocar la cadena de conexión de la base de datos local
        string constring = "Data Source=LAPTOP-KV53R3CH\\SQLEXPRESS;Initial Catalog=Evaluacion2_SWcons;Integrated Security=True;";
        //Elimina una asignatura en la base de datos desde la id
        public bool BorrarAsignatura(int idAsignatura)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string sql = "delete from Asignaturas where CodigoAsignatura=@CodigoAsignatura";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@CodigoAsignatura", idAsignatura);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;// true si se eliminó al menos una fila
                    }
                }
            }
            catch (Exception) { return false; }
        }
        //Almacena todas las asignaturas existentes en una lista
        public List<AsignaturaBOL> list()
        {
            List<AsignaturaBOL> lista = new List<AsignaturaBOL>();
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string sql = "select CodigoAsignatura, NombreAsignatura, Creditos from Asignaturas";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AsignaturaBOL
                            {
                                CodigoAsignatura = reader.GetInt32(0),
                                NombreAsignatura = reader.GetString(1),
                                Creditos = reader.GetInt32(2)
                            });
                        }
                    }
                }
                return lista;
            }
            catch (Exception) { return null; }
        }
        //Almacena una nueva asignatura en la base de datos
        public bool GuardarAsignatura(AsignaturaBOL obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string sql = "insert into Asignaturas (NombreAsignatura, Creditos) " +
                        "values (@NombreAsignatura, @Creditos)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@NombreAsignatura", obj.NombreAsignatura);
                        cmd.Parameters.AddWithValue("@Creditos", obj.Creditos);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception) { return false; }
        }
        //Valida si existe una asignatura en la base de datos
        public int ContAsignatura(AsignaturaBOL obj)
        {
            int result = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string sql = "select count(*) from Asignaturas " +
                        "where NombreAsignatura=@NombreAsignatura";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@NombreAsignatura", obj.NombreAsignatura);
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
            return result;
        }
        //Permite modificar una asignatura en la base de datos desde la id
        public bool ModificarAsignatura(AsignaturaBOL obj, int idAsignatura)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string sql = "update Asignaturas set NombreAsignatura=@NombreAsignatura, Creditos=@Creditos " +
                        "where CodigoAsignatura=@CodigoAsignatura";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@NombreAsignatura", obj.NombreAsignatura);
                        cmd.Parameters.AddWithValue("@Creditos", obj.Creditos);
                        cmd.Parameters.AddWithValue("@CodigoAsignatura", idAsignatura);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception) { return false; }
        }
        //Selecciona una asignatura existente en la base de datos
        public AsignaturaBOL SelectAsignatura(int idAsignatura)
        {
            AsignaturaBOL asBOL = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string sql = "select NombreAsignatura, Creditos from Asignaturas " +
                        "where CodigoAsignatura=@CodigoAsignatura";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@CodigoAsignatura", idAsignatura);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                asBOL = new AsignaturaBOL
                                {
                                    NombreAsignatura = reader.GetString(0),
                                    Creditos = reader.GetInt32(1)
                                };
                            } 
                        }
                    }
                }
                return asBOL;
            }
            catch (Exception) { return null; }
        }
    }
}
