namespace Domain.Exceptions;

public class NotFoundListException : Exception
{
    public NotFoundListException(string name) : base($"Список {name} - пуст")
    {
        
    }
}