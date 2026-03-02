using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ClinicaMedica
{
	internal class Exame
	{
		private int _prazo;
		private string _nome{ get; set; }

		public int Prazo
		{
			get => _prazo;
			private set
			{
				if (value <= 0)
					throw new ArgumentException("Exame deve ter prazo > 0");
				_prazo = value;
			}
		}

		public Exame(string nome, int prazo)
		{
			_nome = nome;
			_prazo = prazo;
		}
	}
}
