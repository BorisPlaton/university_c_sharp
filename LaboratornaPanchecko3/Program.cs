﻿namespace Lab
{

    class Program
    {

        static int[] UserInput()
        {
            Console.WriteLine("Как вы хотите заполнить массив? 1 - вручную, 2 - случайным образом, 3 - через файл");
            int answer = int.Parse(Console.ReadLine());
            int[] array;
            if (answer == 1)    // Ручной ввод
            {

                Console.Write("Введите количество элементов массива - ");
                int size = int.Parse(Console.ReadLine());
                array = new int[size];
                Console.WriteLine("Вводите элементы массива:");
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = int.Parse(Console.ReadLine());
                }

            }
            else if (answer == 2)   // Заполнение массива случайным образом
            {
                Random rnd = new Random();
                Console.Write("Введите количество элементов массива - ");
                int size = int.Parse(Console.ReadLine());
                array = new int[size];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(-25, 25);
                }
            }
            else if (answer == 3)   // Ввод из файла
            {

                Console.Write("Введите количество элементов массива в файле numbers.txt - ");
                int size = int.Parse(Console.ReadLine());
                StreamReader sRead = new StreamReader("numbers.txt");
                array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = Convert.ToInt32(sRead.ReadLine());
                }
                sRead.Close();
            }
            else    // Если неверный ввод
            {
                throw new ArgumentException("Неверный ввод данных");
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
            return array;
        }

        static int NegativeAmount(int[] mas)    // Количество отрицательных чисел в одномерном массиве 
        {
            int amount = 0;
            foreach (int elem in mas)
            {
                if (elem < 0)
                {
                    amount++;
                }
            }
            return amount;
        }

        static int PositiveAmount(int[] mas)    // Количество положительных чисел в одномерном массиве 
        {
            int amount = 0;
            foreach (int elem in mas)
            {
                if (elem > 0)
                {
                    amount++;
                }
            }
            return amount;
        }

        static Tuple<int[], int[]> CreateTwoArray(int[] mas)    // Два массива
        {
            int size = mas.Length / 2;
            int[] array1 = new int[size + 1];   // четные
            int[] array2 = new int[mas.Length - size];  // нечетные
            int chet, nechet;
            chet = 0;
            nechet = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (i % 2 == 0)
                {
                    array1[chet] = mas[i];
                    chet++;
                }
                else
                {
                    array2[nechet] = mas[i];
                    nechet++;
                }
            }
            return Tuple.Create(array1, array2);
        }

        static double Sum(int[] mas)    // Сумма элементов массива
        {
            int sum = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                sum += mas[i];
            }
            return sum;
        }

        static double AverageSum(int[] mas)     // Среднее арифметическое в одномерном массиве 
        {
            double sum = 0;
            foreach (int elem in mas)
            {
                sum += elem;
            }
            double average = sum / mas.Length;
            return average;
        }

        static int FirstNegative(int[] mas)     // Первый отрицательный элемент в массиве
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] < 0)
                {
                    return i;
                }
            }
            return -1;
        }

        static int LastNegative(int[] mas)     // Последний отрицательный элемент в массиве
        {
            int neg = -1;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] < 0)
                {
                    neg = i;
                }
            }
            return neg;
        }

        static int LastPositive(int[] mas)  // Последний положительный элемент
        {
            int index = -1;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > 0)
                {
                    index = i;
                }
            }
            return index;
        }

        static int FirstPositive(int[] mas)     // Первый положительный элемент в массиве
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > 0)
                {
                    return i;
                }
            }
            return -1;
        }

        static int SumPositive(int[] mas)   // Сумма только положительных элементов массива
        {
            int sum = 0;
            foreach (int elem in mas)
            {
                if (elem > 0)
                {
                    sum += elem;
                }
            }
            return sum;
        }

        static int MaxNegative(int[] mas)   // Максимальный отрицательный элемент массива
        {
            int maxNeg = -1;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] < 0 & maxNeg == -1)
                {
                    maxNeg = i;
                }
                else if (mas[i] < 0 & mas[maxNeg] < mas[i])
                {
                    maxNeg = i;
                }
            }
            return maxNeg;
        }

        static int[] chetNechet(int[] mas)  // Замена четных и нечетных элементов местами
        {
            int[] newMas = new int[mas.Length];
            if (newMas.Length % 2 != 0)
            {
                newMas[mas.Length - 1] = mas[mas.Length - 1];
            }
            if (mas.Length > 1)
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    if (i + 1 < mas.Length)
                    {
                        newMas[i] = mas[i + 1];
                        newMas[i + 1] = mas[i];
                        i++;
                    }
                }
            }
            else
            {
                return mas;
            }
            return newMas;
        }

        static int[] sortMaxtoMin(int[] mas) // Сортировка по убыванию
        {
            int q;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] < mas[j])
                    {
                        q = mas[i];     
                        mas[i] = mas[j];
                        mas[j] = q;
                    }

                }


            }
            return mas;
        }

        static int[] sortMintoMax(int[] mas)    // Сортировка по возрастанию
        {
            int q;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        q = mas[i];
                        mas[i] = mas[j];
                        mas[j] = q;
                    }

                }


            }
            return mas;
        }

        static int[] MoveOn(int[] mas, int value)   // Смещение элементов
        {
            List<int> list = new List<int>();
            for (int i = mas.Length - value; i < mas.Length; i++)
            {
                list.Add(mas[i]);
            }
            for (int i = 0; i < mas.Length - value; i++)
            {
                list.Add(mas[i]);
            }
            return list.ToArray();
        }

        static void Main(string[] args)
        {
            // 1
            /*int[] array = UserInput();
            int negative = NegativeAmount(array);
            int positive = PositiveAmount(array);
            double average = AverageSum(array);
            Console.WriteLine("Отрицательных чисел - {0}, Положительных чисел - {1}, Среднее арифм. - {2:f3}", negative, positive, average);

            Console.WriteLine();

            // 2
            int[] array2 = UserInput();
            int[] array21 = CreateTwoArray(array2).Item1;
            int[] array22 = CreateTwoArray(array2).Item2;
            Console.WriteLine("Сумма четного массива - {0};\nСумма нечетного массива - {1}", Sum(array21), Sum(array22));

            Console.WriteLine();

            //3
            int[] array3 = UserInput();
            int lstP, fstN;
            lstP = LastPositive(array3);
            fstN = FirstNegative(array3);
            if (lstP > -1 && fstN > -1)
            {
                Console.WriteLine("Среднее арифм. - {0:f3}, последний положительный - {1}, первый отрицательный - {2}", AverageSum(new int[] { array3[lstP], array3[fstN] }), array3[lstP], array3[fstN]);
            }
            else
            {
                Console.WriteLine("Массив не удовлетворяет входным данным");
            }

            Console.WriteLine();

            //4
            int[] array4 = UserInput();
            int max = array4.Max();
            int index = Array.LastIndexOf(array4, max);
            Console.WriteLine("Количество отрицательных элементов перед наибольшим положительным числом - {0}", NegativeAmount(array4[1..index]));

            Console.WriteLine();

            //5
            int[] array5 = UserInput();
            int lstP1, fstP1;
            lstP1 = LastPositive(array5);
            fstP1 = FirstPositive(array5);
            int j = array5[lstP1];
            array5[lstP1] = array5[fstP1];
            array5[fstP1] = j;

            Console.WriteLine();

            //6
            int[] array6 = UserInput();
            Console.WriteLine("Сумма элементов массива - {0}, среднее арифм. - {1}", Sum(array6), AverageSum(array6);

            Console.WriteLine();

            // 7
            int[] array7 = UserInput();
            int sum = 0;
            foreach (int elem in array7)
            {
                if (elem > 0)
                {
                    sum += elem;
                }
            }
            Console.WriteLine("Сумма положительных элементов массива - {0}", sum);

            Console.WriteLine();

            // 8
            int[] array8 = UserInput();
            Console.WriteLine("Сумма четных элементов массива - {0}", Sum(CreateTwoArray(array8).Item1));

            Console.WriteLine();

            // 9
            int[] array9 = UserInput();
            int maxPositive = array9.Max();
            int maxNegativeValue = MaxNegative(array9);
            Console.WriteLine("Максимальный отрицательный - {0}, Максимальный положительный - {1}", maxNegativeValue, maxPositive);

            Console.WriteLine(); 

            // 10
            int[] array10 = UserInput();
            List<int> indexes = new List<int>();
            for (int i = 0; i < array10.Length; i++)
            {
                if (array10[i] > 0)
                {
                    indexes.Add(i);
                }
            }
            Console.Write("Индексы положительных элементов - ");
            foreach (int i in indexes)
            {
                Console.Write("{0} ", i);
            }

            Console.WriteLine(); 

            // 11
            int[] array11 = UserInput();
            double sum1 = 0;
            foreach (int item in array11)
            {
                sum1 += Math.Abs(item);
            }
            Console.WriteLine("Среднее арифметическое - {0:f3}", sum1/array11.Length);

            Console.WriteLine(); 

            // 12
            int[] array12 = UserInput();
            int c = 0;
            int i12 = -1;
            for (int i = 0; i < array12.Length; i++)
            {
                if (array12[i] > 0 & c < 3)
                {
                    c++;
                }
                else if (array12[i] > 0 & c > 3)
                {
                    c = array12[i];
                    i12 = i;
                    break;
                }
            }
            Console.WriteLine("Третий положительный элемент и его индекс - {0}, {1}", c, i12);

            Console.WriteLine();

            // 13
            int[] array13 = UserInput();
            int c = 0;
            int i13 = -1;
            for (int i = 0; i < array13.Length; i++)
            {
                if (array13[i] > 0 & c < 3)
                {
                    c++;
                }
                else if (array13[i] > 0 & c > 3)
                {
                    c = array13[i];
                    i13 = i;
                    break;
                }
            }
            Console.WriteLine("Третий положительный элемент и его индекс - {0}, {1}", c, i13);

            Console.WriteLine(); 

            // 14 
            int[] array14 = UserInput();
            Console.WriteLine("Максимальный элемент и его индекс - {0}, {1}", array14.Max(), Array.IndexOf(array14, array14.Max());

            Console.WriteLine();

            // 15
            int[] array15 = UserInput();
            int[] newArray15 = chetNechet(array15);
            for (int i = 0; i < newArray15.Length; i++)
            {
                Console.Write("{0} ", newArray15[i]);
            }

            Console.WriteLine(); 

            // 16
            int[] array16 = UserInput();
            int min16 = array16.Min();
            int c16 = 0;
            for (int i = 0; i < array16.Length; i++)
            {
                if (array16[i] < 0 & c16 < 1)
                {
                    c16++;
                }
                else if (array16[i] < 0 & c16 == 1)
                {
                    int j16 = min16;
                    array16[Array.IndexOf(array16, min16)] = array16[i];
                    array16[i] = j16;
                }
            }
            Console.WriteLine("Новый массив - {0}", array16); 
            
            Console.WriteLine(); 

            // 17
            int[] array17 = UserInput();
            Console.WriteLine("Упорядоченный массив: ");
            foreach (int item in sortMaxtoMin(array17))
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine(); 

            // 18
            int[] array18 = UserInput();
            Console.WriteLine("Упорядоченный массив: ");
            foreach (int item in sortMintoMax(array18))
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine(); 

            // 19
            int[] array19 = UserInput();
            Console.WriteLine("Новый порядок массива массив: ");
            Array.Reverse(array19);
            foreach (int item in array19)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine(); 

            // 20
            int[] array20 = UserInput();
            array20 = MoveOn(array20, 2);
            foreach (int item in array20)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine(); 

            // 21
            int[] array21 = UserInput();

            List<int> listPos = new List<int>();
            List<int> listNeg = new List<int>();
            foreach (int item in array21)
            {
                if (item > 0)
                {
                    listPos.Add(item);
                }
                else
                {
                    listNeg.Add(item);  
                }
            }
            Console.WriteLine("Положительные элементы:");
            foreach (int item in listPos)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine("\nОтрицательные элементы:");
            foreach (int item in listNeg)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine(); 

            // 22
            int[] array22 = UserInput();
            int nN22 = array22[FirstNegative(array22)];
            int lN22 = array22[LastNegative(array22)];
            Console.WriteLine("Сумма первого и последнего отрицательного элемента: {0}", nN22 +lN22);

            Console.WriteLine(); 

            // 23
            int[] array23 = UserInput();
            int f23;
            int l23;
            bool f = false;
            bool f2 = false;
            foreach (int item in array23)
            {
                if (item % 2 != 0 & f == false)
                {
                    f23 = item;
                    f= true;
                }
                else
                {
                    l23 = item;
                    f2 = true;
                }
            }
            if (f == true & f2 == true)
            {
                Console.WriteLine("Сумма первого и последнего нечетного элемента: {0}", f23 - l23);
            }
            else
            {
                Console.WriteLine("Нечетных элементов нет: {0}", f23 - l23);
            }

            Console.WriteLine(); 

            // 24
            int[] array24 = UserInput();
            Console.WriteLine("Индекс наибольшего - {0}, индекс наименьшего - {1}", Array.IndexOf(array24, array24.Max()), Array.IndexOf(array24, array24.Min()));

            Console.WriteLine(); */

            // 25


        }

    }

}
