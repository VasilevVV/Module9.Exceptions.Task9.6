namespace Module9.Exceptions.Task9.Exercise1;


public class Program
{
    public static void Main(string[] args)
    {
        Exception[] ArrExceptions = { new MyException("Возникло собственное исключение."), 
                                    new DivideByZeroException(), 
                                    new IndexOutOfRangeException(), 
                                    new DirectoryNotFoundException(), 
                                    new FileNotFoundException() };

        for (int i = 0; i < ArrExceptions.Length; i++) 
        {
            try
            {
                throw ArrExceptions[i];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение {i + 1}: {ex.Message}");
            }
        }

        Console.ReadKey();
    }
}