using shop.Models;

namespace shop.Services
{
    public interface IOrderDetailServices
    {
        public List<Order> GetOrderItems();
        public void Add(Order item);      
       
    }
}
