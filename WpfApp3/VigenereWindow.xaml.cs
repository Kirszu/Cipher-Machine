using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy VinegereWindow.xaml
    /// </summary>
    public partial class VigenereWindow : Window
    {
        public VigenereWindow()
        {
            InitializeComponent();
        }

        string password;
        string key;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            password = passwordText.Text;
            key = keyText.Text;

            string result;
            result = Vigenere.vigenereEncrypt(password, key);
            resultText.Text = result;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            password = passwordText.Text;
            key = keyText.Text;

            string result;
            result = Vigenere.vigenereDecrypt(password, key);
            resultText.Text = result;
        }
    }

    public static class Vigenere
    {
        public static string vigenereEncrypt(string vinegereText, string vinegereKey)
        {
            String text = vinegereText;
            RemoveSpecialCharacters(text);
            text = text.ToUpper();

            String key = vinegereKey;
            RemoveSpecialCharacters(key);
            key = key.ToUpper();
            char[] textArray = text.ToCharArray();
            char[] keyArray = new char[text.Length];

            //Adding characters to keyArray until there is the same amount of chars as in textArray
            fillArray(keyArray, text.Length, key.Length, key);

            int[] asciiTextArray = new int[text.Length];
            int[] asciiKeyArray = new int[text.Length];
            int[] asciiNewText = new int[text.Length];
            char[] asciiFinalText = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                asciiTextArray[i] = (int)textArray[i];
                asciiKeyArray[i] = (int)keyArray[i];
                asciiNewText[i] = asciiTextArray[i] + asciiKeyArray[i];
                if (asciiNewText[i] > 155)
                {
                    asciiFinalText[i] = (char)(asciiNewText[i] - 91);
                }
                else
                {
                    asciiFinalText[i] = (char)(asciiNewText[i] - 65);
                }
            }

            String result = new string(asciiFinalText);
            return result;
        }

        public static string vigenereDecrypt(string vinegereText, string vinegereKey)
        {

            String text = vinegereText;
            RemoveSpecialCharacters(text);
            text = text.ToUpper();

            String key = vinegereKey;
            RemoveSpecialCharacters(key);
            key = key.ToUpper();

            char[] textArray = text.ToCharArray();
            char[] keyArray = new char[text.Length];

            //Adding characters to keyArray until there is the same amount of chars as in textArray
            fillArray(keyArray, text.Length, key.Length, key);
            int[] asciiTextArray = new int[text.Length];
            int[] asciiKeyArray = new int[text.Length];
            int[] asciiNewText = new int[text.Length];
            char[] asciiFinalText = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                asciiTextArray[i] = (int)textArray[i];
                asciiKeyArray[i] = (int)keyArray[i];
                asciiNewText[i] = asciiTextArray[i] - asciiKeyArray[i];
                if (asciiNewText[i] >= 0)
                {
                    asciiFinalText[i] = (char)(asciiNewText[i] + 65);
                }
                else
                {
                    asciiFinalText[i] = (char)(asciiNewText[i] + 91);
                }
            }
            String result = new string(asciiFinalText);
            return result;
        }

        public static void fillArray(char[] keyArray, int textLen, int keyLen, String key)
        {
            int temp = 0;
            for (int i = 0; i < textLen; i++)
            {
                if (i >= keyLen)
                {
                    keyArray[i] = key[temp];
                    temp++;
                    if (temp >= key.Length)
                    {
                        temp = 0;
                    }
                }
                else
                {
                    keyArray[i] = key[i];
                }
            }
        }
        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
