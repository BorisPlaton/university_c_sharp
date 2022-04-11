namespace Lab
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
            int maxNeg= -1;
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

            Console.WriteLine(); */

            // 13

        }

    }

}
