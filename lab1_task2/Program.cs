using System;

class VigenereCipher
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string alphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюяАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ0123456789";

        Console.WriteLine("Введіть текст для шифрування:");
        string plaintext = Console.ReadLine().ToLower(); // Перетворюємо весь текст в нижній регістр

        Console.WriteLine("Введіть ключ:");
        string key = Console.ReadLine().ToLower(); // Перетворюємо весь ключ в нижній регістр

        string encryptedText = Encrypt(plaintext, key, alphabet);
        Console.WriteLine("Зашифрований текст: " + encryptedText);

        string decryptedText = Decrypt(encryptedText, key, alphabet);
        Console.WriteLine("Розшифрований текст: " + decryptedText);
    }

    static string Encrypt(string plaintext, string key, string alphabet)
    {
        string encryptedText = "";
        int keyIndex = 0;

        for (int i = 0; i < plaintext.Length; i++)
        {
            char currentChar = plaintext[i];

            if (alphabet.Contains(currentChar.ToString()))
            {
                int shift = alphabet.IndexOf(key[keyIndex]) + 1;
                int newIndex = (alphabet.IndexOf(currentChar) + shift) % alphabet.Length;
                char newChar = alphabet[newIndex];
                encryptedText += newChar;
                keyIndex = (keyIndex + 1) % key.Length;
            }
            else
            {
                encryptedText += currentChar;
            }
        }

        return encryptedText;
    }

    static string Decrypt(string encryptedText, string key, string alphabet)
    {
        string decryptedText = "";
        int keyIndex = 0;

        for (int i = 0; i < encryptedText.Length; i++)
        {
            char currentChar = encryptedText[i];

            if (alphabet.Contains(currentChar.ToString()))
            {
                int shift = alphabet.IndexOf(key[keyIndex]) + 1;
                int newIndex = (alphabet.IndexOf(currentChar) - shift + alphabet.Length) % alphabet.Length;
                char newChar = alphabet[newIndex];
                decryptedText += newChar;
                keyIndex = (keyIndex + 1) % key.Length;
            }
            else
            {
                decryptedText += currentChar;
            }
        }

        return decryptedText;
    }
}
