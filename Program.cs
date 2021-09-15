using System;
using System.Collections.Generic;

namespace PSWD_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 10000;
            List<string> list;

            while (true)
            {
                Console.WriteLine("Hello World!");
                Console.WriteLine("===============================================");
                pswd p = new pswd();
                newPassword pswd = new newPassword();
                Console.WriteLine(p.GetPswd(6, true, true, 3, true, 3));
                Console.WriteLine(p.GetPswd(8, false, true, 3, true, 3));
                Console.WriteLine(p.GetPswd(16, true, false, 3, true, 3));
                Console.WriteLine(p.GetPswd(32, true, true, 3, false, 3));
                Console.WriteLine(p.GetPswd(64, true, false, 3, false, 3));
                Console.WriteLine(p.GetPswd(128, false, false, 3, false, 3));
                Console.WriteLine("===============================================");
                Console.WriteLine(pswd.GetNewPassword(6, true, true, 3, true, 3));
                Console.WriteLine(pswd.GetNewPassword(8, false, true, 3, true, 3));
                Console.WriteLine(pswd.GetNewPassword(16, true, false, 3, true, 3));
                Console.WriteLine(pswd.GetNewPassword(32, true, true, 3, false, 3));
                Console.WriteLine(pswd.GetNewPassword(64, true, false, 3, false, 3));
                Console.WriteLine(pswd.GetNewPassword(128, false, false, 3, false, 3));
                Console.WriteLine("===============================================");
                Console.ReadLine();
            }
        }
    }

    public class newPassword
    {
        static string[] let = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        static string[] LET = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        static string[] numb = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        static string[] symb = new string[] { "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "+", "|", "{", "}", ":", "<", ">", "?", "\"", "№", ";", "%", ":", "/", "-", "=", "\\", ".", "`", "[", "]", ";", "'", "," };

        static Random letRND = new Random();
        static Random LETRND = new Random();
        static Random numbRND = new Random();
        static Random symbRND = new Random();

        public string GetNewPassword(int Lengh, bool Uppercase, bool Numbers, int MinNumbers, bool Symbols, int MinSymbols)
        {
            string NewPassword = null;
            string str_numb = null;
            string str_symb = null;


            int length;
            if (Numbers && Symbols)
                 length = (Lengh - MinNumbers - MinSymbols);//резервируем 
            else if (!Numbers && Symbols)
                 length = (Lengh - MinSymbols);//резервируем 
            else if (Numbers && !Symbols)            
                length = (Lengh - MinNumbers - MinSymbols);//резервируем 
                else
                    length = Lengh;

            if (Numbers)
            {
                str_numb = GetNumbers(MinNumbers);
            }

            if (Symbols)
            {
                str_symb = GetSymbols(MinSymbols);
            }

            if (Uppercase)
            {
               
                for (int i = 0; i < length; i++)
                {
                    NewPassword += GetLetandlet(Uppercase);//добовляем в NewPassword большие и маленькие буквы
                }
            }
            else
            {
                
                for (int i = 0; i < length; i++)
                {
                    NewPassword += GetLetandlet(Uppercase);//добовляем в NewPassword большие и маленькие буквы
                }
            }


            NewPassword += str_numb + str_symb; // собираем все вместе

            NewPassword = Mix(NewPassword);//перемешиваем


            return NewPassword;// возвращаем
        }

        private string Mix(string newPassword)
        {
            char[] array = newPassword.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }

        private string GetLetandlet(bool uppercase)
        {
            if (uppercase)
            {
                Random r = new Random();
                int i = r.Next(1, 3);
                if (i == 1)
                {
                    return LET[LETRND.Next(0, LET.Length - 1)];
                }
                else return let[letRND.Next(0, let.Length - 1)];
            }
            return let[letRND.Next(0, let.Length - 1)];
        }

        private string GetSymbols(int minSymbols)
        {
            string s=null;

            for (int i = 0; i < minSymbols; i++)
            {
                s += numb[numbRND.Next(0, numb.Length - 1)];
            }
            return s;
        }

        private string GetNumbers(int minNumbers)
        {
            string s = null;

            for (int i = 0; i < minNumbers; i++)
            {
                s += symb[symbRND.Next(0, symb.Length - 1)];
            }
            return s;
        }
    }


    public class pswd
    {
        static string[] let = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        static string[] LET = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        static string[] numb = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        static string[] symb = new string[] { "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "+", "|", "{", "}", ":", "<", ">", "?", "\"", "№", ";", "%", ":", "/", "-", "=", "\\", ".", "`", "[", "]", ";", "'", "," };

        static Random letRND = new Random();
        static Random LETRND = new Random();
        static Random numbRND = new Random();
        static Random symbRND = new Random();
        static Random DelicacyRND = new Random();

        static int curNumbers = 0; //проверка количества цифр
        static int curSymbols = 0; // проверка количества символов
        static int curLet; // проверка количества символов

        public string GetPswd(int Lengh, bool Uppercase, bool Numbers, int MinNumbers, bool Symbols, int MinSymbols)
        {            
            string pswd = null;
                       
            for (int i = 0; i < Lengh; i++)
            {
                pswd += GetString(Uppercase, Numbers, MinNumbers, Symbols, MinSymbols); 
            }

            return pswd;
        }

        static string GetString(bool uppercase, bool numbers, int minNumbers, bool symbols, int minSymbols)
        {      
            if (uppercase & numbers & symbols)
            {
                int i = DelicacyRND.Next(1, 5);
                if (i == 4)
                {
                    return LET[LETRND.Next(0, LET.Length - 1)];
                }
                else if (i == 3)
                {
                    curNumbers++;
                    if (true)
                    {
                        return numb[numbRND.Next(0, numb.Length - 1)];
                    }
                }
                else if (i == 2)
                {
                    curSymbols++;
                    return symb[symbRND.Next(0, symb.Length - 1)];
                }

                else return let[letRND.Next(0, let.Length - 1)];

            }
            else if (!uppercase & numbers & symbols)
            {
                int i = DelicacyRND.Next(1, 4);
                if (i == 3)
                    return numb[numbRND.Next(0, numb.Length - 1)];
                else if (i == 2)
                    return symb[symbRND.Next(0, symb.Length - 1)];
                else return let[letRND.Next(0, let.Length - 1)];

            }
            else if (uppercase & !numbers & symbols)
            {
                int i = DelicacyRND.Next(1, 4);
                if (i == 3)
                    return LET[LETRND.Next(0, LET.Length - 1)];
                else if (i == 2)
                    return symb[symbRND.Next(0, symb.Length - 1)];
                else return let[letRND.Next(0, let.Length - 1)];

            }
            else if (uppercase & numbers & !symbols)
            {
                int i = DelicacyRND.Next(1, 4);
                if (i == 3)
                    return LET[LETRND.Next(0, LET.Length - 1)];
                else if (i == 2)
                    return numb[numbRND.Next(0, numb.Length - 1)];
                else return let[letRND.Next(0, let.Length - 1)];

            }
            else if (!uppercase & !numbers & symbols)
            {
                int i = DelicacyRND.Next(1, 2);
                if (i > 1)
                {
                    return symb[symbRND.Next(0, symb.Length - 1)];
                }

                return let[letRND.Next(0, let.Length - 1)];
            }
            else if (uppercase & !numbers & !symbols)
            {
                int i = DelicacyRND.Next(1, 3);
                if (i>1)
                {
                    return LET[LETRND.Next(0, LET.Length - 1)];
                }

                return let[letRND.Next(0, let.Length - 1)];
            }
            else if (!uppercase & numbers & !symbols)
            {
                if (curNumbers != minNumbers)
                {
                    int i = DelicacyRND.Next(1, 2);
                    if (i > 1)
                    {
                        curNumbers++;
                        return numb[numbRND.Next(0, numb.Length - 1)];
                    }
                }                
                
                    return let[letRND.Next(0, let.Length - 1)];                
            }
            else
            {
                return let[letRND.Next(0,let.Length-1)];
            }
        }
    }
}
