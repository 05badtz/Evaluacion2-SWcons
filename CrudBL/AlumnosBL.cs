using CrudBOL;
using CrudDAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBL
{
    //Clase que contiene la lógica de negocios relacionada a alumnos
    public class AlumnosBL
    {
        //Registra un mensaje log en un archivo de texto ubicado en Documentos
        public void log(string message)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputfile = new StreamWriter(Path.Combine(docPath, "Evaluacion2_SWcons.log"), true))
            {
                outputfile.WriteLine(DateTime.Now.ToString() + " - " + message);
            }
        }
        //Valida si existe un alumno en la base de datos 
        public int ContAlumnos(AlumnoBOL obj)
        {
            log("Consultando existencia del alumno");
            AlumnosDAL dal = new AlumnosDAL();
            int count = dal.ContAlumnos(obj);
            log("Contador de alumnos: " + count);
            return count;
        }
        //Almacena un alumno en la base de datos
        public bool GuardarAlumnos(AlumnoBOL obj)
        {
            log("Almacenando alumno");
            AlumnosDAL dal = new AlumnosDAL();
            bool result = dal.GuardarAlumnos(obj);
            if (result)
            {
                log("Alumno almacenado correctamente");
                return true;
            }
            else
            {
                log("El alumno no fue ingresado correctamente");
                return false;
            }
        }
        //Crea una lista a partir de los alumnos existentes en la base de datos
        public List<AlumnoBOL> list()
        {
            log("Buscando a todos los alumnos almacenados");
            try
            {
                AlumnosDAL dal = new AlumnosDAL();
                List<AlumnosDAL> lista = new List<AlumnosDAL>();
                log("Cantidad de alumnos: " + lista.Count);
                return dal.list();
            }
            catch (Exception) {
                log("Ocurrió un error al listar los alumnos");
                return null;
            }
        }
        //Elimina un alumno en la base de datos a partir de la id
        public bool BorrarAlumno(int idAlumno)
        {
            log("Eliminando alumno...");
            AlumnosDAL dal = new AlumnosDAL();
            bool result = dal.BorrarAlumno(idAlumno);
            if (result)
            {
                log("Alumno eliminado correctamente");
                return true;
            }
            else
            {
                log("No se pudo eliminar al alumno");
                return false;
            }
        }
        //Modifica un alumno en la base de datos a partir de la id
        public bool ModificarAlumno(AlumnoBOL obj, int idAlumno)
        {
            log("Modificando alumno");
            AlumnosDAL dal = new AlumnosDAL();
            bool result = dal.ModificarAlumno(obj, idAlumno);
            if (result)
            {
                log("Alumno modificado correctamente");
                return true;
            }
            else
            {
                log("No se pudo modificar al alumno");
                return false;
            }
        }
        //Valida si se pudo seleccionar al alumno
        public AlumnoBOL SelectAlumno(int idAlumno)
        {
            log("Buscando al alumno seleccionado");
            try
            {
                AlumnosDAL dal = new AlumnosDAL();
                log("Alumno encontrado");
                return dal.SelectAlumno(idAlumno);//retorna true si se encuentra un alumno
            }
            catch (Exception) {
                log("No se pudo obtener información del alumno");
                return null;
            }
        }
    }
}
