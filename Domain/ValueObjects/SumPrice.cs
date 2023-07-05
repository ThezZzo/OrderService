namespace Domain.ValueObjects;

public class SumPrice
{
    private long Value { get; init; }

    public static SumPrice Create(long value)
    {
        if (value < 0)
        {
            throw new Exception();
        }
        return new SumPrice { Value = value };
    }
}