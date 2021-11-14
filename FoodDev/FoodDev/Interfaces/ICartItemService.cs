namespace FoodDev.Services
{
    public interface ICartItemService
    {
        int GetUserCartCount();
        void RemoveItemsFromCart();
    }
}