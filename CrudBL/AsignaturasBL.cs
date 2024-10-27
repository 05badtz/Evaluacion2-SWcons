using CrudBOL;
using CrudDAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CrudBL
{
    //Clase que contiene la lógica de negocios relacionada a asignatura
    public class AsignaturasBL
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
        //Valida si existe la asignatura en la base de datos
        public int ContAsignatura(AsignaturaBOL obj)
        {
            log("Consultando la existencia de la asignatura");
            AsignaturasDAL dal = new AsignaturasDAL();
            int count = dal.ContAsignatura(obj);
            log("Contador de asignaturas: " + count);
            return count;
        }
        //Almacena una asignatura en la base de datos
        public bool GuardarAsignatura(AsignaturaBOL obj)
        {
            log("Almacenando asignatura");
            AsignaturasDAL dal = new AsignaturasDAL();
            bool result = dal.GuardarAsignatura(obj);
            if (result)
            {
                log("Asignatura almacenada correctamente");
                return true;
            }
            else
            {
                log("No se pudo almacenar la asignatura");
                return false;
            }
        }
        //Crea una lista a partir de las asignaturas almacenadas en la base de datos
        public List<AsignaturaBOL> list()
        {
            log("Buscando las asignaturas disponibles");
            try
            {
                AsignaturasDAL dal = new AsignaturasDAL();
                List<AsignaturaBOL> lista = new List<AsignaturaBOL>();
                log("Cantidad de asignaturas: " + lista.Count);
                return dal.list();
            }
            catch (Exception)
            {
                log("No se pudieron listar las asignaturas");
                return null;
            }
        }
        //Elimina una asignatura en la base de datos a partir de la id
        public bool BorrarAsignatura(int idAsignatura)
        {
            log("Eliminando Asignatura");
            AsignaturasDAL dal = new AsignaturasDAL();
            bool result = dal.BorrarAsignatura(idAsignatura);
            if (result)
            {
                log("Asignatura eliminada correctamente");
                return true;
            }
            else
            {
                log("No se pudo eliminar la asignatura seleccionada");
                return false;
            }
        }
        //Modifica una asignatura en la base de datos a partir de la id
        public bool ModificarAsignatura(AsignaturaBOL obj, int idAsignatura)
        {
            log("Modificando asignatura");
            AsignaturasDAL dal = new AsignaturasDAL();
            bool result = dal.ModificarAsignatura(obj, idAsignatura);
            if (result)
            {
                log("Asignatura modificada correctamente");
                return true;
            }
            else
            {
                log("No se pudo modificar la asignatura seleccionada");
                return false;
            }
        }
        //Valida si se pudo seleccionar la asignatura
        public AsignaturaBOL SelectAsignatura(int idAsignatura)
        {
            log("Buscando la asignatura seleccionada");
            try
            {
                AsignaturasDAL dal = new AsignaturasDAL();
                log("Asignatura encontrada");
                return dal.SelectAsignatura(idAsignatura); //retorna true si se encuentra un alumno
            }
            catch (Exception)
            {
                log("No se pudo obtener información de la asignatura");
                return null;
            }
        }
    }
}
