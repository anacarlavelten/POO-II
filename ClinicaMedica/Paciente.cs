using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ClinicaMedica
{
	internal class Paciente
	{
		private string _nome;
		private string _cpf;
		public string Nome { get => _nome; }
		public string Cpf { get => _cpf; }

		public Paciente(string nome, string cpf) {
			this._nome = nome;
			this._cpf = cpf;
		}
	}
}
