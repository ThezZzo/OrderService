namespace Application.Exceptions;

public class ArgumentException : Exception
{
    public ArgumentException(string name) : base($"Введено неверное значение {name} ")
    {
        
    }
}