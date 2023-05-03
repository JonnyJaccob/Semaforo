namespace PruebaSemaforo
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnSalir = new System.Windows.Forms.Button();
			this.btnInter = new System.Windows.Forms.Button();
			this.btnDetener = new System.Windows.Forms.Button();
			this.btnIniciar = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.rdbEVerde = new System.Windows.Forms.RadioButton();
			this.rdbEAmbar = new System.Windows.Forms.RadioButton();
			this.rdbERojo = new System.Windows.Forms.RadioButton();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.rdbWVerde = new System.Windows.Forms.RadioButton();
			this.rdbWAmbar = new System.Windows.Forms.RadioButton();
			this.rdbWRojo = new System.Windows.Forms.RadioButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.rdbSVerde = new System.Windows.Forms.RadioButton();
			this.rdbSAmbar = new System.Windows.Forms.RadioButton();
			this.rdbSRojo = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rdbNVerde = new System.Windows.Forms.RadioButton();
			this.rdbNAmbar = new System.Windows.Forms.RadioButton();
			this.rdbNRojo = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblContador = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.picSemaforoNorte = new System.Windows.Forms.PictureBox();
			this.picSemaforoEste = new System.Windows.Forms.PictureBox();
			this.picSemaforoSur = new System.Windows.Forms.PictureBox();
			this.picSemaforoOeste = new System.Windows.Forms.PictureBox();
			this.lblCrono = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picSemaforoNorte)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picSemaforoEste)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picSemaforoSur)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picSemaforoOeste)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.groupBox1.Controls.Add(this.btnSalir);
			this.groupBox1.Controls.Add(this.btnInter);
			this.groupBox1.Controls.Add(this.btnDetener);
			this.groupBox1.Controls.Add(this.btnIniciar);
			this.groupBox1.Location = new System.Drawing.Point(880, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(214, 725);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// btnSalir
			// 
			this.btnSalir.Location = new System.Drawing.Point(51, 168);
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(75, 23);
			this.btnSalir.TabIndex = 9;
			this.btnSalir.Text = "Salir";
			this.btnSalir.UseVisualStyleBackColor = true;
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// btnInter
			// 
			this.btnInter.Location = new System.Drawing.Point(51, 110);
			this.btnInter.Name = "btnInter";
			this.btnInter.Size = new System.Drawing.Size(75, 23);
			this.btnInter.TabIndex = 8;
			this.btnInter.Text = "Intermitente";
			this.btnInter.UseVisualStyleBackColor = true;
			this.btnInter.Click += new System.EventHandler(this.btnInter_Click);
			// 
			// btnDetener
			// 
			this.btnDetener.Location = new System.Drawing.Point(51, 67);
			this.btnDetener.Name = "btnDetener";
			this.btnDetener.Size = new System.Drawing.Size(75, 23);
			this.btnDetener.TabIndex = 7;
			this.btnDetener.Text = "Detener";
			this.btnDetener.UseVisualStyleBackColor = true;
			this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
			// 
			// btnIniciar
			// 
			this.btnIniciar.Location = new System.Drawing.Point(51, 19);
			this.btnIniciar.Name = "btnIniciar";
			this.btnIniciar.Size = new System.Drawing.Size(75, 23);
			this.btnIniciar.TabIndex = 6;
			this.btnIniciar.Text = "Iniciar";
			this.btnIniciar.UseVisualStyleBackColor = true;
			this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.rdbEVerde);
			this.groupBox6.Controls.Add(this.rdbEAmbar);
			this.groupBox6.Controls.Add(this.rdbERojo);
			this.groupBox6.Location = new System.Drawing.Point(749, 341);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(79, 90);
			this.groupBox6.TabIndex = 5;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Este";
			this.groupBox6.Visible = false;
			// 
			// rdbEVerde
			// 
			this.rdbEVerde.AutoSize = true;
			this.rdbEVerde.Location = new System.Drawing.Point(7, 66);
			this.rdbEVerde.Name = "rdbEVerde";
			this.rdbEVerde.Size = new System.Drawing.Size(53, 17);
			this.rdbEVerde.TabIndex = 2;
			this.rdbEVerde.TabStop = true;
			this.rdbEVerde.Text = "Verde";
			this.rdbEVerde.UseVisualStyleBackColor = true;
			// 
			// rdbEAmbar
			// 
			this.rdbEAmbar.AutoSize = true;
			this.rdbEAmbar.Location = new System.Drawing.Point(7, 43);
			this.rdbEAmbar.Name = "rdbEAmbar";
			this.rdbEAmbar.Size = new System.Drawing.Size(55, 17);
			this.rdbEAmbar.TabIndex = 1;
			this.rdbEAmbar.TabStop = true;
			this.rdbEAmbar.Text = "Ambar";
			this.rdbEAmbar.UseVisualStyleBackColor = true;
			// 
			// rdbERojo
			// 
			this.rdbERojo.AutoSize = true;
			this.rdbERojo.Location = new System.Drawing.Point(7, 19);
			this.rdbERojo.Name = "rdbERojo";
			this.rdbERojo.Size = new System.Drawing.Size(47, 17);
			this.rdbERojo.TabIndex = 0;
			this.rdbERojo.TabStop = true;
			this.rdbERojo.Text = "Rojo";
			this.rdbERojo.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.rdbWVerde);
			this.groupBox5.Controls.Add(this.rdbWAmbar);
			this.groupBox5.Controls.Add(this.rdbWRojo);
			this.groupBox5.Location = new System.Drawing.Point(36, 321);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(79, 90);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Oeste";
			this.groupBox5.Visible = false;
			// 
			// rdbWVerde
			// 
			this.rdbWVerde.AutoSize = true;
			this.rdbWVerde.Location = new System.Drawing.Point(7, 20);
			this.rdbWVerde.Name = "rdbWVerde";
			this.rdbWVerde.Size = new System.Drawing.Size(53, 17);
			this.rdbWVerde.TabIndex = 2;
			this.rdbWVerde.TabStop = true;
			this.rdbWVerde.Text = "Verde";
			this.rdbWVerde.UseVisualStyleBackColor = true;
			// 
			// rdbWAmbar
			// 
			this.rdbWAmbar.AutoSize = true;
			this.rdbWAmbar.Location = new System.Drawing.Point(7, 43);
			this.rdbWAmbar.Name = "rdbWAmbar";
			this.rdbWAmbar.Size = new System.Drawing.Size(55, 17);
			this.rdbWAmbar.TabIndex = 1;
			this.rdbWAmbar.TabStop = true;
			this.rdbWAmbar.Text = "Ambar";
			this.rdbWAmbar.UseVisualStyleBackColor = true;
			// 
			// rdbWRojo
			// 
			this.rdbWRojo.AutoSize = true;
			this.rdbWRojo.Location = new System.Drawing.Point(7, 66);
			this.rdbWRojo.Name = "rdbWRojo";
			this.rdbWRojo.Size = new System.Drawing.Size(47, 17);
			this.rdbWRojo.TabIndex = 0;
			this.rdbWRojo.TabStop = true;
			this.rdbWRojo.Text = "Rojo";
			this.rdbWRojo.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.rdbSVerde);
			this.groupBox4.Controls.Add(this.rdbSAmbar);
			this.groupBox4.Controls.Add(this.rdbSRojo);
			this.groupBox4.Location = new System.Drawing.Point(351, 630);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(199, 47);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Sur";
			this.groupBox4.Visible = false;
			// 
			// rdbSVerde
			// 
			this.rdbSVerde.AutoSize = true;
			this.rdbSVerde.Location = new System.Drawing.Point(7, 19);
			this.rdbSVerde.Name = "rdbSVerde";
			this.rdbSVerde.Size = new System.Drawing.Size(53, 17);
			this.rdbSVerde.TabIndex = 2;
			this.rdbSVerde.Text = "Verde";
			this.rdbSVerde.UseVisualStyleBackColor = true;
			// 
			// rdbSAmbar
			// 
			this.rdbSAmbar.AutoSize = true;
			this.rdbSAmbar.Location = new System.Drawing.Point(67, 19);
			this.rdbSAmbar.Name = "rdbSAmbar";
			this.rdbSAmbar.Size = new System.Drawing.Size(55, 17);
			this.rdbSAmbar.TabIndex = 1;
			this.rdbSAmbar.TabStop = true;
			this.rdbSAmbar.Text = "Ambar";
			this.rdbSAmbar.UseVisualStyleBackColor = true;
			// 
			// rdbSRojo
			// 
			this.rdbSRojo.AutoSize = true;
			this.rdbSRojo.Location = new System.Drawing.Point(128, 19);
			this.rdbSRojo.Name = "rdbSRojo";
			this.rdbSRojo.Size = new System.Drawing.Size(47, 17);
			this.rdbSRojo.TabIndex = 0;
			this.rdbSRojo.TabStop = true;
			this.rdbSRojo.Text = "Rojo";
			this.rdbSRojo.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.rdbNVerde);
			this.groupBox3.Controls.Add(this.rdbNAmbar);
			this.groupBox3.Controls.Add(this.rdbNRojo);
			this.groupBox3.Location = new System.Drawing.Point(519, 31);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(199, 47);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Norte";
			this.groupBox3.Visible = false;
			// 
			// rdbNVerde
			// 
			this.rdbNVerde.AutoSize = true;
			this.rdbNVerde.Location = new System.Drawing.Point(122, 20);
			this.rdbNVerde.Name = "rdbNVerde";
			this.rdbNVerde.Size = new System.Drawing.Size(53, 17);
			this.rdbNVerde.TabIndex = 2;
			this.rdbNVerde.Text = "Verde";
			this.rdbNVerde.UseVisualStyleBackColor = true;
			// 
			// rdbNAmbar
			// 
			this.rdbNAmbar.AutoSize = true;
			this.rdbNAmbar.Location = new System.Drawing.Point(60, 20);
			this.rdbNAmbar.Name = "rdbNAmbar";
			this.rdbNAmbar.Size = new System.Drawing.Size(55, 17);
			this.rdbNAmbar.TabIndex = 1;
			this.rdbNAmbar.TabStop = true;
			this.rdbNAmbar.Text = "Ambar";
			this.rdbNAmbar.UseVisualStyleBackColor = true;
			// 
			// rdbNRojo
			// 
			this.rdbNRojo.AutoSize = true;
			this.rdbNRojo.Location = new System.Drawing.Point(7, 20);
			this.rdbNRojo.Name = "rdbNRojo";
			this.rdbNRojo.Size = new System.Drawing.Size(47, 17);
			this.rdbNRojo.TabIndex = 0;
			this.rdbNRojo.TabStop = true;
			this.rdbNRojo.Text = "Rojo";
			this.rdbNRojo.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.White;
			this.groupBox2.Location = new System.Drawing.Point(589, 271);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(79, 88);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Visible = false;
			// 
			// lblContador
			// 
			this.lblContador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblContador.AutoSize = true;
			this.lblContador.BackColor = System.Drawing.SystemColors.GrayText;
			this.lblContador.Font = new System.Drawing.Font("Algerian", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblContador.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblContador.Location = new System.Drawing.Point(409, 341);
			this.lblContador.Name = "lblContador";
			this.lblContador.Size = new System.Drawing.Size(57, 60);
			this.lblContador.TabIndex = 0;
			this.lblContador.Text = "0";
			this.lblContador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::PruebaSemaforo.Properties.Resources.calleelazar;
			this.pictureBox1.Location = new System.Drawing.Point(13, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(861, 725);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// picSemaforoNorte
			// 
			this.picSemaforoNorte.Image = global::PruebaSemaforo.Properties.Resources.SemaforoApag1_2;
			this.picSemaforoNorte.InitialImage = global::PruebaSemaforo.Properties.Resources.SemaforoApag1_1;
			this.picSemaforoNorte.Location = new System.Drawing.Point(466, 271);
			this.picSemaforoNorte.Name = "picSemaforoNorte";
			this.picSemaforoNorte.Size = new System.Drawing.Size(56, 41);
			this.picSemaforoNorte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picSemaforoNorte.TabIndex = 6;
			this.picSemaforoNorte.TabStop = false;
			// 
			// picSemaforoEste
			// 
			this.picSemaforoEste.Image = global::PruebaSemaforo.Properties.Resources.SemaforoApag1_2;
			this.picSemaforoEste.InitialImage = global::PruebaSemaforo.Properties.Resources.SemaforoApag1_1;
			this.picSemaforoEste.Location = new System.Drawing.Point(509, 375);
			this.picSemaforoEste.Name = "picSemaforoEste";
			this.picSemaforoEste.Size = new System.Drawing.Size(41, 56);
			this.picSemaforoEste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picSemaforoEste.TabIndex = 7;
			this.picSemaforoEste.TabStop = false;
			// 
			// picSemaforoSur
			// 
			this.picSemaforoSur.Image = global::PruebaSemaforo.Properties.Resources.SemaforoApag1_2;
			this.picSemaforoSur.InitialImage = global::PruebaSemaforo.Properties.Resources.SemaforoApag1_1;
			this.picSemaforoSur.Location = new System.Drawing.Point(391, 433);
			this.picSemaforoSur.Name = "picSemaforoSur";
			this.picSemaforoSur.Size = new System.Drawing.Size(56, 41);
			this.picSemaforoSur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picSemaforoSur.TabIndex = 8;
			this.picSemaforoSur.TabStop = false;
			// 
			// picSemaforoOeste
			// 
			this.picSemaforoOeste.Image = global::PruebaSemaforo.Properties.Resources.SemaforoApag1_2;
			this.picSemaforoOeste.InitialImage = global::PruebaSemaforo.Properties.Resources.SemaforoApag1_1;
			this.picSemaforoOeste.Location = new System.Drawing.Point(325, 302);
			this.picSemaforoOeste.Name = "picSemaforoOeste";
			this.picSemaforoOeste.Size = new System.Drawing.Size(41, 56);
			this.picSemaforoOeste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picSemaforoOeste.TabIndex = 9;
			this.picSemaforoOeste.TabStop = false;
			// 
			// lblCrono
			// 
			this.lblCrono.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCrono.AutoSize = true;
			this.lblCrono.BackColor = System.Drawing.SystemColors.Desktop;
			this.lblCrono.Font = new System.Drawing.Font("Algerian", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCrono.ForeColor = System.Drawing.Color.Red;
			this.lblCrono.Location = new System.Drawing.Point(138, 213);
			this.lblCrono.Name = "lblCrono";
			this.lblCrono.Size = new System.Drawing.Size(245, 60);
			this.lblCrono.TabIndex = 10;
			this.lblCrono.Text = "00:00.00";
			this.lblCrono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1122, 749);
			this.Controls.Add(this.lblCrono);
			this.Controls.Add(this.lblContador);
			this.Controls.Add(this.picSemaforoOeste);
			this.Controls.Add(this.picSemaforoSur);
			this.Controls.Add(this.picSemaforoEste);
			this.Controls.Add(this.picSemaforoNorte);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picSemaforoNorte)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picSemaforoEste)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picSemaforoSur)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picSemaforoOeste)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSalir;
		private System.Windows.Forms.Button btnInter;
		private System.Windows.Forms.Button btnDetener;
		private System.Windows.Forms.Button btnIniciar;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.RadioButton rdbEVerde;
		private System.Windows.Forms.RadioButton rdbEAmbar;
		private System.Windows.Forms.RadioButton rdbERojo;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.RadioButton rdbWVerde;
		private System.Windows.Forms.RadioButton rdbWAmbar;
		private System.Windows.Forms.RadioButton rdbWRojo;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RadioButton rdbSVerde;
		private System.Windows.Forms.RadioButton rdbSAmbar;
		private System.Windows.Forms.RadioButton rdbSRojo;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rdbNVerde;
		private System.Windows.Forms.RadioButton rdbNAmbar;
		private System.Windows.Forms.RadioButton rdbNRojo;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblContador;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox picSemaforoNorte;
		private System.Windows.Forms.PictureBox picSemaforoEste;
		private System.Windows.Forms.PictureBox picSemaforoSur;
		private System.Windows.Forms.PictureBox picSemaforoOeste;
		private System.Windows.Forms.Label lblCrono;
	}
}

