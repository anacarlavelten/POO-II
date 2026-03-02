using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1.ClinicaMedica
{
	internal class Consulta
	{
		private Medico _medico;
		private Paciente _paciente;
		private DateTime _dataHorario;
		private bool _realizada;

		public bool Compareceu { get => _realizada; }
		public Consulta(Medico medico, Paciente paciente, DateTime data)
		{
			if (data < DateTime.Now.Date)
				throw new ArgumentException("Não é permitido agendar no passado.");
			_medico = medico;
			_paciente = paciente;
			_dataHorario = data;
		}

		public void RegistrarPresenca() { _realizada = true; }
	}
}
