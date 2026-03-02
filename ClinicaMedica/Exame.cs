using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ClinicaMedica
{
	internal class Exame
	{
		private string _nome;
		private int _prazo;

		public Exame(string nome, int prazo)
		{
			if (prazo <= 0)
			{
				throw new ArgumentException("O prazo do exame deve ser maior que zero.");
			}
			_nome = nome;
			_prazo = prazo;
		}
	}
}
