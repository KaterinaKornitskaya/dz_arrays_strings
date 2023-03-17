using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace task1
{
    /*
    Задание 1
    Объявить одномерный (5 элементов) массив с именем A и двумерный массив 
    (3 строки, 4 столбца) дробных чисел с именем B. Заполнить одномерный 
    массив А числами, введенными с клавиатуры пользователем, а двумерный 
    массив В случайными числами с помощью циклов. Вывести на экран значения 
    массивов: массива А в одну строку, массива В — в виде матрицы. 
    Найти в данных массивах общий максимальный элемент, минимальный элемент,
    общую сумму всех элементов, общее произведение всех элементов, сумму 
    четных элементов массива А, сумму нечетных столбцов массива В.
    */
    internal class Program
    {
        static void Main1(string[] args)
        {
            double[] arrA = new double[5];      // объявление одномерного массива, размер 5
            double[,] arrB = new double[3, 4];  // объявление двухмерного массива, размер 3*4
            Console.WriteLine("Fill arr A with 5 numbers: ");
            for (int i = 0; i < arrA.Length; i++)
            {
                arrA[i] = Convert.ToDouble(Console.ReadLine());  // заполнение пользователем
            }
            Console.WriteLine("Array A filled by user: ");
            foreach (double i in arrA)
            {
                Console.Write(i + " ");  // вывод элементов массива А в строку
            }

            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j <4; j++)
                {
                    arrB[i, j] = Math.Round(rand.NextDouble(), 1);  // заполнение рандомными числами
                }
            }
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("Array B filled by random: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j <4; j++)
                {
                    Console.Write(arrB[i, j] + " ");  // вывод элементов массива В в строки
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------");
          
            double maxB = arrB[0, 0];     // переменная для макс элемента массива В
            double minB = arrB[0, 0];     // переменная для мин элемента массива В
            double sumB = 0;              // переменная для суммы элементов массива В
            double prod = 1;              // переменная для общего произведения всех элементов
            double sum_odd_column_B = 0;  // переменная для эл-тов нечетных столбцов массива В
            double sum_evenA = 0;         // переменная для четных эл-тов массива А
            double maxA = arrA.Max();     // макс элемент массива А, применяем метод класса System.Array
            double minA = arrA.Min();     // мин эл-т массива А, применяем метод класса System.Array
            double sumA = arrA.Sum();     // сумма ел-ов массива А, применяем метод класса System.Array

            for (int i = 0; i < arrA.Length; i++)
            {
                prod *= arrA[i];         // общего произведене элементов А
                if (arrA[i]%2==0)        // если элемент А четный (делится на 2 без остатка)
                    sum_evenA+=arrA[i];  // плюсуем эти элементы
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j <4; j++)
                {
                    if (arrB[i, j] > maxB)  // ищем наибольший элемент В
                        maxB = arrB[i, j];
                    if (arrB[i, j]< minB)   // ищем наименьший элемент В
                        minB = arrB[i, j];

                    sumB+=arrB[i, j];       // плюсуем к сумме все элементы В
                    prod*=arrB[i, j];       // умножаем все элементы В
                    if (j%2!=0)             // если индекс j(колонки) нечетный
                        sum_odd_column_B+=arrB[i, j];  // плюсуем к данной переменной                                                           
                }
            }

            Console.WriteLine("Max element in arr A: " + maxA);       // вывод в консоль макс элемента А
            Console.WriteLine("Max element in arr B: " +maxB);        // вывод в консоль макс элемента B
            if (maxA == maxB)                                         // если макс элементы А и В совпадают
                Console.WriteLine("Common max element is: " + maxA);  // выводим элемент как общий
            else
                Console.WriteLine("No common max element");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Min element in arr A: " + minA);       // вывод в консоль мин элемента А
            Console.WriteLine("Min element in arr B: " +minB);        // вывод в консоль мин элемента В
            if (minA == minB)                                         // если мин элементы А и В совпадают
                Console.WriteLine("Common min element is: " + minA);  // выводим элемент как общий
            else
                Console.WriteLine("No common min element");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Sum of elements arr A: " + sumA);                        // вывод в консоль суммы эл-ов А                     
            Console.WriteLine("Sum of elements arr B: " + sumB);                        // вывод в консоль суммы эл-ов В
            Console.WriteLine("Sum of elements from arrA and arrB: " + (sumB + sumA));  // вывод в консоль общей суммы
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("The product of elements from arrA and arrB: " + prod);   // вывод в консоль общего производного
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Sum of even elements arr A: " + sum_evenA);              // вывод в консоль суммы четных эл-тов А
            Console.WriteLine("------------------------------------------");
            Console.WriteLine
                ("Sum of elements in odd columns in arr B: " + sum_odd_column_B);       // вывод в консоль суммы эл-тов нечетных колонок В

        }
    }
}

