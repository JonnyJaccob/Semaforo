using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSemaforo
{
	public class Semaforo
	{
		public Semaforo()
		{
			FaseFijoVerde = 5;
			FaseParpadeoVerde = 3;
			FijoAmarillo = 3;
			FijoRojo = 2;
			blnNorte_Sur = true;
			blnEste_Oeste = false;
			Fase = 1;
		}
		private static int FaseFijoVerde;
		private static int FaseParpadeoVerde;
		private static int FijoAmarillo;
		private static int FijoRojo;
		public bool blnNorte_Sur;
		public bool blnEste_Oeste;
		public int Fase;
		public Color colorLetrero = verde;
		public static Color verde = Color.Lime;
		public static Color amarillo = Color.Yellow;
		public static Color rojo = Color.Red;
		public static Color fondo = ColorTranslator.FromHtml("#253544");

		public int CicloSemaforo(double cuenta)
		{
			int entero = (int)cuenta;
			double decimalOriginal = cuenta - entero;
			int decimalParte = (int)Math.Round(decimalOriginal * 10);

			if (entero < FaseFijoVerde && Fase == 1)
			{
				colorLetrero = verde;
			}
			else
			if (Fase == 1 && cuenta > 5)
			{
				Fase = 2;
				entero = 1;
				cuenta = 1;
				colorLetrero = verde;
			}
			else
			if (entero < FaseParpadeoVerde && Fase == 2)
			{
				if (decimalParte == 5)
				{
					colorLetrero = fondo;
				}
				else
				{
					colorLetrero = verde;
				}
			}
			else
			if (Fase == 2 && cuenta > 3)
			{
				Fase = 3;
				entero = 1;
				cuenta = 1;
				colorLetrero = verde;
			}
			else
			if (entero < FijoAmarillo && Fase == 3)
			{
				colorLetrero = amarillo;
			}
			else
			if (Fase == 3 && cuenta >= 3)
			{
				Fase = 4;
				entero = 1;
				cuenta = 1;
				colorLetrero = amarillo;
			}
			else
			if (entero < 2 && Fase == 4)
			{
				colorLetrero = rojo;
			}
			else
			if (Fase == 4 && cuenta > FijoRojo + 0.5)
			{
				Fase = 1;
				entero = 1;
				cuenta = 1;
				colorLetrero = verde;
			}
			return entero;
			
		}
		public int SemaforoTiempo(double numero)
		{
			switch (numero)
			{
				case 1 when Fase == 1:
				case 1.5 when Fase == 1:
				case 2 when Fase == 1:
				case 2.5 when Fase == 1:
				case 3 when Fase == 1:
				case 3.5 when Fase == 1:
				case 4 when Fase == 1:
				case 4.5 when Fase == 1:
				case 5 when Fase == 1:
				case 5.5 when Fase == 1:
				case 6 when Fase == 1:
				case 6.5 when Fase == 1:
				case 7 when Fase == 1:
				case 7.5 when Fase == 1:
				case 8 when Fase == 1:
				case 8.5 when Fase == 1:
				case 9 when Fase == 1:
				case 9.5 when Fase == 1:
				case 10 when Fase == 1:
				case 10.5 when Fase == 1:
				case 11 when Fase == 1:
				case 11.5 when Fase == 1:
				case 12 when Fase == 1:
				case 12.5 when Fase == 1:
				case 13 when Fase == 1:
				case 13.5 when Fase == 1:
				case 14 when Fase == 1:
				case 14.5 when Fase == 1:
				case 15 when Fase == 1:
				case 15.5 when Fase == 1:
				case 15.5 when Fase == 1:
				case 16 when Fase == 1:
				case 16.5 when Fase == 1:
				case 17 when Fase == 1:
					colorLetrero = verde;
					break;
				case 17.5 when Fase == 1:
					Fase = 2;
					numero = 1;
					colorLetrero = verde;
					break;
				
				case 1.5 when Fase == 2:
				case 2.5 when Fase == 2:
					colorLetrero = fondo;
					break;
				case 2 when Fase == 2:
				case 1 when Fase == 2:
				case 3 when Fase == 2:
					colorLetrero = verde;
					break;
				case 3.5 when Fase == 2:
					Fase = 3;
					numero = 1;
					colorLetrero = amarillo;
					break;
				case 1 when Fase == 3:
				case 1.5 when Fase == 3:
				case 2 when Fase == 3:
				case 2.5 when Fase == 3:
				case 3 when Fase == 3:
					colorLetrero = amarillo;
					break;
				case 3.5 when Fase == 3:
					colorLetrero = rojo;
					Fase = 4;
					numero = 1;
					break;
				case 1 when Fase == 4:
				case 1.5 when Fase == 4:
				case 2 when Fase == 4:
					colorLetrero = rojo;
					break;
				case 2.5 when Fase == 4:
					colorLetrero = verde;
					Fase = 1;
					numero = 1;
					if(blnNorte_Sur)
					{
						blnNorte_Sur = false;
						blnEste_Oeste = true;
					}
					else
					{
						blnEste_Oeste = false;
						blnNorte_Sur = true;
					}
					break;
				default:
					throw new Exception("Ocurrio algo inesperado");
			}
			return (int)numero;
		}
	}
}
