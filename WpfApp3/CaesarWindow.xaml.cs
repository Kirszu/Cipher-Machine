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
    /// Logika interakcji dla klasy CaesarWindow.xaml
    /// </summary>
    public partial class CaesarWindow : Window
    {
        public CaesarWindow()
        {
            InitializeComponent();
        }

        string text;
        int key;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            text = passwordText.Text;

            if (!int.TryParse(keyText.Text.Trim(), out key))
            {
                //not a valid integer
            }
            else
            {
                //valid integer
                key = int.Parse(keyText.Text);
            }
            string result;
            result = Caesar.caesarEncrypt(text, key);
            resultText.Text = result;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            text = passwordText.Text;

            if (!int.TryParse(keyText.Text.Trim(), out key))
            {
                //not a valid integer
            }
            else
            {
                //valid integer
                key = int.Parse(keyText.Text);
            }
            string result;
            result = Caesar.caesarDecrypt(text, key);
            resultText.Text = result;
        }
    }
    public static class Caesar
    {
        public static string caesarEncrypt(string caesarText, int caesarKey)
        {
            String text = caesarText;
            text = RemoveSpecialCharacters(text);
            int key = caesarKey;
            char[] charArray = text.ToCharArray();
            int[] asciiArray = new int[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                asciiArray[i] = (int)charArray[i];
                // Keep char if it is a space
                if (asciiArray[i] == 32)
                {
                    charArray[i] = (char)32;
                    // If statement for small letters
                }
                else if (asciiArray[i] >= 97)
                {
                    if (asciiArray[i] + key > 122)
                    {
                        asciiArray[i] = asciiArray[i] - 26 + key;
                    }
                    else
                    {
                        asciiArray[i] += key;
                    }
                    // If statement for capital letters
                }
                else if (asciiArray[i] < 97)
                {
                    if (asciiArray[i] + key > 90)
                    {
                        asciiArray[i] = asciiArray[i] - 26 + key;
                    }
                    else
                    {
                        asciiArray[i] += key;
                    }
                }
                charArray[i] = (char)asciiArray[i];
            }
            String result = new string(charArray);
            text = result;
            return text;
        }

        public static string caesarDecrypt(string caesarText, int caesarKey)
        {

            String text = caesarText;
            text = RemoveSpecialCharacters(text);
            int key = caesarKey;
            char[] charArray = text.ToCharArray();
            int[] asciiArray = new int[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                asciiArray[i] = (int)charArray[i];
                // Keep char if it is a space
                if (asciiArray[i] == 32)
                {
                    charArray[i] = (char)32;
                    // If statement for small letters
                }
                else if (asciiArray[i] >= 97)
                {
                    if (asciiArray[i] - key < 97)
                    {
                        asciiArray[i] += 26 - key;
                    }
                    else
                    {
                        asciiArray[i] -= key;
                    }
                    // If statement for capital letters
                }
                else if (asciiArray[i] < 97)
                {
                    if (asciiArray[i] - key < 65)
                    {
                        asciiArray[i] += 26 - key;
                    }
                    else
                    {
                        asciiArray[i] -= key;
                    }
                }
                charArray[i] = (char)asciiArray[i];
            }
            String result = new string(charArray);
            text = result;
            return text;
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
