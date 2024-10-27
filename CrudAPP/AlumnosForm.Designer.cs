namespace CrudAPP
{
    partial class AlumnosForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            btnModificar = new Button();
            btnGuardar = new Button();
            txtNumMat = new TextBox();
            txtEmail = new TextBox();
            txtApMat = new TextBox();
            txtApPat = new TextBox();
            txtNombre = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            modificarToolStripMenuItem = new ToolStripMenuItem();
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            dataGV_Alumno = new DataGridView();
            groupBox1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGV_Alumno).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnModificar);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(txtNumMat);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtApMat);
            groupBox1.Controls.Add(txtApPat);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(403, 239);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ingreso de datos";
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(303, 100);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 29);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(303, 34);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtNumMat
            // 
            txtNumMat.Location = new Point(15, 189);
            txtNumMat.Name = "txtNumMat";
            txtNumMat.Size = new Size(205, 27);
            txtNumMat.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(67, 130);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(197, 27);
            txtEmail.TabIndex = 4;
            // 
            // txtApMat
            // 
            txtApMat.Location = new Point(147, 97);
            txtApMat.Name = "txtApMat";
            txtApMat.Size = new Size(139, 27);
            txtApMat.TabIndex = 3;
            // 
            // txtApPat
            // 
            txtApPat.Location = new Point(141, 64);
            txtApPat.Name = "txtApPat";
            txtApPat.Size = new Size(145, 27);
            txtApPat.TabIndex = 2;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(85, 31);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(167, 27);
            txtNombre.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 166);
            label5.Name = "label5";
            label5.Size = new Size(150, 20);
            label5.TabIndex = 0;
            label5.Text = "Número de Matrícula";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 133);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 0;
            label4.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 100);
            label3.Name = "label3";
            label3.Size = new Size(126, 20);
            label3.TabIndex = 0;
            label3.Text = "Apellido Materno";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 67);
            label2.Name = "label2";
            label2.Size = new Size(120, 20);
            label2.TabIndex = 0;
            label2.Text = "Apellido Paterno";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 34);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { modificarToolStripMenuItem, eliminarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(143, 52);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // modificarToolStripMenuItem
            // 
            modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            modificarToolStripMenuItem.Size = new Size(142, 24);
            modificarToolStripMenuItem.Text = "&Modificar";
            modificarToolStripMenuItem.Click += modificarToolStripMenuItem_Click;
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(142, 24);
            eliminarToolStripMenuItem.Text = "&Eliminar";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // dataGV_Alumno
            // 
            dataGV_Alumno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGV_Alumno.ContextMenuStrip = contextMenuStrip1;
            dataGV_Alumno.Location = new Point(12, 257);
            dataGV_Alumno.Name = "dataGV_Alumno";
            dataGV_Alumno.ReadOnly = true;
            dataGV_Alumno.RowHeadersWidth = 51;
            dataGV_Alumno.Size = new Size(403, 236);
            dataGV_Alumno.TabIndex = 2;
            // 
            // AlumnosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 537);
            Controls.Add(dataGV_Alumno);
            Controls.Add(groupBox1);
            Name = "AlumnosForm";
            Text = "Alumnos";
            Load += AlumnosForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGV_Alumno).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnGuardar;
        private TextBox txtNumMat;
        private TextBox txtEmail;
        private TextBox txtApMat;
        private TextBox txtApPat;
        private TextBox txtNombre;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnModificar;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem modificarToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private DataGridView dataGV_Alumno;
    }
}