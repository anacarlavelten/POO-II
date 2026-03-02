using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ClinicaMedica
{
	internal class HistoricoClinico
	{
		private List<string> _registros = new List<string>();

		public void AdicionarEntrada(DateTime data, string observacao)
		{
			if (string.IsNullOrWhiteSpace(observacao))
				throw new ArgumentException("O histórico não aceita texto vazio.");

			_registros.Add($"[{data:dd/MM/yyyy}] - {observacao}");
		}

		// Certifique-se de que o nome é "Mostrar" para combinar com o Program.cs
		public void Mostrar()
		{
			Console.WriteLine("\n=== HISTÓRICO MÉDICO COMPLETO ===");
			if (_registros.Count == 0) Console.WriteLine("Nenhum registro encontrado.");
			else _registros.ForEach(Console.WriteLine);
		}
	}
}
