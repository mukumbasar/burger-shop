namespace ANK14.BurgerShop.MVC.Models
{
    public class UpdateOrderViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public string AppUserId { get; set; }
        public int MenuId { get; set; }
        public int MenuSizeId { get; set; }
    }
}
