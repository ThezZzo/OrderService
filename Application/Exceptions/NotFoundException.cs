namespace Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key) : base($"Сущность {name} с ключом {key} не найдена")
    {
        
    }
}