/*
 Задание 2
 Дан двумерный массив размерностью 5×5, заполненный случайными числами 
 из диапазона от –100 до 100. Определить сумму элементов массива, 
 расположенных между минимальным и максимальным элементами.
*/
namespace task2
{
    internal class Program
    {
        static void Main2(string[] args)
        {
            int size = 5;
            int[,] arr = new int[size, size];  // объявление двухмерного массива 5*5
            Random rand = new Random();
            for (int i = 0; i<size; i++)
            {
                for (int j = 0; j<size; j++)
                {
                    arr[i, j] = rand.Next(-100, 100);  // заполнения рандомными числами -100...100
                }
            }
            for (int i = 0; i<size; i++)
            {
                for (int j = 0; j<size; j++)
                {
                    Console.Write(arr[i, j]+" ");  // вывод матрицы в консоль
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n------------------------------------------");
            
            int[] arr1 = new int[size*size];       // обявление одномерного массива для копирования
                                                   // в него строк из двухмерного, размер 25
            for (int i = 0; i < arr1.Length; i++)  // идем по циклу одномерного 
            {
                for (int j = 0; j < size; j++)     // внутри проходим по двухмерному
                {
                    for (int k = 0; k < size; k++)
                    {
                        arr1[i]= arr[j, k];        // записываем в эл-т одномерного эл-ты из двухмерного
                        i++;                 
                    }
                }
            }

            for (int i = 0; i<arr1.Length; i++)
            {
                Console.Write(arr1[i] + " ");  // вывод на экран 1мерного массива
            }
            Console.WriteLine("\n------------------------------------------");
            int max = arr1.Max();  // ищем макс элемент в 1мерном массиве
            int min = arr1.Min();  // ищем мин элемент в 1мерном массиве
            int max_ind = 0;       // переменная для индекса макс эл-та
            int min_ind = 0;       // переменная для индекса мин эл-та
            int sum = 0;           // переменная для суммы элементов, стоящих между индексами макс и мин
            for (int i = 0; i<arr1.Length; i++)
            {
                if (arr1[i] == max)  // если эл-т максимальный
                    max_ind = i;     // то присваиваем его индекс переменной max_ind
                if (arr1[i] == min)  // если эл-т минимальный
                    min_ind = i;     // то присваиваем его индекс переменной min_ind          
            }

            for(int i = min_ind+1; i < max_ind; i++)  // цикл между индексами макс и мин элементов
            {
                sum+=arr1[i];  // суммируем элементы в диапазоне             
            }
            Console.WriteLine("sum = " + sum);  // вывод в консоль суммы
        }
    }
}

/*
 Задание 3
 Пользователь вводит строку с клавиатуры. Необходимо зашифровать данную 
 строку используя шифр Цезаря. 
 */
namespace task3
{
    internal class Program
    {
        static void Main3(string[] args)
        {
            StringBuilder str2 = new StringBuilder();        // создание строки
            str2.Append("HappZ holidayX! Happy New Year!");  // заполнение строки данными
            
            char[] str = new char[str2.Length];  // создание массива char
            str2.CopyTo(0, str,0, str2.Length);  // копирование данных из строки в массив char
            Console.WriteLine (str);             //  вывод строки в консоль         
            int k = 3;                           // "ключ" - на сколько символов осуществлять сдвиг по алфавиту  
            
            for (int i = 0; i < str.Length; i++)   // цикл по строке char
            {
                int pos = 0;                       // новая позиция по ASCII
                if (str[i] >= 65 && str[i] <= 90)  // если символ - буква в верхнем регистре
                {
                    pos = (str[i]+k);              // новая "позиция" - смещаем букву на k едениц
                    if (pos > 90)                  // если позиция > 90 по ASCII 
                    {
                        pos -= 91;                 // то возвращаемся на 91 назад
                        pos+=65;                   // и добавляем 65 (заново пойдем по буквам ASCII 
                    }
                }                  
                else if (str[i] >= 97 && str[i] <= 122)  // если символ - буква в нижнем регистре
                {
                    pos = (str[i] + k);                  // новая "позиция" - смещаем букву на k едениц
                    if (pos > 122)                       // если позиция > 122 по ASCII
                    {
                        pos -= 123;                      // то возвращаемся на 123 назад
                        pos+=97;                         // и добавляем 97 (заново пойдем по буквам ASCII 
                    }
                }
                Console.Write((char)pos);  // вывод в консоль результата (char-символы)
            }         
        }
    }
}

/*
 Создайте приложение, которое производит операции над матрицами:
 ■ Умножение матрицы на число;
 ■ Сложение матриц;
 ■ Произведение матриц.
*/
namespace task4
{
    internal class Program
    {
        // метод для заполнение двухмерного массива рандомными числами
        static void FillMatrix(int[,] matrix, int row, int col, Random rand)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = rand.Next(1, 10);
                }
            }
        }
        // метод для вывода в консоль двухмерного массива
        static void ShowMatrix(int[,] matrix, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        // метод для умножения двухмерного массива на число;
        static void MultMatrixNum(int[,] matrix, int[,] res_matrix, int row, int col, int num)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    res_matrix[i, j] = matrix[i, j] * num;
                }
            }
        }
        // метод для сложения двух двухмерный массивов
        static void SumMatrix
            (int[,] matrix1, int[,] matrix2, int[,] new_matrix, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    new_matrix[i, j] = matrix1[i, j]+matrix2[i,j];               
                }
            }
        }
        // метод для умножения двух двухмерный массивов
        static void MultMatrixMutrix
            (int[,] matrix1, int[,] matrix2, int[,] new_matrix, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    new_matrix[i, j] = matrix1[i, j] * matrix2[i, j];
                }
            }
        }
        static void Main4(string[] args)
        {
            int row = 3;  // "строки" матрицы
            int col = 4;  // "колонки" матрицы
            int[,] matrix1 = new int[row, col];  // создание и инициализация матрицы 1
            int[,] matrix2 = new int[row, col];  // создание и инициализация матрицы 2

            int[,] matrix_new = new int[row, col];   // создание и инициализация матрицы для хранения результата
            int num = 2;  // число для метода умножения матрицы на число

            Random rand = new Random();
            FillMatrix(matrix1, row, col, rand);  // заполнения матрицы1
            FillMatrix(matrix2, row, col, rand);  // заполнения матрицы2

            int choice;  // переменная для ввода пользователем
           
            do  // цикл продолжить, пока пользователь нажимает 1, 2 или 3
            {
                Console.WriteLine("\nMatrix1: ");
                ShowMatrix(matrix1, row, col);  // вывод в консоль матрицы1
                Console.WriteLine("\nMatrix2: ");
                ShowMatrix(matrix2, row, col);  // вывод в консоль матрицы2

                // вывод в консоль меню:
                Console.WriteLine("\nWhat to do? Enter number (1/2/3)");
                Console.WriteLine("1. Multiplying the matrix1 by a number");
                Console.WriteLine("2. Addition of matrices");
                Console.WriteLine("3. Multiplying of matrices");               
                choice = Convert.ToInt32(Console.ReadLine());  // ввод пользователя             
                Console.Clear();  // очистка экрана
               
                switch (choice)  // выбор метода и вывод в консоль результата в зависимости от выбора пользователя
                {
                    case 1:
                        MultMatrixNum(matrix1, matrix_new, row, col, num);
                        Console.WriteLine("Result: ");
                        ShowMatrix(matrix_new, row, col);
                        break;
                    case 2:
                        SumMatrix(matrix1, matrix2, matrix_new, row, col);
                        Console.WriteLine("Result: ");
                        ShowMatrix(matrix_new, row, col);
                        break;
                    case 3:
                        MultMatrixMutrix(matrix1, matrix2, matrix_new, row, col);
                        Console.WriteLine("Result: ");
                        ShowMatrix(matrix_new, row, col);
                        break;
                }
            } while (choice == 1 || choice == 2 || choice == 3);
        }
    }
}

