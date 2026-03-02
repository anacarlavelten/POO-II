using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.ClinicaMedica;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("--- Cadastro de Clínica Médica ---");

			try
			{
				//Cadastrar dados do Médico
				Console.Write("Digite o nome do Médico: ");
				string nomeMed = Console.ReadLine();
				Console.Write("Digite o CRM: ");
				string crm = Console.ReadLine();
				Medico medico = new Medico(nomeMed, crm);

				Console.WriteLine("\n----------------------------------");

				//Cadastrar dados do Paciente
				Console.Write("Digite o nome do Paciente: ");
				string nomePac = Console.ReadLine();
				Console.Write("Digite o CPF: ");
				string cpf = Console.ReadLine();
				Paciente paciente = new Paciente(nomePac, cpf);

				Console.WriteLine("\n----------------------------------");

				//Agendar a Consulta
				Console.WriteLine("Agendamento de Consulta:");
				Console.Write("Digite a data (formato DD/MM/AAAA): ");
				DateTime data = DateTime.Parse(Console.ReadLine());

				//Criando a consulta (a validação de data futura acontece no construtor da Consulta)
				Consulta consulta = new Consulta(medico, paciente, data);
				Console.WriteLine("✔ Consulta pré-agendada com sucesso!");

				//Verificar se o paciente compareceu (Regra: só pode registrar comparecimento se a data da consulta for hoje ou no passado)
				Console.Write("\nO paciente compareceu? (S/N): ");
				string resposta = Console.ReadLine().ToUpper();

				if (resposta == "S")
				{
					consulta.RegistrarComparecimento();
					Console.WriteLine("✔ Comparecimento registrado.");
				}

				//Histórico Clínico (Regra: não pode ser vazio, o 'set' do HistoricoClinico lançará erro se for)
				Console.WriteLine("\n--- Registro de Histórico ---");
				Console.Write("Digite as observações clínicas: ");
				string obs = Console.ReadLine();

				HistoricoClinico historico = new HistoricoClinico();
				historico.Observacoes = obs; // Se estiver vazio, o 'set' lançará erro

				// Registro do atendimento (Resumo)
				Console.WriteLine("\n==================================");
				Console.WriteLine("RESUMO DO ATENDIMENTO:");
				Console.WriteLine($"Médico: {medico.Nome}");
				Console.WriteLine($"Paciente: {paciente.Nome}");
				Console.WriteLine($"Compareceu: {(consulta.Compareceu ? "Sim" : "Não")}");
				Console.WriteLine($"Observações: {historico.Observacoes}");
				Console.WriteLine("==================================");

			}
			catch (FormatException)
			{
				Console.WriteLine("ERRO: Formato de data inválido. Use DD/MM/AAAA.");
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine($"ERRO DE VALIDAÇÃO: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERRO INESPERADO: {ex.Message}");
			}

			Console.WriteLine("\nPressione qualquer tecla para encerrar...");
			Console.ReadKey();
		}
	}
}
