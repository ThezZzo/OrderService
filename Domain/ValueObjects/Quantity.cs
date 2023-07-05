namespace Domain.ValueObjects;

public class Quantity 
{
    public long Value { get; init; }

    public static Quantity Create(long value)
    {
        if (value < 0)
        {
            throw new Exception();
        }

        return new Quantity { Value = value };
    }
}