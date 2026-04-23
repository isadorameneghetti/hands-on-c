using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaConsole
{
    class Compromisso
    {
        public string Descricao { get; set; }
        public DateTime DataHoraUtc { get; set; }
        public string TimeZoneId { get; set; }

        public Compromisso(string descricao, DateTime dataHoraUtc, string timeZoneId)
        {
            Descricao = descricao;
            DataHoraUtc = dataHoraUtc;
            TimeZoneId = timeZoneId;
        }
    }

    class Program
    {
        static List<Compromisso> compromissos = new List<Compromisso>();

        static void Main(string[] args)
        {
            bool executando = true;

            while (executando)
            {
                Console.Clear();
                Console.WriteLine("AGENDA");
                Console.WriteLine("1 - Adicionar compromisso");
                Console.WriteLine("2 - Exibir compromissos do dia atual");
                Console.WriteLine("3 - Exibir compromissos de uma data específica");
                Console.WriteLine("4 - Sair");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarCompromisso();
                        break;
                    case "2":
                        ExibirCompromissosDoDiaAtual();
                        break;
                    case "3":
                        ExibirCompromissosPorData();
                        break;
                    case "4":
                        executando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AdicionarCompromisso()
        {
            Console.Clear();
            Console.WriteLine("ADICIONAR COMPROMISSO\n");

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Data (dd/MM/yyyy): ");
            string dataStr = Console.ReadLine();

            Console.Write("Hora (HH:mm): ");
            string horaStr = Console.ReadLine();

            Console.Write("TimeZone (ex: E. South America Standard Time para SP): ");
            string timeZoneId = Console.ReadLine();

            try
            {
                DateTime dataHoraLocal = DateTime.ParseExact($"{dataStr} {horaStr}", "dd/MM/yyyy HH:mm", null);

                TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                DateTime dataHoraUtc = TimeZoneInfo.ConvertTimeToUtc(dataHoraLocal, tz);

                compromissos.Add(new Compromisso(descricao, dataHoraUtc, timeZoneId));
                Console.WriteLine("\nCompromisso adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        static void ExibirCompromissosDoDiaAtual()
        {
            Console.Clear();
            Console.WriteLine("=== COMPROMISSOS DO DIA ATUAL ===\n");

            Console.Write("Informe o timezone (ou Enter para usar o padrão do sistema): ");
            string timeZoneId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(timeZoneId))
            {
                timeZoneId = TimeZoneInfo.Local.Id;
            }

            try
            {
                TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                DateTime hoje = DateTime.UtcNow;
                DateTime hojeNoTimezone = TimeZoneInfo.ConvertTimeFromUtc(hoje, tz);

                var compromissosDoDia = compromissos.Where(c =>
                {
                    DateTime dataLocal = TimeZoneInfo.ConvertTimeFromUtc(c.DataHoraUtc, tz);
                    return dataLocal.Date == hojeNoTimezone.Date;
                });

                if (!compromissosDoDia.Any())
                {
                    Console.WriteLine("Nenhum compromisso para hoje.");
                }
                else
                {
                    foreach (var c in compromissosDoDia)
                    {
                        DateTime dataLocal = TimeZoneInfo.ConvertTimeFromUtc(c.DataHoraUtc, tz);
                        Console.WriteLine($"- {c.Descricao} | {dataLocal:dd/MM/yyyy HH:mm}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        static void ExibirCompromissosPorData()
        {
            Console.Clear();
            Console.WriteLine("=== COMPROMISSOS POR DATA ===\n");

            Console.Write("Informe a data (dd/MM/yyyy): ");
            string dataStr = Console.ReadLine();

            Console.Write("Informe o timezone (ou Enter para usar o padrão do sistema): ");
            string timeZoneId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(timeZoneId))
            {
                timeZoneId = TimeZoneInfo.Local.Id;
            }

            try
            {
                DateTime data = DateTime.ParseExact(dataStr, "dd/MM/yyyy", null);
                TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

                var compromissosDaData = compromissos.Where(c =>
                {
                    DateTime dataLocal = TimeZoneInfo.ConvertTimeFromUtc(c.DataHoraUtc, tz);
                    return dataLocal.Date == data.Date;
                });

                if (!compromissosDaData.Any())
                {
                    Console.WriteLine($"\nNenhum compromisso para {dataStr}.");
                }
                else
                {
                    Console.WriteLine($"\nCompromissos para {dataStr}:\n");
                    foreach (var c in compromissosDaData)
                    {
                        DateTime dataLocal = TimeZoneInfo.ConvertTimeFromUtc(c.DataHoraUtc, tz);
                        Console.WriteLine($"- {c.Descricao} | {dataLocal:dd/MM/yyyy HH:mm}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}