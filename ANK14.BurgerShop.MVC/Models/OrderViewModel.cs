namespace ANK14.BurgerShop.MVC.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string AppUserId { get; set; }
        public int MenuId { get; set; }
        public int MenuSizeId { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<int> SelectedExtraIds { get; set; }
    }
}
