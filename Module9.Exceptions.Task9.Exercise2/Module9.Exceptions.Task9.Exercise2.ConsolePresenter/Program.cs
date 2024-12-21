namespace Module9.Exceptions.Task9.Exercise2.ConsolePresenter;

/*
Создайте консольное приложение, в котором будет происходить сортировка списка фамилий из пяти человек. 
Сортировка должна происходить при помощи события. Сортировка происходит при введении пользователем либо числа 1 (сортировка А-Я), 
либо числа 2 (сортировка Я-А).

Дополнительно реализуйте проверку введённых данных от пользователя через конструкцию TryCatchFinally с использованием собственного типа исключения. 
*/

public class Program
{
    public static void Main(string[] args)
    {
        string[] surnames = { "Иванов", "Петров", "Сидоров", "Дороздов", "Картошкин" };

        NumberReader numberReader = new NumberReader();
        numberReader.NumberEnteredEvent += ShowNumber;

        while (true) 
        {
            try
            {
                numberReader.Read();
            }
            catch (FormatException e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }

    /// <summary>
    /// Обработчик события ввода 1 или 2 пользователем
    /// </summary>
    /// <param name="number">Введенное значение 1 или 2</param>
    static void ShowNumber(int number)
    {
        switch (number)
        { 
            case 1: //сортировка А-Я
                {
                    Console.WriteLine("Введено значение: 1"); 
                    break;
                }                
            case 2: //сортировка Я-А
                {
                    Console.WriteLine("Введено значение: 2"); 
                    break;
                }
        }
    }
}

/// <summary>
/// Чтение числа 1 или 2 из консоли
/// </summary>
public class NumberReader
{
    /// <summary>
    /// Делегат для обработки события
    /// </summary>
    /// <param name="number"></param>
    public delegate void NumberEnteredDelegate(int number);

    /// <summary>
    /// Событие
    /// </summary>
    public event NumberEnteredDelegate NumberEnteredEvent; // 1.Определение события

    /// <summary>
    /// Метод чтения числа
    /// </summary>
    /// <exception cref="FormatExceptionOneOrTwo">Исключение, если в консоли ни 1, ни 2</exception>
    public void Read()
    {
        Console.WriteLine();
        Console.WriteLine("Необходимо ввести значение: либо 1, либо 2.");

        int number = Convert.ToInt32(Console.ReadLine());

        if (number != 1 && number != 2) throw new FormatExceptionOneOrTwo("Введено некоректное значение");

        NumberEntered(number); // 2.Вызов события
    }

    /// <summary>
    /// Вызов события 
    /// </summary>
    /// <param name="number">Введеное число либо 1, либо 2</param>
    protected virtual void NumberEntered(int number)
    {
        NumberEnteredEvent?.Invoke(number);
    }
}

/// <summary>
/// Исключение, если в консоли ни 1, ни 2
/// </summary>
public class FormatExceptionOneOrTwo : FormatException
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="_exceptionMessage">Сообщение об ошибке</param>
    public FormatExceptionOneOrTwo(string _exceptionMessage) : base(_exceptionMessage) { }
}
