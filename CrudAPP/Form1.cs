namespace CrudAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formAlumno in Application.OpenForms)
            {
                if (formAlumno is AlumnosForm)
                {
                    formAlumno.Activate();
                    return;
                }
            }
            AlumnosForm alumnosForm = new AlumnosForm();
            alumnosForm.MdiParent = this;
            alumnosForm.Dock = DockStyle.Fill;
            alumnosForm.Show();
            alumnosForm.WindowState = FormWindowState.Maximized;
        }

        private void asignaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formAsignatura in Application.OpenForms)
            {
                if(formAsignatura is AsignaturasForm)
                {
                    formAsignatura.Activate(); 
                    return;
                }
            }
            AsignaturasForm asignaturasForm = new AsignaturasForm();
            asignaturasForm.MdiParent = this;
            asignaturasForm.Dock = DockStyle.Fill;
            asignaturasForm.Show();
            asignaturasForm.WindowState = FormWindowState.Maximized;
        }
    }
}
