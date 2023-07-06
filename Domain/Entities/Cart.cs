namespace Domain.Entities;

public class Cart
{
    public int Id { get; set; }
    
    private IList<CartItem> CartItems { get; init; }
    
    private DateTime DateCreated { get; init; }
    
    private DateTime? DateClose { get; set; }

    private bool CloseCart { get; set; }

    public Cart()
    {
        CloseCart = false;
    }

    public Cart Create(IList<CartItem> cartItems, DateTime dateTime)
    {
        return new Cart { CartItems = cartItems, DateCreated = dateTime };
    }

    public void AddCartItem(CartItem cartItem)
    {
        if (!CloseCart)
        {
            throw new Exception();
        }
        CartItems.Add(cartItem);
    }
    
    
    public void CloseCartForCheckoutOrder()
    {
        CloseCart = true;
        DateClose = DateTime.UtcNow;
    }
}