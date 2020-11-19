using System;

namespace GDI_Task_06
{
    class Program
    {

        static string[] DefName = { "Яблонцев Мефодий Денисович", "Никитина Антонина Кузьмевна", //Дефолтные массивы, которые можно использовать вместо составления своих
                                    "Пороник Михаил Михаилович", "Блинова Кира Юрьевна",
                                    "Баландина Лиана Сигизмундовна", "Наполов Харитон Мартьянович", 
                                    "Артемьев Вадим Всеволодович", "Ратников Феоктист Матвеевич", 
                                    "Плюхина Юлия Наумовна", "Близнюк Марианна Григоргиевна" };
        static string[] DefPosition = { "Менеджер", "ген. Директор", 
                                        "Зав-хоз", "Менеджер", 
                                        "Программист", "Зав-хоз", 
                                        "Менеджер", "Программист", 
                                        "Сисадмин", "Менеджер" };

        static void Addfile(ref string[] N, ref string[] P)//Добавление досье
        {
            string[] boof;

            string s;
            int count;


        reN:
            Console.Write("Отмена: -\nВведите ФИО сотрудника: ");
            s = Console.ReadLine();

            count = N.Length;
            boof = new string[count];

            if ((s != "") && (s != "-"))//Ввод имени
            {
                count++;
                boof = N;
                N = new string[count];

                for (int i = 0; i < count - 1; i++)
                    N[i] = boof[i];

                N[count - 1] = s;
            }
            else if (s == "")//проверка на пустоту
            {
                Console.WriteLine("Ошибка!!! Строка пуста! Для отмены введите -");
                goto reN;
            }
            else if (s == "-") return;//отмена операции

            reP:
            Console.Write("Введите Должность сотрудника: ");
            s = Console.ReadLine();

            if (s != "")//Ввод должности
            {
                boof = P;
                P = new string[count];

                for (int i = 0; i < count - 1; i++)
                    P[i] = boof[i];

                P[count - 1] = s;
                
            }
            else if (s == "")
            {
                Console.WriteLine("Ошибка!!! Строка пуста!");
                goto reP;
            }
        }

        static void Find(string[] N, string[] P)//Метод поиска по имени
        {
            string F;
            bool Fin;
            Masout(N, P);

            Console.Write("Введите ФИО для поиска: ");
            F = Console.ReadLine();
            
            Console.Clear();
            for (int i = 0; i < N.Length; i++)
            {
                Fin = N[i].Contains(F, StringComparison.CurrentCultureIgnoreCase);//поиск совпадений без учёта регистра
                if(Fin == true)
                {
                    Console.WriteLine($"{i + 1}.\t{N[i]}-\t{P[i]}");
                }
            }
            Console.ReadKey();
        }

        static void Masout(string[] N, string[] P) //Вывод массивов с данными 
        {
            for(int i = 0; i < N.Length; i++)
            {
                Console.WriteLine($"{i+1}.\t{P[i]}  \t-{N[i]}");
            }
            Console.ReadKey();
        }

        static void Del(ref string[] N, ref string[] P)//Метод удаления данных
        {
            int DelNum;
            string[] DelBoofN, DelBoofP;

            del:
            Console.WriteLine("Введите номер досье для удаления.");
            Console.WriteLine("Если вы не знаете номер досье: введите 0 и в меню выбирете поиск");
            Console.Write(">");
            DelNum = Convert.ToInt32(Console.ReadLine());

            if (DelNum <= 0)
            {
                return;
            } else if(DelNum > N.Length)
            {
                Console.WriteLine("Досье с таким номером не существует!");
                Console.ReadKey();
                Console.Clear();
                goto del;
            }

            DelNum--;
            DelBoofN = N;
            DelBoofP = P;

            if (DelNum != N.Length) {
                for (int i = DelNum--; i < N.Length-1; i++)
                {
                    DelBoofN[i] = DelBoofN[i + 1];
                    DelBoofP[i] = DelBoofP[i + 1];
                }
                N = new string[DelBoofN.Length - 1];
                P = new string[DelBoofP.Length - 1];

                for (int i = 0; i < N.Length; i++)
                {
                    N[i] = DelBoofN[i];
                    P[i] = DelBoofP[i];
                }
            }
            else
            {
                N = new string[DelBoofN.Length - 1];
                P = new string[DelBoofP.Length - 1];

                for (int i = 0; i < N.Length; i++)
                {
                    N[i] = DelBoofN[i];
                    P[i] = DelBoofP[i];
                }
            }

            Console.WriteLine("Удаление успешно завершенно!");
            Console.ReadKey();

        }

        static void Menu(ref string[] N, ref string[] P)//Метод интерфейса
        {
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                Console.WriteLine(@" _       __     __                        
| |     / /__  / /________  ____ ___  ___ 
| | /| / / _ \/ / ___/ __ \/ __ `__ \/ _ \
| |/ |/ /  __/ / /__/ /_/ / / / / / /  __/
|__/|__/\___/_/\___/\____/_/ /_/ /_/\___/");

                Console.WriteLine('\n');
                Console.WriteLine("Управление:");
                Console.WriteLine("+ - Добавить досье.");
                Console.WriteLine("* - Поиск досье по ФИО.");
                Console.WriteLine("/ - Вывести все досье.\n");


                Console.WriteLine("Пробел - Использовать заранее заготовленные массивы.");
                Console.WriteLine("Delete - Удаление досье.\n");
                Console.WriteLine("Esc - Выход.");

                key = Console.ReadKey(true);

                if(key.Key == ConsoleKey.Add)
                {
                    Console.Clear();
                    Addfile(ref N, ref P);

                }else if(key.Key == ConsoleKey.Divide)
                {
                    Console.Clear();
                    Masout(N, P);

                }else if (key.Key == ConsoleKey.Multiply)
                {
                    Console.Clear();
                    Find(N, P);
                }else if (key.Key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    N = DefName;
                    P = DefPosition;
                }else if (key.Key == ConsoleKey.Delete)
                {
                    Console.Clear();
                    Del(ref N, ref P);
                }
            } while (key.Key != ConsoleKey.Escape);

            Console.Clear();
            Console.WriteLine(@"   ______                ____             
  / ____/___  ____  ____/ / /_  __  _____ 
 / / __/ __ \/ __ \/ __  / __ \/ / / / _ \
/ /_/ / /_/ / /_/ / /_/ / /_/ / /_/ /  __/
\____/\____/\____/\__,_/_.___/\__, /\___/ 
                             /____/       ");
        }


        static void Main(string[] args)
        {
            string[] Name = new string[0]; 
            string[] Position = new string[0];//Объявление рабочих массивов

            int origWidth, origHeight;

            origWidth = Console.WindowWidth;//Настраиваем окно командной строки
            origHeight = Console.WindowHeight;

            Console.SetWindowSize(origWidth / 2, origHeight);

            Menu(ref Name, ref Position);
        }
    }
}
