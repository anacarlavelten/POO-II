using System;
using System.Collections.Generic;
using System.Globalization;
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
			HistoricoClinico hist = new HistoricoClinico();

			while (true)
			{
				Console.WriteLine("\n=== SISTEMA DA CLÍNICA MÉDICA ===");
				Console.WriteLine("1. Agendar Nova Consulta (Cadastrar Médico/Paciente)");
				Console.WriteLine("2. Consultar Histórico de Atendimentos");
				Console.WriteLine("3. Cadastrar Exame");
				Console.WriteLine("4. Sair");
				Console.Write("Escolha uma opção: ");
				string op = Console.ReadLine();

				if (op == "4") break;

				try
				{
					if (op == "1")
					{
						//Cadastro do médico
						Console.WriteLine("\n[ CADASTRO DO MÉDICO ]");
						Console.Write("Nome do Médico: ");
						string nomeMed = Console.ReadLine();
						Console.Write("CRM: ");
						string crm = Console.ReadLine();
						Medico medico = new Medico(nomeMed, crm);

						//Cadastro do paciente
						Console.WriteLine("\n[ CADASTRO DO PACIENTE ]");
						Console.Write("Nome do Paciente: ");
						string nomePac = Console.ReadLine();
						Console.Write("CPF: ");
						string cpf = Console.ReadLine();
						Paciente paciente = new Paciente(nomePac, cpf);

						//Agendamento da consulta
						Console.WriteLine("\n[ DATA DA CONSULTA ]");
						Console.Write("Digite a data (dd/mm/aaaa): ");
						DateTime data = DateTime.Parse(Console.ReadLine(), new CultureInfo("pt-BR"));

						//O construtor da Consulta já valida se a data é futura
						Consulta consulta = new Consulta(medico, paciente, data);
						Console.WriteLine($"✔ Consulta de {paciente.Nome} com {medico.Nome} agendada!");

						//registra se o paciente compareceu ou não
						Console.Write("\nO paciente compareceu ao consultório agora? (S/N): ");
						if (Console.ReadLine().ToUpper() == "S")
						{
							consulta.RegistrarPresenca();

							Console.Write("Digite a observação clínica para o histórico: ");
							string obs = Console.ReadLine();

							// Adiciona ao histórico incluindo os nomes que acabamos de cadastrar
							string registroCompleto = $"Paciente: {paciente.Nome} | Médico: {medico.Nome} | Obs: {obs}";
							hist.AdicionarEntrada(data, registroCompleto);
							Console.WriteLine("✔ Dados salvos no histórico médico.");
						}
					}
					else if (op == "2")
					{
						hist.Mostrar();
					}
					else if (op == "3")
					{
						Console.WriteLine("\n[ CADASTRO DE EXAME ]");
						Console.Write("Nome do Exame: ");
						string nomeE = Console.ReadLine();
						Console.Write("Prazo de entrega em dias: ");
						int p = int.Parse(Console.ReadLine());

						// Validação de prazo > 0 ocorre dentro da classe Exame
						new Exame(nomeE, p);
						Console.WriteLine("✔ Exame validado e cadastrado com sucesso!");
					}
				}
				catch (FormatException)
				{
					Console.WriteLine("\n[ERRO]: Formato de dado inválido (Data ou Número).");
				}
				catch (ArgumentException ex)
				{
					// Captura as regras de negócio: Data no passado, Prazo <= 0, Texto vazio
					Console.WriteLine($"\n[ERRO DE VALIDAÇÃO]: {ex.Message}");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"\n[ERRO INESPERADO]: {ex.Message}");
				}
			}
		}
	}
}	
