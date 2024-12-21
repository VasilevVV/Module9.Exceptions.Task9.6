
namespace Module9.Exceptions.Task9.Exercise1;

/// <summary>
/// Собственный тип исключения
/// </summary>
public class MyException : Exception
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public MyException()
    { }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="message">Сообщение об исключении</param>
    public MyException(string message) : base(message)
    { }
}
