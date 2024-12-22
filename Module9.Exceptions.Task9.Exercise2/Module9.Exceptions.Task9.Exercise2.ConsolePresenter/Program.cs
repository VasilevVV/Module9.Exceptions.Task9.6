namespace Module9.Exceptions.Task9.Exercise2.ConsolePresenter;

public class Program
{
    public static void Main(string[] args)
    {
        string[] surnames = { "Иванов", "Петров", "Сидоров", "Дороздов", "Картошкин" };
        Console.WriteLine("Исходный список фамилий:");
        foreach (string s in surnames) { Console.WriteLine(s); }

        NumberReaderForSortSernames numberReader = new NumberReaderForSortSernames();
        numberReader.NumberEnteredEvent += ShowNumber;

        while (true) 
        {
            try
            {
                numberReader.Read(surnames);
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
    /// <param name="surnames"></param>
    static void ShowNumber(int number, string[] surnames)
    {
        switch (number)
        { 
            case 1: //сортировка А-Я
                {
                    Console.WriteLine("Введено значение: 1");
                    Array.Sort<string>(surnames);
                    foreach (string s in surnames) { Console.WriteLine(s); }
                    break;
                }                
            case 2: //сортировка Я-А
                {
                    Console.WriteLine("Введено значение: 2");
                    Array.Sort<string>(surnames);
                    Array.Reverse<string>(surnames);
                    foreach (string s in surnames) { Console.WriteLine(s); }
                    break;
                }
        }
    }
}

