using CrudBOL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDAL
{
    //Clase que contiene la lógica de datos relacionada a alumnos
    public class AlumnosDAL
    {
        //Colocar la cadena de conexión de la base de datos local
        string constring = "Data Source=LAPTOP-KV53R3CH\\SQLEXPRESS;Initial Catalog=Evaluacion2_SWcons;Integrated Security=True;";
        //Elimina un alumno en la base de datos desde la id
        public bool BorrarAlumno(int idAlumno)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string sql = "delete from Alumnos where IDAlumno=@IDAlumno";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@IDAlumno", idAlumno);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;//si result es mayor que 0 = true (se eliminó al menos una fila)
                    }
                }
            }
            catch (Exception) { return false; }
        }
        //Almacena todos los alumnos existentes en una lista
        public List<AlumnoBOL> list()
        {
            List<AlumnoBOL> lista = new List<AlumnoBOL>();
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string sql = "select IDAlumno, Nombre, ApellidoPat, ApellidoMat, Email, NumMatricula from Alumnos";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AlumnoBOL
                            {
                                IDAlumno = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                ApellidoPat = reader.GetString(2),
                                ApellidoMat = reader.GetString(3),
                                Email = reader.GetString(4),
                                NumMatricula = reader.GetString(5),
                            });
                        }
                    }
                }
                return lista;
            }
            catch (Exception) { return null; }
        }
        //Almacena un nuevo alumno en la base de datos
        public bool GuardarAlumnos(AlumnoBOL obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string sql = "insert into Alumnos (Nombre, ApellidoPat, ApellidoMat, Email, NumMatricula) " +
                        "values (@Nombre, @ApellidoPat, @ApellidoMat, @Email, @NumMatricula)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPat", obj.ApellidoPat);
                        cmd.Parameters.AddWithValue("@ApellidoMat", obj.ApellidoMat);
                        cmd.Parameters.AddWithValue("@Email", obj.Email);
                        cmd.Parameters.AddWithValue("@NumMatricula", obj.NumMatricula);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception) { return false; }
        }
        //Valida si existe un alumno en la base de datos
        public int ContAlumnos(AlumnoBOL obj)
        {
            int result = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string sql = "select count(*) from Alumnos " +
                                 "where Email=@Email or NumMatricula=@NumMatricula";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", obj.Email);
                        cmd.Parameters.AddWithValue("@NumMatricula", obj.NumMatricula);

                        result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            return result;
        }
        //Permite modificar un alumno en la base de datos desde la id
        public bool ModificarAlumno(AlumnoBOL obj, int idAlumno)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string sql = "update Alumnos " +
                        "set Nombre=@Nombre, ApellidoPat=@ApellidoPat, ApellidoMat=@ApellidoMat, Email=@Email, NumMatricula=@NumMatricula " +
                        "where IDAlumno=@IDAlumno";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPat", obj.ApellidoPat);
                        cmd.Parameters.AddWithValue("@ApellidoMat", obj.ApellidoMat);
                        cmd.Parameters.AddWithValue("@Email", obj.Email);
                        cmd.Parameters.AddWithValue("@NumMatricula", obj.NumMatricula);
                        cmd.Parameters.AddWithValue("@IDAlumno", idAlumno);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception) { return false; }
        }
        //Selecciona un alumno existente en la base de datos
        public AlumnoBOL SelectAlumno(int idAlumno)
        {
            AlumnoBOL alBOL = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string sql = "select Nombre, ApellidoPat, ApellidoMat, Email, NumMatricula " +
                        "from Alumnos where IDAlumno=@IDAlumno";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@IDAlumno", idAlumno);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                alBOL = new AlumnoBOL
                                {
                                    Nombre = reader.GetString(0),
                                    ApellidoPat = reader.GetString(1),
                                    ApellidoMat = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    NumMatricula = reader.GetString(4),
                                };
                            }
                        }
                    }
                }
                return alBOL;
            }
            catch (Exception) { return null; }
        }
    }
}
