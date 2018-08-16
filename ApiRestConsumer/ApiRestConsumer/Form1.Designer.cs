namespace ApiRestConsumer
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsuario2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSaldo2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTelefono2 = new System.Windows.Forms.TextBox();
            this.txtEdad2 = new System.Windows.Forms.TextBox();
            this.txtNombre2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnPut = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtId2 = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnPut2 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.txtUsuario3 = new System.Windows.Forms.TextBox();
            this.txtEstado2 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnJsonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(708, 354);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(79, 541);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(202, 36);
            this.btnPost.TabIndex = 8;
            this.btnPost.Text = "PostSend";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.BtnPost_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(758, 44);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(152, 36);
            this.btnGet.TabIndex = 1;
            this.btnGet.Text = "GetSend";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.BtnGet_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(79, 377);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(202, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(79, 401);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(202, 20);
            this.txtEdad.TabIndex = 3;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(79, 428);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(202, 20);
            this.txtTelefono.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 384);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Edad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Telefono";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(79, 454);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(202, 20);
            this.txtSaldo.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Saldo";
            // 
            // txtMail
            // 
            this.txtMail.AutoSize = true;
            this.txtMail.Location = new System.Drawing.Point(21, 483);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(26, 13);
            this.txtMail.TabIndex = 22;
            this.txtMail.Text = "Mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(79, 480);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(202, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 509);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(79, 506);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(202, 20);
            this.txtUsuario.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(311, 530);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Usuario";
            // 
            // txtUsuario2
            // 
            this.txtUsuario2.Location = new System.Drawing.Point(369, 527);
            this.txtUsuario2.Name = "txtUsuario2";
            this.txtUsuario2.Size = new System.Drawing.Size(202, 20);
            this.txtUsuario2.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(311, 504);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Mail";
            // 
            // txtEmail2
            // 
            this.txtEmail2.Location = new System.Drawing.Point(369, 501);
            this.txtEmail2.Name = "txtEmail2";
            this.txtEmail2.Size = new System.Drawing.Size(202, 20);
            this.txtEmail2.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(311, 478);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Saldo";
            // 
            // txtSaldo2
            // 
            this.txtSaldo2.Location = new System.Drawing.Point(369, 475);
            this.txtSaldo2.Name = "txtSaldo2";
            this.txtSaldo2.Size = new System.Drawing.Size(202, 20);
            this.txtSaldo2.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(311, 455);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Telefono";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(311, 430);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Edad";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(311, 405);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Nombre";
            // 
            // txtTelefono2
            // 
            this.txtTelefono2.Location = new System.Drawing.Point(369, 449);
            this.txtTelefono2.Name = "txtTelefono2";
            this.txtTelefono2.Size = new System.Drawing.Size(202, 20);
            this.txtTelefono2.TabIndex = 12;
            // 
            // txtEdad2
            // 
            this.txtEdad2.Location = new System.Drawing.Point(369, 422);
            this.txtEdad2.Name = "txtEdad2";
            this.txtEdad2.Size = new System.Drawing.Size(202, 20);
            this.txtEdad2.TabIndex = 11;
            // 
            // txtNombre2
            // 
            this.txtNombre2.Location = new System.Drawing.Point(369, 398);
            this.txtNombre2.Name = "txtNombre2";
            this.txtNombre2.Size = new System.Drawing.Size(202, 20);
            this.txtNombre2.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(311, 379);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Id";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(369, 372);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(202, 20);
            this.txtId.TabIndex = 9;
            // 
            // btnPut
            // 
            this.btnPut.Location = new System.Drawing.Point(369, 594);
            this.btnPut.Name = "btnPut";
            this.btnPut.Size = new System.Drawing.Size(202, 36);
            this.btnPut.TabIndex = 17;
            this.btnPut.Text = "PutSend";
            this.btnPut.UseVisualStyleBackColor = true;
            this.btnPut.Click += new System.EventHandler(this.btnPut_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(311, 561);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Estado";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(369, 558);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(202, 20);
            this.txtEstado.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(577, 561);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(229, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Estado = { ACTIVO , INACTIVO, ELIMINADO }";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(577, 530);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(212, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Usuario = Nombre Empleado de la Empresa";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(580, 401);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(158, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "Nombre = Cliente de la Empresa";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(580, 475);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(359, 13);
            this.label17.TabIndex = 35;
            this.label17.Text = "Separador Decimal (,) de Miles(.) pero eso lo deben validar e la App Cliente";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(737, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(16, 13);
            this.label18.TabIndex = 37;
            this.label18.Text = "Id";
            // 
            // txtId2
            // 
            this.txtId2.Location = new System.Drawing.Point(737, 18);
            this.txtId2.Name = "txtId2";
            this.txtId2.Size = new System.Drawing.Size(202, 20);
            this.txtId2.TabIndex = 36;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(758, 151);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(152, 36);
            this.btnDelete.TabIndex = 38;
            this.btnDelete.Text = "DeleteSend";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(791, 93);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 13);
            this.label19.TabIndex = 39;
            this.label19.Text = "GET Id Opcional";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(774, 203);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(120, 13);
            this.label20.TabIndex = 40;
            this.label20.Text = "DELETE  Id  Obligatorio";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(737, 288);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 13);
            this.label21.TabIndex = 44;
            this.label21.Text = "Estado";
            // 
            // btnPut2
            // 
            this.btnPut2.Location = new System.Drawing.Point(737, 330);
            this.btnPut2.Name = "btnPut2";
            this.btnPut2.Size = new System.Drawing.Size(202, 36);
            this.btnPut2.TabIndex = 42;
            this.btnPut2.Text = "PutSend 2";
            this.btnPut2.UseVisualStyleBackColor = true;
            this.btnPut2.Click += new System.EventHandler(this.btnPut2_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(737, 247);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(43, 13);
            this.label22.TabIndex = 43;
            this.label22.Text = "Usuario";
            // 
            // txtUsuario3
            // 
            this.txtUsuario3.Location = new System.Drawing.Point(737, 263);
            this.txtUsuario3.Name = "txtUsuario3";
            this.txtUsuario3.Size = new System.Drawing.Size(202, 20);
            this.txtUsuario3.TabIndex = 41;
            // 
            // txtEstado2
            // 
            this.txtEstado2.Location = new System.Drawing.Point(740, 304);
            this.txtEstado2.Name = "txtEstado2";
            this.txtEstado2.Size = new System.Drawing.Size(202, 20);
            this.txtEstado2.TabIndex = 45;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(725, 372);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(229, 13);
            this.label23.TabIndex = 46;
            this.label23.Text = "Estado = { ACTIVO , INACTIVO, ELIMINADO }";
            // 
            // btnJsonSend
            // 
            this.btnJsonSend.Location = new System.Drawing.Point(79, 611);
            this.btnJsonSend.Name = "btnJsonSend";
            this.btnJsonSend.Size = new System.Drawing.Size(202, 36);
            this.btnJsonSend.TabIndex = 47;
            this.btnJsonSend.Text = "POST_JSON";
            this.btnJsonSend.UseVisualStyleBackColor = true;
            this.btnJsonSend.Click += new System.EventHandler(this.btnJsonSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 673);
            this.Controls.Add(this.btnJsonSend);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtEstado2);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnPut2);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtUsuario3);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtId2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.btnPut);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUsuario2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEmail2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSaldo2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTelefono2);
            this.Controls.Add(this.txtEdad2);
            this.Controls.Add(this.txtNombre2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtMail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUsuario2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmail2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSaldo2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTelefono2;
        private System.Windows.Forms.TextBox txtEdad2;
        private System.Windows.Forms.TextBox txtNombre2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnPut;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtId2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnPut2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtUsuario3;
        private System.Windows.Forms.TextBox txtEstado2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnJsonSend;
    }
}

