using CrudBL;
using CrudBOL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudAPP
{
    public partial class AsignaturasForm : Form
    {
        public AsignaturasForm()
        {
            InitializeComponent();
        }
        //Actualiza el contenido del DataGridView
        void Recargar()
        {
            AsignaturasBL asBL = new AsignaturasBL();
            List<AsignaturaBOL> lista = asBL.list();
            dataGV_Asignaturas.DataSource = null;//Limpia DataSource anterior
            dataGV_Asignaturas.DataSource = lista;//Asigna la lista como Datasource
        }
        //Método para dar formato al dataGV
        void formatDGV()
        {
            dataGV_Asignaturas.AutoGenerateColumns = false; //Prohibe la generación automática de columnas
            dataGV_Asignaturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //Selecciona la fila completa
            dataGV_Asignaturas.AllowUserToAddRows = false; //Prohibe que el usuario agregue filas

            dataGV_Asignaturas.Columns.Clear(); //Limpia columnas existentes

            //Crea las columnas y las conecta con la propiedad del datasource
            dataGV_Asignaturas.ColumnCount = 3;
            dataGV_Asignaturas.Columns[0].Name = "ID";
            dataGV_Asignaturas.Columns[0].DataPropertyName = "CodigoAsignatura";
            dataGV_Asignaturas.Columns[1].Name = "Nombre asignatura";
            dataGV_Asignaturas.Columns[1].DataPropertyName = "NombreAsignatura";
            dataGV_Asignaturas.Columns[2].Name = "Creditos";
            dataGV_Asignaturas.Columns[2].DataPropertyName = "Creditos";
        }
        //Al cargar el form crea las columnas del dataGridView
        private void AsignaturasForm_Load(object sender, EventArgs e)
        {
            formatDGV();
            foreach (DataGridViewColumn column in dataGV_Asignaturas.Columns)
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
            if (dataGV_Asignaturas.SelectedRows.Count == 0)
                contextMenuStrip1.Enabled = false;
            else
                contextMenuStrip1.Enabled = true;
        }
        //Valida que los campos de texto no estén vacíos
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
        //Valida todos los campos del formulario
        public bool ValidarForm()
        {
            if (!ValidarTxtVacio(txtNombreAs, "Nombre de Asignatura no puede estar vacío.") ||
                !ValidarTxtVacio(txtCreditos, "Creditos no pueden estar vacíos."))
            {
                return false;
            }
            if (!int.TryParse(txtCreditos.Text, out int creds))
            {
                MessageBox.Show("Los créditos deben ser un número.");
                txtCreditos.Focus();
                return false;
            }
            return true;
        }
        //Almacena la asignatura en la base de datos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Si los campos son correctos, se podrá almacenar la asignatura en la base de datos
            if (ValidarForm())
            {
                AsignaturaBOL asBOL = new AsignaturaBOL();
                asBOL.NombreAsignatura = txtNombreAs.Text;
                asBOL.Creditos = int.Parse(txtCreditos.Text);

                AsignaturasBL asBL = new AsignaturasBL();
                int count = asBL.ContAsignatura(asBOL);
                if (count == 0)
                {
                    bool result = asBL.GuardarAsignatura(asBOL);
                    if (result)
                        MessageBox.Show("Asignatura almacenada correctamente");
                    else
                        MessageBox.Show("No se pudo almacenar la asignatura");
                }
                else
                    MessageBox.Show("La asignatura ya se encuentra en la base de datos");
                Recargar();
                txtNombreAs.Text = "";
                txtCreditos.Text = "";
            }
        }
        //Permite seleccionar una asignatura para poder modificar sus datos después
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var idValor = dataGV_Asignaturas.SelectedRows[0].Cells[0].Value.ToString(); //Selecciona el valor de la columna "ID"
            if (idValor != null)
            {
                int id = int.Parse(idValor);
                if (id != 0)
                {
                    AsignaturasBL asBL = new AsignaturasBL();
                    AsignaturaBOL asBOL = asBL.SelectAsignatura(id);
                    txtNombreAs.Text = asBOL.NombreAsignatura;
                    txtCreditos.Text = asBOL.Creditos.ToString();
                }
                else
                    MessageBox.Show("No se seleccionó una asignatura");
            }
        }
        //Modifica la asignatura seleccionada en la base de datos
        private void btnModificar_Click(object sender, EventArgs e)
        {
            var idValor = dataGV_Asignaturas.SelectedRows[0].Cells[0].Value.ToString(); //Selecciona el valor de la columna "ID"
            if (idValor != null)
            {
                int id = int.Parse(idValor);
                AsignaturasBL asBL = new AsignaturasBL();
                //Si los campos son correctos, se podrá modificar la asignatura
                if (ValidarForm())
                {
                    AsignaturaBOL asBOL = new AsignaturaBOL();
                    asBOL.NombreAsignatura = txtNombreAs.Text;
                    asBOL.Creditos = int.Parse(txtCreditos.Text);

                    bool result = asBL.ModificarAsignatura(asBOL, id);
                    if (result)
                        MessageBox.Show("Asignatura modificada correctamente");
                    else
                        MessageBox.Show("No se pudo modificar la asignatura");
                    Recargar();
                    txtNombreAs.Text = "";
                    txtCreditos.Text = "";
                }
            }
        }
        //Elimina la asignatura en la base de datos
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var idValor = dataGV_Asignaturas.SelectedRows[0].Cells[0].Value.ToString(); //Selecciona el valor de la columna "ID"
            if (idValor != null)
            {
                int id = int.Parse(idValor);
                AsignaturasBL asBL = new AsignaturasBL();
                asBL.BorrarAsignatura(id);
                Recargar();
            }
        }
    }
}
