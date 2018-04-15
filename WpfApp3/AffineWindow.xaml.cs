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
    /// Logika interakcji dla klasy AffineWindow.xaml
    /// </summary>
    public partial class AffineWindow : Window
    {
        public AffineWindow()
        {
            InitializeComponent();
        }

        string text;
        int keyA;
        int keyB;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            text = passwordText.Text;

            if (!int.TryParse(keyAText.Text.Trim(), out keyA))
            {
                //not a valid integer
            }
            else
            {
                //valid integer
                keyA = int.Parse(keyAText.Text);
            }

            if (!int.TryParse(keyBText.Text.Trim(), out keyB))
            {
                //not a valid integer
            }
            else
            {
                //valid integer
                keyB = int.Parse(keyBText.Text);
            }

            string result;
            result = Affine.affineEncrypt(text, keyA, keyB);
            resultText.Text = result;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            text = passwordText.Text;

            if (!int.TryParse(keyAText.Text.Trim(), out keyA))
            {
                //not a valid integer
            }
            else
            {
                //valid integer
                keyA = int.Parse(keyAText.Text);
            }

            if (!int.TryParse(keyBText.Text.Trim(), out keyB))
            {
                //not a valid integer
            }
            else
            {
                //valid integer
                keyB = int.Parse(keyBText.Text);
            }

            string result;
            result = Affine.affineDecrypt(text, keyA, keyB);
            resultText.Text = result;
        }
    }
    public static class Affine
    {

        public static string affineEncrypt(string affineText, int affineKeyA, int affineKeyB)
        {
            int keyA = affineKeyA;
            int keyB = affineKeyB;
            String text = affineText;
            text = RemoveSpecialCharacters(text);
            text = text.ToUpper();
            char[] charArray = text.ToCharArray();
            int[] asciiArray = new int[text.Length];
            int[] newAsciiArray = new int[text.Length];
            int[] asciiCharsAdded = new int[text.Length];

            // Using the affine cipher formula
            for (int i = 0; i < text.Length; i++)
            {
                asciiArray[i] = (int)charArray[i];
                newAsciiArray[i] = ((keyA * asciiArray[i] + keyB) % 26) + 65;
                if (newAsciiArray[i] >= 78)
                {
                    asciiCharsAdded[i] = newAsciiArray[i] - 13;
                }
                else
                {
                    asciiCharsAdded[i] = newAsciiArray[i] + 13;
                }
                charArray[i] = (char)asciiCharsAdded[i];
            }

            String result = new string(charArray);
            return result;
        }

        public static string affineDecrypt(string affineText, int affineKeyA, int affineKeyB)
        {
            int keyA = affineKeyA;
            int keyB = affineKeyB;
            String text = affineText;
            text = RemoveSpecialCharacters(text);
            text = text.ToUpper();
            char[] charArray = text.ToCharArray();
            int[] asciiArray = new int[text.Length];
            int[] newAsciiArray = new int[text.Length];
            int[] asciiCharsAdded = new int[text.Length];

            // Invertion of keyA
            int inv = 0;
            int temp;
            for (int i = 0; i <= 26; i++)
            {
                temp = (keyA * i) % 26;
                if (temp == 1)
                {
                    inv = i;
                    break;
                }
            }

            // Using the affine decipher formula
            for (int i = 0; i < text.Length; i++)
            {
                asciiArray[i] = (int)charArray[i];
                newAsciiArray[i] = (inv * (asciiArray[i] - keyB) % 26) + 65;
                if (newAsciiArray[i] >= 78)
                {
                    asciiCharsAdded[i] = newAsciiArray[i] - 13;
                }
                else
                {
                    asciiCharsAdded[i] = newAsciiArray[i] + 13;
                }
                charArray[i] = (char)asciiCharsAdded[i];
            }
            String result = new string(charArray);
            return result;
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
