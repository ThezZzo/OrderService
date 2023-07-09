using Domain.Common.DTO;

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

    public void AddCartItem(Product product, Quantity quantity)
    {
        if (CloseCart)
        {
            throw new Exception();
        }
        CartItems.Add(CartItem.Create(product, quantity));
    }

    public IList<CartItem> GetCartItems()
    {
        return CartItems;
    }

    public CartItem GetCartItemWithProduct(List<CartItem> cartItems, Product product)
    {
        var cartItem = cartItems.Find(p => p.Product == product);
        if (cartItem == null)
        {
            throw new Exception();
        }

        return cartItem;
    }

    public void RemoveProductFromCart(int id)
    {
        var product = CartItems.Where(p => p.Product.Id == id).GetEnumerator().Current;
        CartItems.Remove(product);
    }
    
    public CartItem GetCartItem(List<CartItem> cartItems, Product product)
    {
        var cartItem = cartItems.Find(p => p.Product == product);
        if (cartItem == null)
        {
            throw new Exception();
        }

        return cartItem;
    }
    

    
    public bool CartIsClosed()
    {
        return CloseCart;
    } 
    
    
    public static long CalculateFinalPrice(IEnumerable<CartItemDTO> cartItems)
    {
        if (cartItems == null)
        {
            throw new Exception();
        }

        var sum = 0L;
        
        foreach (var item in cartItems)
        {
            sum += item.Product.Price.Value * item.Quantity;
        }
        return sum;
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

    public Guid GetCartId()
    {
        return Id;
    }

}