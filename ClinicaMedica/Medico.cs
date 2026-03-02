using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ClinicaMedica
{
	internal class Medico
	{
		private string _nome;
		private string _CRM;

		public Medico(string nome, string crm)
		{
			this._nome = nome;
			this._CRM = crm;
		}

		public string Nome { get => _nome; }
	}
}
