using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace PruebaSemaforo
{
	public partial class Form1 : Form
	{
		[DllImport("gdi32.dll")]

		//Funcion de la DLL externa
		private static extern IntPtr AddFontMemResourceEx(IntPtr pFileView, uint cjSize, IntPtr pvResrved, [In] ref uint pNumFonts);

		public Form1()
		{
			InitializeComponent();
			// Inicializar el temporizador
			timer.Interval = 500;
			timer.Tick += new EventHandler(Timer_Tick);

			//Cargar fuente personalizada
			Font fuente_DS_DIGI = new Font(CargarFuente(Properties.Resources.DS_DIGI), 27, FontStyle.Regular);
			Font fuente_DS_DIGIB = new Font(CargarFuente(Properties.Resources.DS_DIGIB), 27, FontStyle.Regular);
			Font fuente_DS_DIGII = new Font(CargarFuente(Properties.Resources.DS_DIGII), 27, FontStyle.Regular);
			Font fuente_DS_DIGIT = new Font(CargarFuente(Properties.Resources.DS_DIGIT), 40, FontStyle.Regular);

			lblContador.Font = fuente_DS_DIGIT;

			//pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
			picSemaforoNorte.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
			picSemaforoSur.Image.RotateFlip(RotateFlipType.Rotate270FlipX);
			picSemaforoOeste.Image.RotateFlip(RotateFlipType.Rotate180FlipX);

			groupBox2.BackColor = fondo;
			lblContador.BackColor = fondo;
			lblContador.ForeColor = fondo;
		}
		static Timer timer = new Timer(); // Declarar un temporizador para contar los segundos
		static double segundos = 0; // Declarar la variable para el contador de segundos
		private static Color verde = Semaforo.verde;
		private static Color amarillo = Semaforo.amarillo;
		private static Color rojo = Semaforo.rojo;
		private static Color fondo = Semaforo.fondo;
		private static string imagenNormal = @"C:\Users\jacco\OneDrive\Documentos\Repositorios\SemaforoEleazar\PruebaSemaforo\Resources\SemaforoApag1_2.png";
		private static string imagenVerde = @"C:\Users\jacco\OneDrive\Documentos\Repositorios\SemaforoEleazar\PruebaSemaforo\Resources\SemaforoVerde1.png";
		private static string imagenAmbar = @"C:\Users\jacco\OneDrive\Documentos\Repositorios\SemaforoEleazar\PruebaSemaforo\Resources\SemaforoAmarillo1.png";
		private static string imagenRojo = @"C:\Users\jacco\OneDrive\Documentos\Repositorios\SemaforoEleazar\PruebaSemaforo\Resources\SemaforoRojo1.png";

		private void btnSalir_Click(object sender, EventArgs e)
		{
			Application.ExitThread();
			Application.Exit();
		}
		private void FormatoContador(string valor, Color color)
		{
			if(valor.Length > 1)
			{
				lblContador.Text = valor;
			}else
			{
				lblContador.Text = "0" + valor;
			}
			lblContador.ForeColor = color;
		}
		Semaforo semaforo;
		private void Iniciar()
		{
			timer.Start(); // Iniciar el temporizador
			segundos = 1; // Reiniciar el contador de segundos
			fase = 1;
			semaforo = new Semaforo();
			FormatoContador("0",verde); // Actualizar la etiqueta con el valor inicial
		}

		private void btnIniciar_Click(object sender, EventArgs e)
		{
			// Activar la variable de detener para salir del bucle
			_detener = true;

			Iniciar();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// Inicializar el temporizador
			//timer.Interval = 1000;
			//timer.Tick += new EventHandler(Timer_Tick);
		}
		int fase;
		// Función que se ejecuta cada segundo
		private void Timer_Tick(object sender, EventArgs e)
		{
			segundos += 0.5; // Incrementar el contador de segundos

			int valor = 1;
			try
			{
				valor = semaforo.SemaforoTiempo(segundos);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			if (semaforo.Fase != fase)
			{
				fase = semaforo.Fase;
				ApagarSemaforos(semaforo.blnNorte_Sur);
				timer.Stop();
				segundos = 1;
				timer.Start();
			}
			if(semaforo.blnNorte_Sur)
			{
				rdbERojo.Checked = rdbWRojo.Checked = true;

				picSemaforoEste.Image = Image.FromFile(imagenRojo);
				picSemaforoOeste.Image = Image.FromFile(imagenRojo);
			}
			else
			{
				rdbNRojo.Checked = rdbSRojo.Checked = true;

				picSemaforoEste.Image = Image.FromFile(imagenRojo);
				picSemaforoOeste.Image = Image.FromFile(imagenRojo);
			}
			switch (semaforo.Fase)
			{
				case 1 when semaforo.blnNorte_Sur:
					picSemaforoNorte.Image = Image.FromFile(imagenVerde);
					picSemaforoSur.Image = Image.FromFile(imagenVerde);
					rdbNVerde.Checked = true;
					rdbSVerde.Checked = true;
					rdbNAmbar.Checked = rdbNRojo.Checked = false;
					rdbSAmbar.Checked = rdbSRojo.Checked = false;
					rdbERojo.Checked = rdbWRojo.Checked = true;
					break;
				case 2 when semaforo.blnNorte_Sur:
					if (semaforo.colorLetrero != fondo)
					{
						rdbNVerde.Checked = rdbSVerde.Checked = true;
						picSemaforoNorte.Image = Image.FromFile(imagenVerde);
						picSemaforoSur.Image = Image.FromFile(imagenVerde);
					}
					else
					{
						picSemaforoNorte.Image = Image.FromFile(imagenNormal);
						picSemaforoSur.Image = Image.FromFile(imagenNormal);
						rdbNVerde.Checked = rdbSVerde.Checked = false;
					}
					rdbNAmbar.Checked = rdbSAmbar.Checked = false;
					rdbNRojo.Checked = rdbSRojo.Checked = false;
					rdbERojo.Checked = rdbWRojo.Checked = true;
					break;
				case 3 when semaforo.blnNorte_Sur:
					picSemaforoNorte.Image = Image.FromFile(imagenAmbar);
					picSemaforoSur.Image = Image.FromFile(imagenAmbar);
					rdbNVerde.Checked = rdbSVerde.Checked = false;
					rdbNAmbar.Checked = rdbSAmbar.Checked = true;
					rdbNRojo.Checked = rdbSRojo.Checked = false;
					break;
				case 4 when semaforo.blnNorte_Sur:
					picSemaforoNorte.Image = Image.FromFile(imagenRojo);
					picSemaforoSur.Image = Image.FromFile(imagenRojo);
					rdbNVerde.Checked = rdbSVerde.Checked = false;
					rdbNAmbar.Checked = rdbSAmbar.Checked = false;
					rdbNRojo.Checked = rdbSRojo.Checked = true;
					break;
				case 1 when semaforo.blnEste_Oeste:
					picSemaforoEste.Image = Image.FromFile(imagenVerde);
					picSemaforoOeste.Image = Image.FromFile(imagenVerde);
					rdbEVerde.Checked = true;
					rdbWVerde.Checked = true;
					rdbEAmbar.Checked = rdbERojo.Checked = false;
					rdbWAmbar.Checked = rdbWRojo.Checked = false;
					break;
				case 2 when semaforo.blnEste_Oeste:
					if (semaforo.colorLetrero != fondo)
					{
						rdbEVerde.Checked = rdbWVerde.Checked = true;
						picSemaforoEste.Image = Image.FromFile(imagenVerde);
						picSemaforoOeste.Image = Image.FromFile(imagenVerde);
					}
					else
					{
						rdbEVerde.Checked = rdbWVerde.Checked = false;
						picSemaforoEste.Image = Image.FromFile(imagenNormal);
						picSemaforoOeste.Image = Image.FromFile(imagenNormal);
					}
					rdbEAmbar.Checked = rdbWAmbar.Checked = false;
					rdbERojo.Checked = rdbWRojo.Checked = false;
					break;
				case 3 when semaforo.blnEste_Oeste:
					picSemaforoEste.Image = Image.FromFile(imagenAmbar);
					picSemaforoOeste.Image = Image.FromFile(imagenAmbar);
					rdbEVerde.Checked = rdbWVerde.Checked = false;
					rdbEAmbar.Checked = rdbWAmbar.Checked = true;
					rdbERojo.Checked = rdbWRojo.Checked = false;
					break;
				case 4 when semaforo.blnEste_Oeste:
					picSemaforoEste.Image = Image.FromFile(imagenRojo);
					picSemaforoOeste.Image = Image.FromFile(imagenRojo);
					rdbEVerde.Checked = rdbWVerde.Checked = false;
					rdbEAmbar.Checked = rdbWAmbar.Checked = false;
					rdbERojo.Checked = rdbWRojo.Checked = true;
					break;
				default:
					break;
			}
			FormatoContador(valor.ToString(), semaforo.colorLetrero); // Actualizar la etiqueta con el nuevo valor
			picSemaforoNorte.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
			picSemaforoSur.Image.RotateFlip(RotateFlipType.Rotate270FlipX);
			picSemaforoOeste.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
		}

		private void btnDetener_Click(object sender, EventArgs e)
		{
			// Activar la variable de detener para salir del bucle
			_detener = true;
			timer.Stop(); // Detener el temporizador
			groupBox2.BackColor = fondo;
			lblContador.BackColor = fondo;
			lblContador.ForeColor = fondo;
			picSemaforoNorte.Image = Image.FromFile(imagenNormal);
			picSemaforoSur.Image = Image.FromFile(imagenNormal);
			picSemaforoEste.Image = Image.FromFile(imagenNormal);
			picSemaforoOeste.Image = Image.FromFile(imagenNormal);
			picSemaforoNorte.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
			picSemaforoSur.Image.RotateFlip(RotateFlipType.Rotate270FlipX);
			picSemaforoOeste.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
		}
		private FontFamily CargarFuente(byte[] fuente)
		{
			FontFamily fuenteNueva;

			//Asignar memoria y copiar bytes
			IntPtr data = Marshal.AllocCoTaskMem(fuente.Length);
			Marshal.Copy(fuente, 0, data, fuente.Length);

			uint cFonts = 0;
			AddFontMemResourceEx(data, (uint)fuente.Length, IntPtr.Zero, ref cFonts);

			PrivateFontCollection fontCollection = new PrivateFontCollection();

			//Pasar fuente a PrivateFontCollection
			fontCollection.AddMemoryFont(data, fuente.Length);

			//Liberar memoria
			Marshal.FreeCoTaskMem(data);

			fuenteNueva = fontCollection.Families[0];

			return fuenteNueva;
		}
		private void ApagarSemaforos(bool IsBlnNorte_Sur)
		{
			if(!IsBlnNorte_Sur)
			{
				rdbNVerde.Checked = false;
				rdbNAmbar.Checked = false;
				rdbNRojo.Checked = false;
				rdbSVerde.Checked = false;
				rdbSAmbar.Checked = false;
				rdbSRojo.Checked = false;
			}
			else
			{
				rdbEVerde.Checked = false;
				rdbEAmbar.Checked = false;
				rdbERojo.Checked = false;
				rdbWVerde.Checked = false;
				rdbWAmbar.Checked = false;
				rdbWRojo.Checked = false;
			}
		}
		private bool _detener = false;
		int x = 1;
		
		private Timer _timer;
		private void btnInter_Click(object sender, EventArgs e)
		{
			timer.Stop();
			// Reiniciar variable de detener
			_detener = false;

			// Crear y configurar el temporizador
			_timer = new Timer();
			_timer.Interval = 1000; // 1000 ms = 1 segundo
			_timer.Tick += Timer_Tick1; // Asignar el manejador de eventos
			_timer.Start(); // Iniciar el temporizador
		}
		private void Timer_Tick1(object sender, EventArgs e)
		{
			// Aquí va el código a repetir
			if (x == 1)
			{
				x = 2;
				lblContador.Text = "00";
				lblContador.ForeColor = amarillo;
				
				rdbNAmbar.Checked =
				rdbSAmbar.Checked =
				rdbEAmbar.Checked =
				rdbWAmbar.Checked = true;
				picSemaforoNorte.Image = Image.FromFile(imagenAmbar);
				picSemaforoSur.Image = Image.FromFile(imagenAmbar);
				picSemaforoEste.Image = Image.FromFile(imagenAmbar);
				picSemaforoOeste.Image = Image.FromFile(imagenAmbar);
			}
			else
			{
				lblContador.Text = "00";
				lblContador.ForeColor = fondo;
				picSemaforoNorte.Image = Image.FromFile(imagenNormal);
				picSemaforoSur.Image = Image.FromFile(imagenNormal);
				picSemaforoEste.Image = Image.FromFile(imagenNormal);
				picSemaforoOeste.Image = Image.FromFile(imagenNormal);
				ApagarSemaforos(true);
				ApagarSemaforos(false);
				x = 1;
			}

			// Verificar si se ha pulsado el botón de detener
			if (_detener)
			{
				// Detener el temporizador
				_timer.Stop();

				// Liberar los recursos del temporizador
				_timer.Dispose();
				_timer = null;

				return;
			}
			picSemaforoNorte.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
			picSemaforoSur.Image.RotateFlip(RotateFlipType.Rotate270FlipX);
			picSemaforoOeste.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
		}
	}
}
