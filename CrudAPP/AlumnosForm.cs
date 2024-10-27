using CrudBL;
using CrudBOL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudAPP
{
    public partial class AlumnosForm : Form
    {
        public AlumnosForm()
        {
            InitializeComponent();
        }
        //Actualiza el contenido del dataGridView
        void Recargar()
        {
            AlumnosBL alBL = new AlumnosBL();
            List<AlumnoBOL> lista = alBL.list();
            dataGV_Alumno.DataSource = null; //Limpia DataSource anterior
            dataGV_Alumno.DataSource = lista; //Asigna la lista como DataSource
        }
        //Método que da formato a datagridview
        void formatdataGV()
        {
            dataGV_Alumno.AutoGenerateColumns = false; //Prohibe la generación automática de columnas
            dataGV_Alumno.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//Se selecciona toda la fila de la datagridview
            dataGV_Alumno.AllowUserToAddRows = false;//Prohibe que se puedan agregar filas

            dataGV_Alumno.Columns.Clear(); //Limpia columnas existentes

            //Crea las columnas y las conecta con la propiedad del datasource
            dataGV_Alumno.ColumnCount = 6;
            dataGV_Alumno.Columns[0].Name = "ID";
            dataGV_Alumno.Columns[0].DataPropertyName = "IDAlumno";
            dataGV_Alumno.Columns[1].Name = "Nombre";
            dataGV_Alumno.Columns[1].DataPropertyName = "Nombre";
            dataGV_Alumno.Columns[2].Name = "Ap. Paterno";
            dataGV_Alumno.Columns[2].DataPropertyName = "ApellidoPat";
            dataGV_Alumno.Columns[3].Name = "Ap. Materno";
            dataGV_Alumno.Columns[3].DataPropertyName = "ApellidoMat";
            dataGV_Alumno.Columns[4].Name = "Email";
            dataGV_Alumno.Columns[4].DataPropertyName = "Email";
            dataGV_Alumno.Columns[5].Name = "Núm. Matricula";
            dataGV_Alumno.Columns[5].DataPropertyName = "NumMatricula";
        }
        //Al cargar el form se crearán las columnas del dataGridView
        private void AlumnosForm_Load(object sender, EventArgs e)
        {
            formatdataGV();
            foreach (DataGridViewColumn column in dataGV_Alumno.Columns)
            {
                if (column.Index == 0)
                    //Oculta la primera columna (ID)
                    column.Visible = false;
                else
                    //Ajusta el ancho de las columnas restantes al tamaño del dataGV
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            Recargar();
        }
        //Deshabilita contextMenuStrip si el usuario no selecciona una fila con datos
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGV_Alumno.SelectedRows.Count == 0)
                contextMenuStrip1.Enabled = false;
            else
                contextMenuStrip1.Enabled = true;
        }
        //Valida que los textbox no estén vacíos
        public bool ValidarTxtVacio(TextBox txt, string message)
        {
            if (String.IsNullOrEmpty(txt.Text))
            {
                MessageBox.Show(message);
                txt.Focus();
                return false;
            }
            return true;
        }
        //Valida el formato del email
        public bool ValidarEmail(string email)
        {
            string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailRegex);
        }
        //Valida todos los campos del formulario
        public bool ValidarForm()
        {
            if (!ValidarTxtVacio(txtNombre, "Nombre no puede estar vacío") ||
                !ValidarTxtVacio(txtApPat, "Apellido paterno no puede estar vacío") ||
                !ValidarTxtVacio(txtApMat, "Apellido materno no puede estar vacío") ||
                !ValidarTxtVacio(txtEmail, "Email no puede estar vacío") ||
                !ValidarTxtVacio(txtNumMat, "Número de matricula no puede estar vacío"))
            {
                return false;
            }
            if (!ValidarEmail(txtEmail.Text))
            {
                MessageBox.Show("Ingrese un email válido, ej: example@dom.com");
                txtEmail.Focus();
                return false;
            }
            return true;
        }
        //Almacena un alumno en la base de datos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Si los campos son correctos, se podrá almacenar al alumno en la base de datos
            if (ValidarForm())
            {
                AlumnoBOL alBOL = new AlumnoBOL();
                alBOL.Nombre = txtNombre.Text;
                alBOL.ApellidoPat = txtApPat.Text;
                alBOL.ApellidoMat = txtApMat.Text;
                alBOL.Email = txtEmail.Text;
                alBOL.NumMatricula = txtNumMat.Text;

                AlumnosBL alBL = new AlumnosBL();
                int count = alBL.ContAlumnos(alBOL);
                if (count == 0)
                {
                    bool result = alBL.GuardarAlumnos(alBOL);
                    if (result)
                        MessageBox.Show("Alumno almacenado correctamente.");
                    else
                        MessageBox.Show("No se pudo almacenar al alumno");
                }
                else
                    MessageBox.Show("El alumno ya se encuentra en la base de datos");

                Recargar();

                txtNombre.Text = "";
                txtApPat.Text = "";
                txtApMat.Text = "";
                txtEmail.Text = "";
                txtNumMat.Text = "";
            }
        }
        //Permite seleccionar un alumno para poder modificar sus datos después
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var idValor = dataGV_Alumno.SelectedRows[0].Cells[0].Value.ToString(); //Selecciona el valor de la columna "ID"
            if (idValor != null)
            {
                int id = int.Parse(idValor);
                if (id != 0)
                {
                    AlumnosBL alBL = new AlumnosBL();
                    AlumnoBOL alBOL = alBL.SelectAlumno(id);
                    txtNombre.Text = alBOL.Nombre;
                    txtApPat.Text = alBOL.ApellidoPat;
                    txtApMat.Text = alBOL.ApellidoMat;
                    txtEmail.Text = alBOL.Email;
                    txtNumMat.Text = alBOL.NumMatricula;
                }
                else
                    MessageBox.Show("No se seleccionó un alumno");
            }
        }
        //Modifica al alumno seleccionado en la base de datos
        private void btnModificar_Click(object sender, EventArgs e)
        {
            var idValor = dataGV_Alumno.SelectedRows[0].Cells[0].Value.ToString(); //Selecciona el valor de la columna "ID"
            if (idValor != null)
            {
                int id = int.Parse(idValor);

                AlumnosBL alBL = new AlumnosBL();
                //Si los campos son correctos, se podrá modificar al alumno
                if (ValidarForm())
                {
                    AlumnoBOL alBOL = new AlumnoBOL();
                    alBOL.Nombre = txtNombre.Text;
                    alBOL.ApellidoPat = txtApPat.Text;
                    alBOL.ApellidoMat = txtApMat.Text;
                    alBOL.Email = txtEmail.Text;
                    alBOL.NumMatricula = txtNumMat.Text;

                    bool result = alBL.ModificarAlumno(alBOL, id);
                    if (result)
                        MessageBox.Show("Alumno modificado correctamente.");
                    else
                        MessageBox.Show("No se pudo modificar al alumno");

                    Recargar();

                    txtNombre.Text = "";
                    txtApPat.Text = "";
                    txtApMat.Text = "";
                    txtEmail.Text = "";
                    txtNumMat.Text = "";
                }
            }

        }
        //Elimina un alumno en la base de datos
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var idValor = dataGV_Alumno.SelectedRows[0].Cells[0].Value.ToString(); //Selecciona el valor de la columna "ID"
            if (idValor != null)
            {
                int id = int.Parse(idValor);
                AlumnosBL alBL = new AlumnosBL();
                alBL.BorrarAlumno(id);
                Recargar();
            }
        }

    }
}