/*
 Задание 5
 Пользователь с клавиатуры вводит в строку арифметическое выражение. 
 Приложение должно посчитать его результат. Необходимо поддерживать 
 только две операции: + и –.
*/
namespace task5
{
    // в этом задании все работала, пока прописала кмментарии, уже не работает)) и не могу найти, что не так
    internal class Program
    {
        static void Main(string[] args)
        {        
            Console.WriteLine("Enter arithmetic expression with '+' or '-' only"
                + "\nwithout spaces! (for example 2+3 345+7 54-34)");
            
            StringBuilder expression = new StringBuilder(Console.ReadLine());  // создание строки и считывание из консоли
            Console.WriteLine("Expression: " + expression);  // вывод строки в консоль
       
            int[] arr = new int[10];  // массив типа int, для хранения числа из выражения 
            int index = 0;            // переменная для индекса массива

            string str_number = "";   // строка для записи отдельного числа из выражения

            for (int i = 0; i < expression.Length; i++)  // цикл по начальной строке(выражению)
            {
                if ((int)expression[i] >= 48 && (int)expression[i] <= 57)  // если текущий символ - цифра
                {
                    str_number += Convert.ToString(expression[i]);         // записываем цифру в новую строку
                    expression.Remove(i, 1);                               // удаляем цифру из выражения
                    i--;
                    if (expression[i + 1] == '-' ||                // если следующий  символ "-", "+", конец строки
                        expression[i + 1] == '+' ||
                        i + 1 == expression.Length)
                    {
                        arr[index] = Convert.ToInt32(str_number);  // записываем число              
                        index++;                               
                        str_number = "";                           // удаляем данные из строки для нового числа
                    }
                }
            }
           
            int expression_result = arr[0];  // результат выражения
            int symbol = 0;                  // символ в выражении 
            for (int i = 1; i < arr.Length; i++)
            {
                if (expression[symbol] == '+')  // если в выражении "+"
                {
                    expression_result += arr[i];
                }
                else if (expression[symbol] == '-')   // если в выражении "+"
                {
                    expression_result -= arr[i];
                }
                if (symbol != expression.Length - 1) symbol++;
            }            
            Console.WriteLine(" Результат " + expression_result);  // вывод в консоль результата         
        }
    }
}


