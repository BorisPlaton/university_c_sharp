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
            int[] array1 = new int[size + 1];
            int[] array2 = new int[mas.Length - size];
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

        static double Sum(int[] mas)
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

        static int FirstNegative(int[] mas)
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

        static int LastPositive(int[] mas)
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


        static void Main(string[] args)
        {
            // 1
            int[] array = UserInput();
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

        }

    }

}
