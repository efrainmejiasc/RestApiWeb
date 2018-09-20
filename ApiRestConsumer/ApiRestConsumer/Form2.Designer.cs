namespace ApiRestConsumer
{
    partial class Form2
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
            this.BtnIniciarSync = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnFinalizarSync = new System.Windows.Forms.Button();
            this.BtnPrimerSync = new System.Windows.Forms.Button();
            this.BtnPosterioresSync = new System.Windows.Forms.Button();
            this.BtnNuevoProductor = new System.Windows.Forms.Button();
            this.picImagenEmpleado = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImagenEmpleado)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnIniciarSync
            // 
            this.BtnIniciarSync.Location = new System.Drawing.Point(12, 371);
            this.BtnIniciarSync.Name = "BtnIniciarSync";
            this.BtnIniciarSync.Size = new System.Drawing.Size(163, 23);
            this.BtnIniciarSync.TabIndex = 0;
            this.BtnIniciarSync.Text = "IniciarSync";
            this.BtnIniciarSync.UseVisualStyleBackColor = true;
            this.BtnIniciarSync.Click += new System.EventHandler(this.BtnIniciarSync_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(-2, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1046, 333);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "SINCRONIZACION DE DATOS";
            // 
            // BtnFinalizarSync
            // 
            this.BtnFinalizarSync.Location = new System.Drawing.Point(12, 458);
            this.BtnFinalizarSync.Name = "BtnFinalizarSync";
            this.BtnFinalizarSync.Size = new System.Drawing.Size(163, 23);
            this.BtnFinalizarSync.TabIndex = 3;
            this.BtnFinalizarSync.Text = "FinalizarSync";
            this.BtnFinalizarSync.UseVisualStyleBackColor = true;
            this.BtnFinalizarSync.Click += new System.EventHandler(this.BtnFinalizarSync_Click);
            // 
            // BtnPrimerSync
            // 
            this.BtnPrimerSync.Location = new System.Drawing.Point(12, 400);
            this.BtnPrimerSync.Name = "BtnPrimerSync";
            this.BtnPrimerSync.Size = new System.Drawing.Size(163, 23);
            this.BtnPrimerSync.TabIndex = 4;
            this.BtnPrimerSync.Text = "PrimeraSync";
            this.BtnPrimerSync.UseVisualStyleBackColor = true;
            this.BtnPrimerSync.Click += new System.EventHandler(this.BtnPrimerSync_Click);
            // 
            // BtnPosterioresSync
            // 
            this.BtnPosterioresSync.Location = new System.Drawing.Point(12, 429);
            this.BtnPosterioresSync.Name = "BtnPosterioresSync";
            this.BtnPosterioresSync.Size = new System.Drawing.Size(163, 23);
            this.BtnPosterioresSync.TabIndex = 5;
            this.BtnPosterioresSync.Text = "PosterioresSync";
            this.BtnPosterioresSync.UseVisualStyleBackColor = true;
            this.BtnPosterioresSync.Click += new System.EventHandler(this.BtnPosterioresSync_Click);
            // 
            // BtnNuevoProductor
            // 
            this.BtnNuevoProductor.Location = new System.Drawing.Point(464, 371);
            this.BtnNuevoProductor.Name = "BtnNuevoProductor";
            this.BtnNuevoProductor.Size = new System.Drawing.Size(163, 23);
            this.BtnNuevoProductor.TabIndex = 6;
            this.BtnNuevoProductor.Text = "Nuevo Productor ";
            this.BtnNuevoProductor.UseVisualStyleBackColor = true;
            this.BtnNuevoProductor.Click += new System.EventHandler(this.BtnNuevoProductor_Click);
            // 
            // picImagenEmpleado
            // 
            this.picImagenEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picImagenEmpleado.Location = new System.Drawing.Point(862, 344);
            this.picImagenEmpleado.Name = "picImagenEmpleado";
            this.picImagenEmpleado.Size = new System.Drawing.Size(154, 123);
            this.picImagenEmpleado.TabIndex = 7;
            this.picImagenEmpleado.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 496);
            this.Controls.Add(this.picImagenEmpleado);
            this.Controls.Add(this.BtnNuevoProductor);
            this.Controls.Add(this.BtnPosterioresSync);
            this.Controls.Add(this.BtnPrimerSync);
            this.Controls.Add(this.BtnFinalizarSync);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.BtnIniciarSync);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FloraNueva_RestFullApi";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImagenEmpleado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnIniciarSync;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnFinalizarSync;
        private System.Windows.Forms.Button BtnPrimerSync;
        private System.Windows.Forms.Button BtnPosterioresSync;
        private System.Windows.Forms.Button BtnNuevoProductor;
        private System.Windows.Forms.PictureBox picImagenEmpleado;
    }
}