/*
 Задание 6
Пользователь с клавиатуры вводит некоторый текст. 
Приложение должно изменять регистр первой буквы 
каждого предложения на букву в верхнем регистре.

 */
namespace task6
{
    internal class Program
    {
        static void Main6(string[] args)
        {
            StringBuilder my_str = new StringBuilder(Console.ReadLine());  // создание строки и заполнение
            Console.WriteLine("My string: \n" + my_str);                   // вывод в консоль строки

            StringBuilder symbols = new StringBuilder("!?.");  // создание строки с возможными символами "!?."

            for (int i = 0; i < my_str.Length; i++)  // цикл по строке
            {
                if (i == 0 && my_str[i] >= 97 &&  my_str[i] <= 122)  // если первая буква (на 0 позиции) в нижнем регистре
                {
                    my_str[i] = (char)(my_str[i]-32);                // меням регистр на верхний (-32 по ASCII)
                }
                for (int j = 0; j < symbols.Length; j++)  // цикл по массиву символов "!?."
                {
                    // если символ строки это один из символов "!?." и следующий символ "пробел" и следующий символ
                    // в нижнем регистре
                    if (my_str[i] == symbols[j] && my_str[i+1] ==32 && my_str[i+2] >= 97 && my_str[i+2] <= 122)
                    {
                         my_str[i+2] = (char)(my_str[i+2]-32);  // то меням регистр на верхний (-32 по ASCII)
                    }
                }           
            }
            Console.WriteLine("Edit string: \n" + my_str);  // вывод в консоль
        }
    }
}


/*
 Задание 7
Создайте приложение, проверяющее текст на недопустимые слова. Если
недопустимое слово найдено, оно должно быть заменено на набор 
символов *. По итогам работы приложения необходимо показать статистику 
действий. 
 */
namespace task7
{   
    internal class Program
    {
        static void Main7(string[] args)
        {
            Console.WriteLine("Start text: ");
            string str = "\nAnd by opposing end them? To die: to sleep" +
                "\nNo more; and by a sleep to say we end";  // строка с исходным текстом
            Console.WriteLine(str);    // вывод в консоль исходного текста
            string search = "sleep";   // строка с искомым словом для замены
            Console.WriteLine("\nWord for replace: " + search);  // вывод в консоль слова для замены          
            string replace = "*****";  // строка с символами для замены
            string final = str;        // строка для финального текста
            final = final.Replace(search, replace);         // замена в финальной строке: вместо search ставим  replace
            Console.WriteLine("\nFinal text: \n" + final);  // вывод в консоль финальной строки
            
            int fr = str.Count(search);  // количество замен
            Console.WriteLine("\nNumber of replacements: " + fr); // вывод в консоль кол-ва замен     
        }
    }
    // класс и функция для поиска колличесвта замененных слов
    // нашла в интернете, потому что циклами никак не получается у меня посчитать замены
    // (саму замену сделала сама без проблем, а посчитать кол-во не знаю как)
    public static class StringExtension
    {
        public static int Count(this string input, string substr)
        {
            return Regex.Matches(input, substr).Count;
        }
    }
}
