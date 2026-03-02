using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ClinicaMedica
{
	internal class Consulta
	{
		private Medico _medico;
		private Paciente _paciente;
		private DateTime _dataHorario;
		private bool _realizada;

		public bool Compareceu { get => _realizada; }
		public Consulta(Medico medico, Paciente paciente, DateTime dataHorario)
		{
			if(dataHorario < DateTime.Now)
				throw new ArgumentException("A data e horário da consulta deve ser no futuro.");
			_medico = medico;
			_paciente = paciente;
			_dataHorario = dataHorario;
			_realizada = false;
		}

		public void RegistrarComparecimento() {
			this._realizada = true;
		}
	}
}
