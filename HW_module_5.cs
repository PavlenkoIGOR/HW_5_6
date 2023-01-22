using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_5_6_HW
{
    internal class HW_module_5
    {
        static void Main(string[] args)
        {
            var massData = UsrData();
            Console.WriteLine("\n\tитак: " + Environment.NewLine);
            PrintData(massData.name, massData.surname, massData.age, massData.havePet, massData.qPet, massData.favColors, massData.nicknamesOfPets);
            Console.ReadKey();
        }

//метод выводящий на экран кортеж
static void PrintData(string name, string surname, int age, bool havePet, int qPet, string[] favColors, string[] nicknamesOfPets)
        {
            Console.WriteLine("\t\tИмя: {0}", name);
            Console.WriteLine("\t\tФамилия: {0}", surname);
            Console.WriteLine("\t\tВозраст: {0}", age);
            Console.WriteLine("\t\tКоличество животных: {0}", qPet);
            int i = 0;
            foreach (var item in favColors)
            {
                Console.WriteLine($"\t\tЛюбимый цвет №{i+1}: " + favColors[i]);
                i++;
            }
            int n = 0;
            foreach (var item in nicknamesOfPets)
            {
                Console.WriteLine($"\t\tКличка животного №{n+1}: " + nicknamesOfPets[n]);
                n++;
            }

        }

//метод с возвращаемым кортежем данных о пользователе
        static (string name, string surname, int age, bool havePet, int qPet, string[] favColors, string[] nicknamesOfPets) UsrData()
        {
            bool havePet;

            Console.Write("Enter your name: ");
            string name = CorrectiveString(Console.ReadLine());

            Console.Write("Enter your surname: ");
            string surname = CorrectiveString(Console.ReadLine());

            Console.Write("Enter your age: ");
            int age = Corrective(Console.ReadLine());

            Console.Write("how many favourite colors?: ");
            string[] favColors = FavColors(Corrective(Console.ReadLine()));

            int qPet;
            Console.Write("Have a pet?(y/n): ");
            char choice = CorrectiveChoice(Console.ReadLine());
            

                if (choice == 'y')
                {
                    havePet = true;
                    Console.Write("how many?:");
                    qPet = Corrective(Console.ReadLine());

                }
                else
                {
                    havePet = false;
                    qPet = 0;
                }
            
            //while (choice != 'y' | choice != 'n');
            string[] nicknamesOfPets = Pets(qPet);


            var result = (name, surname, age, havePet, qPet, favColors, nicknamesOfPets);

            return result;
        }

//метод, хранящий введенные цвета
        static string[] FavColors(int q)
        {
            string [] favColors = new string[q];
            for (int i = 0; i < q; i++)
            {
                Console.Write($"\tfavourite color {i+1}: ");
                 favColors[i] = Console.ReadLine();
            }
            return favColors;
        }

//метод с данными о питомцах
        static string[] Pets(int q)
        {
            var nicknames = new string[q];
            for (int i = 0; i < nicknames.Length; i++)
            {
                Console.Write($"\tenter nickname {i+1}: ");
                nicknames[i] = Console.ReadLine();
            }
            return nicknames;
        }

//метод проверяющий корректность ввода для числоввых данных 
        static int Corrective(string xParse)
        {
            bool xyz = int.TryParse(xParse, out int num);
            int abc;
            if (num > 0)
            {
                return num;
            }
            else
            {
                do
                {
                    Console.WriteLine("error!");
                    Console.Write("incorrect data! enter again!: ");
                    xParse = Console.ReadLine();
                    xyz = int.TryParse(xParse, out abc);
                } while (xyz == false & abc <= 0);
                return abc;
            }
        }

//метод проверяющий корректность ввода для строковых данных 
        static string CorrectiveString(string sParse)
        {
            bool xyz = int.TryParse(sParse, out int num);
            if (xyz == false)
            {
                return sParse;
            }
            else
            {
                do
                {
                    Console.WriteLine("error!");
                    Console.Write("incorrect data! enter again!: ");
                    sParse = Console.ReadLine();
                    xyz = int.TryParse(sParse, out int abc);
                } while (xyz == true);
                return sParse;
            }
        }

//метод проверяющий введен символ или строка
        static char CorrectiveChoice(string choice)
        {
            char b;
            bool c = char.TryParse(choice, out char result);
            if (c == true & (result == 'y' | result == 'n'))
            {
                return result;
            }
            else
            {
                do
                {
                    Console.WriteLine("error!");
                    Console.Write("incorrect data! enter again!(y/n): ");
                    choice = Console.ReadLine();
                    c = char.TryParse(choice, out b);
                    if (b == 'y' | b == 'n')
                    {
                        return b;
                    }
                } while ((c == false) | (b != 'y' | b != 'n')); //повторяется, если условие в скобках выполнено
                return b;
            }
        }
    }
}





