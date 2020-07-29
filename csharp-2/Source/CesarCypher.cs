using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        private readonly List<char> alphabet = new List<char>(){
            'a', 'b', 'c', 'd',
            'e', 'f', 'g', 'h',
            'i', 'j', 'k', 'l',
            'm', 'n', 'o', 'p',
            'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z'
        };

        public const int CHARS_TO_SKIP = 3;

        public string Crypt(string message)
        {
            if (message == null)
                throw new ArgumentNullException("A mensagem não pode ser nula!");

            string cryptedMessage = "";

            char[] characters = message.ToLower().ToCharArray();

            foreach (char character in characters)
            {
                if (alphabet.Contains(character))
                {
                    int characterIndex = alphabet.IndexOf(character);
                    int cryptedCharacterIndex = characterIndex + CHARS_TO_SKIP;

                    if (cryptedCharacterIndex >= alphabet.Count)
                    {
                        cryptedCharacterIndex -= alphabet.Count;
                    }

                    char decryptedCharacter = alphabet[cryptedCharacterIndex];

                    cryptedMessage += decryptedCharacter;
                }
                else if (IsValidCharacter(character))
                {
                    cryptedMessage += character;
                }
            }

            return cryptedMessage;
        }

        public string Decrypt(string cryptedMessage)
        {
            if (cryptedMessage == null)
                throw new ArgumentNullException("A mensagem não pode ser nula!");

            string decryptedMessage = "";

            char[] characters = cryptedMessage.ToLower().ToCharArray();

            foreach (char character in characters)
            {
                if (alphabet.Contains(character))
                {
                    int cryptedCharacterIndex = alphabet.IndexOf(character);
                    int decryptedCharacterIndex = cryptedCharacterIndex - CHARS_TO_SKIP;

                    bool skipedOutAlphabet = decryptedCharacterIndex < 0;
                    if (skipedOutAlphabet)
                    {
                        decryptedCharacterIndex = alphabet.Count - Math.Abs(decryptedCharacterIndex);
                    }

                    char caracterDecifrado = alphabet[decryptedCharacterIndex];

                    decryptedMessage += caracterDecifrado;
                }
                else if (IsValidCharacter(character))
                {
                    decryptedMessage += character;
                }
            }

            return decryptedMessage;
        }

        private bool IsValidCharacter(char character)
        {
            if (char.IsNumber(character) || char.IsWhiteSpace(character))
            {
                return true;
            }
            else//caracteres especiais ou letras acentuadas(ç, á, é, entre outras..)
            {
                throw new ArgumentOutOfRangeException("A mensagem possui um caracter inválido!");
            }
        }
    }
}
