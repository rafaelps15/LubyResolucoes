using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Luby {
    class Program {
        static void Main(string[] args) {
            try {

            }
            catch (Exception ex) {
                Console.WriteLine($"Erro ao calcular premio: {ex.Message}");
            }
        }

        static int CalcularFatorial(int numero) {
            int fatorial;

            fatorial = 1;
            for (int i = 1; i <= numero; i++) {

                fatorial = fatorial * i;
            }

            return fatorial;
        }

        public static double CalcularPremio(int valor, string tipo, int? multiplicador) {
            if (multiplicador.HasValue && multiplicador.Value < 0)
                throw new Exception("Fator de multiplicação inválido");

            if (!multiplicador.HasValue)
                multiplicador = 1;

            switch (tipo) {
                case "basic":
                    return valor * 1.0 * multiplicador.Value;

                case "vip":
                    return valor * 1.2 * multiplicador.Value;

                case "premium":
                    return valor * 1.5 * multiplicador.Value;

                case "deluxe":
                    return valor * 1.8 * multiplicador.Value;

                case "special":
                    return valor * 2.0 * multiplicador.Value;

                default:
                    throw new Exception("Tipo informado inválido");
            }
        }

        public static int ContarNumerosPrimos(int valor) {
            int contadorPrimos = 0;

            for (int i = 1; i < valor; i++) {
                if (IsPrime(i)) {
                    contadorPrimos++;
                }
            }

            return contadorPrimos;
        }

        public static bool IsPrime(int numero) {
            int contador = 0;

            for (int i = 1; i <= numero; i++) {
                if (numero % i == 0) {
                    contador++;
                }
            }

            return contador == 2;
        }

        public static int CalcularVogais(string palavra) {
            var vogais = new char[] { 'a', 'e', 'i', 'o', 'u' };
            int quantidadeVogais = 0;

            foreach (var letra in palavra) {
                if (vogais.Contains(letra))
                    quantidadeVogais++;
            }

            return quantidadeVogais;
        }

        public static string CalcularValorComDescontoFormatado(string valorString, string descontoString) {
            double valor = double.Parse(valorString, NumberStyles.Currency);
            double desconto = double.Parse(descontoString.Replace("%", ""));

            var resultado = (valor - (valor * (desconto / 100))).ToString("C2");

            return resultado;
        }

        public static int CalcularDiferencaData(string primeiraDataString, string segundaDataString) {
            var primeiraData = DateTime.ParseExact(primeiraDataString, "ddMMyyyy", CultureInfo.InvariantCulture);
            var segundaData = DateTime.ParseExact(segundaDataString, "ddMMyyyy", CultureInfo.InvariantCulture);

            return segundaData.Subtract(primeiraData).Days;
        }

        public static string[] BuscarPessoa(string[] nomes, string termo) {
            return nomes.Where(p => p.Contains(termo)).ToArray();
        }

        public static int[] ObterElementosFaltantes(int[] vetor1, int[] vetor2) {
            List<int> resultado = new List<int>();

            for (int i = 0; i < vetor1.Length; i++) {
                int valorAtual = vetor1[i];

                if (!vetor2.Contains(valorAtual))
                    resultado.Add(valorAtual);
            }

            for (int i = 0; i < vetor2.Length; i++) {
                int valorAtual = vetor2[i];

                if (!vetor1.Contains(valorAtual))
                    resultado.Add(valorAtual);
            }

            return resultado.ToArray();
        }
    }
}
