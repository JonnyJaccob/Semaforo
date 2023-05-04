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
using System.IO;

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
			//timer.Tick += new EventHandler(Timer_Tick);

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

			lblCrono.Font = fuente_DS_DIGIT;
			ptimer = new Timer();
			ptimer.Interval = 500;
			ptimer.Tick += Ptimer_Tick;

			timerx.Interval = 250; //250 ms
			timerx.Tick += new EventHandler(Timerx_Tick);
		}
		private Timer ptimer;
		private int segun = 0;
		private int milisegundos = 0;
		static Timer timer = new Timer(); // Declarar un temporizador para contar los segundos
		static Timer timerx = new Timer();
		static double segundos = 0; // Declarar la variable para el contador de segundos
		private static Color verde = Semaforo.verde;
		private static Color amarillo = Semaforo.amarillo;
		private static Color rojo = Semaforo.rojo;
		private static Color fondo = Semaforo.fondo;
		static string rutaBase = Application.StartupPath;
		private static string imagenNormal = Path.Combine(rutaBase, "SemaforoApag1_2.png");
		private static string imagenVerde = Path.Combine(rutaBase, "SemaforoVerde1.png");
		private static string imagenAmbar = Path.Combine(rutaBase, "SemaforoAmarillo1.png");
		private static string imagenRojo = Path.Combine(rutaBase, "SemaforoRojo1.png");

		private void btnSalir_Click(object sender, EventArgs e)
		{
			Application.ExitThread();
			Application.Exit();
		}
		private void FormatoContador(string valor, Color color)
		{
			if (valor.Length > 1)
			{
				lblContador.Text = valor;
			} else
			{
				lblContador.Text = " " + valor;
			}
			lblContador.ForeColor = color;
		}
		Semaforo semaforo;
		bool blnNorte_Sur = true;
		private void Iniciar()
		{
			//timer.Start(); // Iniciar el temporizador

			timerx.Start();
			ptimer.Stop();
			lblCrono.Text = "0";
			segun = 0;
			milisegundos = 0;
			ptimer.Start();
			segundos = 0; // Reiniciar el contador de segundos
			fase = 1;
			FASES = 1;
			semaforo = new Semaforo();
			blnNorte_Sur = true;
			FormatoContador("0", verde); // Actualizar la etiqueta con el valor inicial
		}
		private void Ptimer_Tick(object sender, EventArgs e)
		{
			milisegundos += 500;
			if (milisegundos == 1000)
			{
				milisegundos = 0;
				segun++;
			}

			lblCrono.Text = segun.ToString() + ":" + milisegundos.ToString("D3");
			AcomodarSemaforo();
		}
		int FASES = 1;
		int Segverde1 = 17;
		int SegVerde2 = 3;
		int SegAmbar = 3;
		int SegRojo = 2;
		string strColor = "";
		bool xc = false;
		private void Timerx_Tick(object sender, EventArgs e)
		{
			segundos += 0.25; // Incrementar el contador de segundos
			double valor = Math.Truncate(segundos);
			switch (FASES)
			{
				case 1 when (segundos > 0 && segundos <= Segverde1):
					FormatoContador(valor.ToString(), verde);
					strColor = "Verde";
					break;
				case 1 when (segundos == Segverde1 + 0.5):
					FormatoContador(valor.ToString(), fondo);
					strColor = "Fondo";
					FASES = 2;
					segundos = 0.5;
					segun = 0;
					milisegundos = 500;
					break;
				case 2 when (segundos > 0.5 && segundos <= SegVerde2):
					if (segundos == 1 || segundos == 2 || segundos == 3)
					{
						FormatoContador(valor.ToString(), verde);
						strColor = "Verde";
					}
					if (segundos == 1.5 || segundos == 2.5 || segundos == 3.5)
					{
						FormatoContador(valor.ToString(), fondo);
						strColor = "Fondo";
					}
					break;
				case 2 when (segundos == SegVerde2 + 0.5):
					FormatoContador(valor.ToString(), fondo);
					strColor = "Fondo";
					FASES = 3;
					segundos = 0.5;
					segun = 0;
					milisegundos = 500;
					break;
				case 3 when (segundos > 0.5 && segundos <= SegAmbar):
					if (segundos >= 1)
					{
						FormatoContador(valor.ToString(), amarillo);
						strColor = "Ambar";
					}
					break;
				case 3 when (segundos == SegAmbar + 0.5):
					FormatoContador(valor.ToString(), fondo);
					strColor = "Fondo";
					FASES = 4;
					segundos = 0.5;
					segun = 0;
					milisegundos = 500;
					break;
				case 4 when (segundos > 0.5 && segundos <= SegRojo):
					if (segundos >= 1)
					{
						FormatoContador(valor.ToString(), rojo);
						strColor = "Rojo";
					}
					break;
				case 4 when (segundos == SegRojo + 0.5):
					FormatoContador(valor.ToString(), fondo);
					strColor = "Fondo";
					FASES = 1;
					segundos = 1;
					segun = 0;
					milisegundos = 1000;
					if (blnNorte_Sur)
					{
						blnNorte_Sur = false;
					} else
					{
						blnNorte_Sur = true;
					}
					break;
				default:
					break;
			}
			if (strColor == "Verde")
			{
				CambiarSemaforo(imagenVerde, blnNorte_Sur);
			}
			else
			if (strColor == "Ambar")
			{
				CambiarSemaforo(imagenAmbar, blnNorte_Sur);

			}
			else
			if (strColor == "Rojo")
			{
				CambiarSemaforo(imagenRojo, blnNorte_Sur);

			}
			else
			{
				CambiarSemaforo(imagenNormal, blnNorte_Sur);

			}
		}
		private void CambiarSemaforo(string ruta, bool IsNorteSur)
		{
			
			if (IsNorteSur)
			{
				Bitmap TempNorte = new Bitmap(ruta);
				TempNorte.RotateFlip(RotateFlipType.Rotate90FlipX);
				Bitmap TempSur = new Bitmap(ruta);
				TempSur.RotateFlip(RotateFlipType.Rotate270FlipX);
				Bitmap TempOeste = new Bitmap(imagenRojo);
				TempOeste.RotateFlip(RotateFlipType.Rotate180FlipX);
				Bitmap TempEste = new Bitmap(imagenRojo);

				picSemaforoNorte.Image = TempNorte;
				picSemaforoSur.Image = TempSur;
				picSemaforoOeste.Image = TempOeste;
				picSemaforoEste.Image = TempEste;
			}
			else
			{
				Bitmap TempNorte = new Bitmap(imagenRojo);
				TempNorte.RotateFlip(RotateFlipType.Rotate90FlipX);
				Bitmap TempSur = new Bitmap(imagenRojo);
				TempSur.RotateFlip(RotateFlipType.Rotate270FlipX);
				Bitmap TempOeste = new Bitmap(ruta);
				TempOeste.RotateFlip(RotateFlipType.Rotate180FlipX);
				Bitmap TempEste = new Bitmap(ruta);

				picSemaforoNorte.Image = TempNorte;
				picSemaforoSur.Image = TempSur;
				picSemaforoOeste.Image = TempOeste;
				picSemaforoEste.Image = TempEste;
			}
		}
		private void AcomodarSemaforo()
		{
			picSemaforoNorte.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
			picSemaforoSur.Image.RotateFlip(RotateFlipType.Rotate270FlipX);
			picSemaforoOeste.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
			picSemaforoNorte.Size =
			picSemaforoSur.Size = new Size(56, 41);
			picSemaforoEste.Size =
			picSemaforoOeste.Size = new Size(41, 56);

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
		//private void Timer_Tick(object sender, EventArgs e)
		//{
		//	segundos += 0.5; // Incrementar el contador de segundos

		//	double valor = 1;
		//	try
		//	{
				
		//		valor = semaforo.SemaforoTiempo(segundos);
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show(ex.Message);
		//	}
		//	if (semaforo.Fase != fase)
		//	{
		//		fase = semaforo.Fase;
		//		ApagarSemaforos(semaforo.blnNorte_Sur);
		//		timer.Stop();
		//		segundos = 1;
		//		timer.Start();
		//	}
		//	if(semaforo.blnNorte_Sur)
		//	{
		//		rdbERojo.Checked = rdbWRojo.Checked = true;

		//		picSemaforoEste.Image = Image.FromFile(imagenRojo);
		//		picSemaforoOeste.Image = Image.FromFile(imagenRojo);
		//	}
		//	else
		//	{
		//		rdbNRojo.Checked = rdbSRojo.Checked = true;

		//		picSemaforoEste.Image = Image.FromFile(imagenRojo);
		//		picSemaforoOeste.Image = Image.FromFile(imagenRojo);
		//	}
		//	switch (semaforo.Fase)
		//	{
		//		case 1 when semaforo.blnNorte_Sur:
		//			try
		//			{
		//				picSemaforoNorte.Image = Image.FromFile(imagenVerde);
		//			}
		//			catch (Exception)
		//			{

		//				throw;
		//			}
					
		//			picSemaforoSur.Image = Image.FromFile(imagenVerde);
		//			rdbNVerde.Checked = true;
		//			rdbSVerde.Checked = true;
		//			rdbNAmbar.Checked = rdbNRojo.Checked = false;
		//			rdbSAmbar.Checked = rdbSRojo.Checked = false;
		//			rdbERojo.Checked = rdbWRojo.Checked = true;
		//			break;
		//		case 2 when semaforo.blnNorte_Sur:
		//			if (semaforo.colorLetrero != fondo)
		//			{
		//				rdbNVerde.Checked = rdbSVerde.Checked = true;
		//				picSemaforoNorte.Image = Image.FromFile(imagenVerde);
		//				picSemaforoSur.Image = Image.FromFile(imagenVerde);
		//			}
		//			else
		//			{
		//				picSemaforoNorte.Image = Image.FromFile(imagenNormal);
		//				picSemaforoSur.Image = Image.FromFile(imagenNormal);
		//				rdbNVerde.Checked = rdbSVerde.Checked = false;
		//			}
		//			rdbNAmbar.Checked = rdbSAmbar.Checked = false;
		//			rdbNRojo.Checked = rdbSRojo.Checked = false;
		//			rdbERojo.Checked = rdbWRojo.Checked = true;
		//			break;
		//		case 3 when semaforo.blnNorte_Sur:
		//			picSemaforoNorte.Image = Image.FromFile(imagenAmbar);
		//			picSemaforoSur.Image = Image.FromFile(imagenAmbar);
		//			rdbNVerde.Checked = rdbSVerde.Checked = false;
		//			rdbNAmbar.Checked = rdbSAmbar.Checked = true;
		//			rdbNRojo.Checked = rdbSRojo.Checked = false;
		//			break;
		//		case 4 when semaforo.blnNorte_Sur:
		//			picSemaforoNorte.Image = Image.FromFile(imagenRojo);
		//			picSemaforoSur.Image = Image.FromFile(imagenRojo);
		//			rdbNVerde.Checked = rdbSVerde.Checked = false;
		//			rdbNAmbar.Checked = rdbSAmbar.Checked = false;
		//			rdbNRojo.Checked = rdbSRojo.Checked = true;
		//			break;
		//		case 1 when semaforo.blnEste_Oeste:
		//			picSemaforoEste.Image = Image.FromFile(imagenVerde);
		//			picSemaforoOeste.Image = Image.FromFile(imagenVerde);
		//			rdbEVerde.Checked = true;
		//			rdbWVerde.Checked = true;
		//			rdbEAmbar.Checked = rdbERojo.Checked = false;
		//			rdbWAmbar.Checked = rdbWRojo.Checked = false;
		//			break;
		//		case 2 when semaforo.blnEste_Oeste:
		//			if (semaforo.colorLetrero != fondo)
		//			{
		//				rdbEVerde.Checked = rdbWVerde.Checked = true;
		//				picSemaforoEste.Image = Image.FromFile(imagenVerde);
		//				picSemaforoOeste.Image = Image.FromFile(imagenVerde);
		//			}
		//			else
		//			{
		//				rdbEVerde.Checked = rdbWVerde.Checked = false;
		//				picSemaforoEste.Image = Image.FromFile(imagenNormal);
		//				picSemaforoOeste.Image = Image.FromFile(imagenNormal);
		//			}
		//			rdbEAmbar.Checked = rdbWAmbar.Checked = false;
		//			rdbERojo.Checked = rdbWRojo.Checked = false;
		//			break;
		//		case 3 when semaforo.blnEste_Oeste:
		//			picSemaforoEste.Image = Image.FromFile(imagenAmbar);
		//			picSemaforoOeste.Image = Image.FromFile(imagenAmbar);
		//			rdbEVerde.Checked = rdbWVerde.Checked = false;
		//			rdbEAmbar.Checked = rdbWAmbar.Checked = true;
		//			rdbERojo.Checked = rdbWRojo.Checked = false;
		//			break;
		//		case 4 when semaforo.blnEste_Oeste:
		//			picSemaforoEste.Image = Image.FromFile(imagenRojo);
		//			picSemaforoOeste.Image = Image.FromFile(imagenRojo);
		//			rdbEVerde.Checked = rdbWVerde.Checked = false;
		//			rdbEAmbar.Checked = rdbWAmbar.Checked = false;
		//			rdbERojo.Checked = rdbWRojo.Checked = true;
		//			break;
		//		default:
		//			break;
		//	}
		//	FormatoContador(Math.Truncate(valor)+"", semaforo.colorLetrero); // Actualizar la etiqueta con el nuevo valor
		//	picSemaforoNorte.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
		//	picSemaforoSur.Image.RotateFlip(RotateFlipType.Rotate270FlipX);
		//	picSemaforoOeste.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
		//}
		Timer _timer2;
		private void btnDetener_Click(object sender, EventArgs e)
		{
			// Activar la variable de detener para salir del bucle
			_detener = true;
			timerx.Stop(); // Detener el temporizador
			segundos = 0;
			ptimer.Stop();
			lblCrono.Text = "0";
			segun = 0;
			milisegundos = 0;
			groupBox2.BackColor = fondo;
			lblContador.BackColor = fondo;
			lblContador.ForeColor = fondo;

			Bitmap TempNorte = new Bitmap(imagenNormal);
			TempNorte.RotateFlip(RotateFlipType.Rotate90FlipX);
			Bitmap TempSur = new Bitmap(imagenNormal);
			TempSur.RotateFlip(RotateFlipType.Rotate270FlipX);
			Bitmap TempOeste = new Bitmap(imagenNormal);
			TempOeste.RotateFlip(RotateFlipType.Rotate180FlipX);
			Bitmap TempEste = new Bitmap(imagenNormal);

			picSemaforoNorte.Image = TempNorte;
			picSemaforoSur.Image = TempSur;
			picSemaforoOeste.Image = TempOeste;
			picSemaforoEste.Image = TempEste;

			_timer2 = new Timer();
			_timer2.Interval = 2000; // 2000 ms = 2 segundos
			_timer2.Tick += Timer_Tick2;
		}

		private void Timer_Tick2(object sender, EventArgs e)
		{
			
			_timer2.Stop();
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
			ptimer.Stop();
			lblCrono.Text = "0";
			timerx.Stop();
			// Reiniciar variable de detener
			_detener = false;

			// Crear y configurar el temporizador
			_timer = new Timer();
			_timer.Interval = 500; // 500 ms = medio segundo
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


				Bitmap TempNorte = new Bitmap(imagenAmbar);
				TempNorte.RotateFlip(RotateFlipType.Rotate90FlipX);
				Bitmap TempSur = new Bitmap(imagenAmbar);
				TempSur.RotateFlip(RotateFlipType.Rotate270FlipX);
				Bitmap TempOeste = new Bitmap(imagenAmbar);
				TempOeste.RotateFlip(RotateFlipType.Rotate180FlipX);
				Bitmap TempEste = new Bitmap(imagenAmbar);

				picSemaforoNorte.Image = TempNorte;
				picSemaforoSur.Image = TempSur;
				picSemaforoOeste.Image = TempOeste;
				picSemaforoEste.Image = TempEste;
			}
			else
			{
				lblContador.Text = "00";
				lblContador.ForeColor = fondo;

				Bitmap TempNorte = new Bitmap(imagenNormal);
				TempNorte.RotateFlip(RotateFlipType.Rotate90FlipX);
				Bitmap TempSur = new Bitmap(imagenNormal);
				TempSur.RotateFlip(RotateFlipType.Rotate270FlipX);
				Bitmap TempOeste = new Bitmap(imagenNormal);
				TempOeste.RotateFlip(RotateFlipType.Rotate180FlipX);
				Bitmap TempEste = new Bitmap(imagenNormal);

				picSemaforoNorte.Image = TempNorte;
				picSemaforoSur.Image = TempSur;
				picSemaforoOeste.Image = TempOeste;
				picSemaforoEste.Image = TempEste;
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

				Bitmap TempNorte = new Bitmap(imagenNormal);
				TempNorte.RotateFlip(RotateFlipType.Rotate90FlipX);
				Bitmap TempSur = new Bitmap(imagenNormal);
				TempSur.RotateFlip(RotateFlipType.Rotate270FlipX);
				Bitmap TempOeste = new Bitmap(imagenNormal);
				TempOeste.RotateFlip(RotateFlipType.Rotate180FlipX);
				Bitmap TempEste = new Bitmap(imagenNormal);

				picSemaforoNorte.Image = TempNorte;
				picSemaforoSur.Image = TempSur;
				picSemaforoOeste.Image = TempOeste;
				picSemaforoEste.Image = TempEste;

				return;
			}
		}
	}
}
