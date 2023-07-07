namespace Domain.Entities;

public class Cart
{
    public Guid Id { get; set; }
    
    public List<CartItem> CartItems { get; set; }
    
    private DateTime DateCreated { get; init; }
    
    private DateTime? DateClose { get; set; }

    public bool CloseCart { get; set; } = false;

    private Cart()
    {
        Id = Guid.NewGuid();
        CloseCart = false;
    }

    public static Cart Create(List<CartItem> cartItems, DateTime dateTime)
    {
        return new Cart { Id = Guid.NewGuid(),CartItems = cartItems, DateCreated = dateTime };
    }

    public void AddCartItem(CartItem cartItem)
    {
        if (!CloseCart)
        {
            throw new Exception();
        }
        CartItems.Add(cartItem);
    }

    public IList<CartItem> GetCartItems(Cart cart)
    {
        return CartItems;
    }
    public bool CartIsClosed()
    {
        return CloseCart;
    } 
    public static long CalculateFinalPrice(IList<CartItem> cartItems)
    {
        if (!cartItems.Any())
        {
            throw new Exception();
        }
        return cartItems.Sum(item => item.Quantity.Value * item.Product.Price.Value);
    }
    
    public void CloseCartForCheckoutOrder()
    {
        CloseCart = true;
        DateClose = DateTime.UtcNow;
    }

    public void RemoveCartItem(CartItem cartItem)
    {
        CartItems.Remove(cartItem);
    }
}