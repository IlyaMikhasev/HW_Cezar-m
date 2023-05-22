using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Cezar_m
{
    public static class StringExtension
    {
        public static string CezarEncrypt(this string str, int C)
        {//доделать для кирилицы
            string input = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (((int)str[i] >= (int)'A' && (int)str[i] <= (int)'Z') || ((int)str[i] >= (int)'a' && (int)str[i] <= (int)'z'))
                {
                    if (((int)str[i] + C > (int)'Z' && (int)str[i] < (int)'a') || (int)str[i] + C > (int)'z')
                    {
                        input += (char)((int)str[i] + C - 26);
                    }
                    else
                    {
                        input += (char)(str[i] + C);
                    }
                }
                else
                    input += str[i];
            }
            str = input;
            return str;
        }
        public static string CezarDecipher(this string str, int C) {
            string input = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (((int)str[i] >= (int)'A' && (int)str[i] <= (int)'Z') || ((int)str[i] >= (int)'a' && (int)str[i] <= (int)'z'))
                {
                    if ((int)str[i] - C < (int)'A' || ((int)str[i] > (int)'Z') && (int)str[i] - C < (int)'a')
                    {
                        input += (char)((int)str[i] - C + 26);
                    }
                    else
                    {
                        input += (char)(str[i] - C);
                    }
                }
                else
                    input += str[i];
            }
            str = input;
            return str;
        }
    }
    internal class Program
    {
        static int NumberCezarUp() {
            bool isParse = true;
            int numC = 0;
            do
            {
                try
                {
                    Console.WriteLine("Введите число сдвига для шифра");
                    numC = int.Parse(Console.ReadLine());
                    if (numC > 0 || numC <= 26)
                    {
                        isParse = false;
                    }
                    else
                    {
                        Console.WriteLine("число должно быть от 1 до 26");
                    }
                }
                catch
                {
                    Console.WriteLine("неверно введенно число");
                }
            } while (isParse);
            return numC;
        }
        static void Main(string[] args)
        {
            bool work = true;
            int NumNumerete = 3;
            int numC = 0;
            string strInput = "";
            do
            {
                Console.WriteLine("Выбирите действие:\n1:Зашифровать текст\n2:Расшифровать текст\n3:Закончить работу");
                try
                {
                    NumNumerete = int.Parse(Console.ReadLine());
                    switch (NumNumerete)
                    {

                        case 1:
                            numC = NumberCezarUp();
                            Console.WriteLine("Введите текст");
                            strInput = Console.ReadLine();
                            Console.WriteLine($"Получившийся текст:{strInput.CezarEncrypt(numC)}");break;
                        case 2:
                            numC = NumberCezarUp();
                            Console.WriteLine("Введите текст");
                            strInput = Console.ReadLine();
                            Console.WriteLine($"Получившийся текст:{strInput.CezarDecipher(numC)}"); break;
                        case 3:work = false; break;
                        default: Console.WriteLine("Несуществующий параметр");break;
                    }
                }
                catch {
                    Console.WriteLine( "Неверный ввод числа");
                }
            } while (work);
            

        }
    }
}
