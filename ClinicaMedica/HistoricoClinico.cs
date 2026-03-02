using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ClinicaMedica
{
	internal class HistoricoClinico
	{
		private string _observacoes;

		public string Observacoes
		{
			get => _observacoes;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentException("Histórico não aceita texto vazio");
				_observacoes = value;
			}
		}
	}
}
