namespace Module9.Exceptions.Task9.Exercise2.ConsolePresenter;

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
