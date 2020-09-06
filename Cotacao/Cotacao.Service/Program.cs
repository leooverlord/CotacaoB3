using Cotacao.Domain.Enums;
using Cotacao.Service.Services;
using System;
using System.Globalization;
using System.Linq;

namespace Cotacao.Service
{
    public static class Program
    {
        public static string Ativo;
        public static double Maximo;
        public static double Minimo;

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Ativo = args[0];
                Maximo = double.Parse(args[1], CultureInfo.InvariantCulture.NumberFormat);
                Minimo = double.Parse(args[2], CultureInfo.InvariantCulture.NumberFormat);

                ConfigureService.Configure();
            }
            else
            {
                Console.WriteLine("Por favor informe os argumentos para executar o serviço de cotações!");
                Console.WriteLine("@Exemplo: -ativo: \"PETR4\" -maximo:\"22.67\" - minimo:\"22.59\"");

                var ativos = Enum.GetNames(typeof(Symbols)).Cast<string>().ToList();
                var ativosComVirgula = string.Join(", ", ativos);
                Console.WriteLine($@"Ativos disponiveis para consulta: {ativosComVirgula.Remove(ativosComVirgula.LastIndexOf(","))}");
                Console.ReadKey();
            }
        }
    }
}
