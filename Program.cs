//Перемножение двух матриц
Console.Clear();

//Метод ввода
int EnterNumber(string message)
{
    Console.Write(message);
    int result = int.Parse(Console.ReadLine());
    return result;
}

//Метод создания массива
var CreateTwodimensionalArray = (int sizeCol, int sizeRow) => new int[sizeCol, sizeRow];

//Метод вывода массива
void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

//Метод рандомного заполнения массива
void RandomFillArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(1, 10);
        }
    }
}

//Метод создания результирующего массива
//TODO : var CreateResultArray = (int[,] arr_1, int[,] arr_2) => new int[arr_1.GetLength(0), arr_2.GetLength(1)];

//Метод проверки матриц количесво стобцов одной на количество строк в другой
var ValidateMatrix = (int[,] arr_1, int[,] arr_2) => arr_1.GetLength(1) == arr_2.GetLength(0);

//Метод перемножения двух двухмерных массивов
/* TODO : int[,] MultiplactionArray(int[,] arr_1, int[,] arr_2)
{
    //Создание результирующего массива и его размера
    int[,] arrayResult = new int[arr_1.GetLength(0), arr_2.GetLength(1)];

    int P = arr_1.GetLength(1);
    int sum = 0;

    for (int i = 0; i < arrayResult.GetLength(0); i++)
    {
        for (int j = 0; j < arrayResult.GetLength(0); j++)
        {
            for (int k = 0; k < P; k++)
            {
                sum += arr_1[i, k] * arr_2[k, j];
            }
            arrayResult[i, j] = sum;
            sum = 0;
        }
    }
    return arrayResult;
}
*/
int[,] MultiplactionArray(int[,] arr_1, int[,] arr_2)
{
    //Создание результирующего массива и его размера
    int[,] arrayResult = new int[arr_1.GetLength(0), arr_2.GetLength(1)];

    int P = arr_1.GetLength(1);
    int sum = 0;
    int K = arr_2.GetLength(1);

    for (int i = 0; i < K; i++)
    {
        for (int j = 0; j < K; j++)
        {
            for (int k = 0; k < P; k++)
            {
                sum += arr_1[i, k] * arr_2[k, j];
            }
            arrayResult[i, j] = sum;
            sum = 0;
        }
    }
    return arrayResult;
}


int sizeCol = EnterNumber("Сколько строк вы хотите создать в первом массиве ? : ");
int sizeRow = EnterNumber("Сколько столбиков вы хотите создать в первом массиве ? : ");
int[,] array_1 = CreateTwodimensionalArray(sizeCol, sizeRow);
RandomFillArray(array_1);


sizeCol = EnterNumber("Сколько строк вы хотите создать во втором массиве ? : ");
sizeRow = EnterNumber("Сколько столбиков вы хотите создать во втором массиве ? : ");
int[,] array_2 = CreateTwodimensionalArray(sizeCol, sizeRow);
RandomFillArray(array_2);

if (ValidateMatrix(array_1, array_2))
{
    int[,] arrayResult = MultiplactionArray(array_1, array_2);

    PrintArray(array_1);
    Console.WriteLine();

    PrintArray(array_2);
    Console.WriteLine();

    PrintArray(arrayResult);
}
else
{
    Console.WriteLine($"Такие матрицы нельзя перемножить, так как количество столбцов матрицы А не равно количеству строк матрицы В.");
}





