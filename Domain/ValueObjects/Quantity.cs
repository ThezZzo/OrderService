namespace Domain.ValueObjects;

public class Quantity 
{
    public long Value { get; set; }

    public static Quantity Create(long value)
    {
        if (value < 0)
        {
            throw new Exception();
        }

        return new Quantity { Value = value };
    }
}