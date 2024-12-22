namespace Module9.Exceptions.Task9.Exercise2.ConsolePresenter;

/// <summary>
/// Чтение числа 1 или 2 из консоли для сортировки списка фамилий
/// </summary>
public class NumberReaderForSortSernames
{
    /// <summary>
    /// Делегат для обработки события
    /// </summary>
    /// <param name="number">Введеное число либо 1, либо 2</param>
    /// <param name="surnames">Список фамилий</param>
    public delegate void NumberEnteredDelegate(int number, string[] surnames);

    /// <summary>
    /// Событие
    /// </summary>
    public event NumberEnteredDelegate NumberEnteredEvent; // 1.Определение события

    /// <summary>
    /// Метод чтения числа
    /// </summary>
    /// <param name="surnames">Список фамилий</param>
    /// <exception cref="FormatExceptionOneOrTwo">Исключение, если в консоли ни 1, ни 2</exception>
    public void Read(string[] surnames)
    {
        Console.WriteLine();
        Console.WriteLine("Необходимо ввести значение: либо 1, либо 2.");

        int number = Convert.ToInt32(Console.ReadLine());

        if (number != 1 && number != 2) throw new FormatExceptionOneOrTwo("Введено некоректное значение");

        NumberEntered(number, surnames); // 2.Вызов события
    }

    /// <summary>
    /// Вызов события 
    /// </summary>
    /// <param name="number">Введеное число либо 1, либо 2</param>
    /// <param name="surnames">Список фамилий</param>
    protected virtual void NumberEntered(int number, string[] surnames)
    {
        NumberEnteredEvent?.Invoke(number, surnames);
    }
}
