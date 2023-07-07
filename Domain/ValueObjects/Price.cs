namespace Domain.ValueObjects;

public class Price
{
    public long Value { get; init; }

    public static Price Create(long value)
    {
        if (value < 0)
        {
            throw new Exception("Must be more 0");
        }

        return new Price { Value = value};
    }
}