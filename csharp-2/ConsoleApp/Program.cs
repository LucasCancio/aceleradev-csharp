using Codenation.Challenge;
using System;

namespace ConsoleApp
{
    class Program
    {

        private static readonly CesarCypher algorithm = new CesarCypher();
        static void Main(string[] args)
        {
            Console.WriteLine($"Teste de criptagem: {TestEncrypt()}");
            Console.WriteLine($"Teste de decriptagem: {TestDecrypt()}");
            Console.WriteLine($"Teste de numeros: {TestNumber()}");

            Console.ReadLine();
        }

        public static bool TestEncrypt() {
            string messageToEncrypt = "the quick brown fox jumps over the lazy dog";
            string result = algorithm.Crypt(messageToEncrypt);
            string correctResult = "wkh txlfn eurzq ira mxpsv ryhu wkh odcb grj";

            Console.WriteLine($"\nMensagem de input: {messageToEncrypt}");
            Console.WriteLine($"Resultado obtido: {result}");
            Console.WriteLine($"Resultado esperado: {correctResult}");
            return result == correctResult;
        }

        public static bool TestNumber()
        {
            string messageToEncrypt = "aaa1aaa2 aa 3";
            string result = algorithm.Crypt(messageToEncrypt);
            string correctResult = "ddd1ddd2 dd 3";

            Console.WriteLine($"\nMensagem de input: {messageToEncrypt}");
            Console.WriteLine($"Resultado obtido: {result}");
            Console.WriteLine($"Resultado esperado: {correctResult}");
            return result == correctResult;
        }

        public static bool TestDecrypt()
        {
            string messageToDecrypt = "wkh txlfn eurzq ira mxpsv ryhu wkh odcb grj";

            string result = algorithm.Decrypt(messageToDecrypt);
            string correctResult = "the quick brown fox jumps over the lazy dog";

            Console.WriteLine($"\nMensagem de input: {messageToDecrypt}");
            Console.WriteLine($"Resultado obtido: {result}");
            Console.WriteLine($"Resultado esperado: {correctResult}");
            return result == correctResult;
        }
    }
}
