namespace ANK14.BurgerShop.MVC.Models
{
    public class MenuSizeViewModel
    {
        public int Id { get; set; }
        public string? SId { get; set; }
        public string Name { get; set; }
        public string NameAndPrice { get; set; }
        public int AdditionalPrice { get; set; }

        public MenuSizeViewModel()
        {
            NameAndPrice = Name + " " + AdditionalPrice+ " ₺";
            SId = Id.ToString();
        }
    }
}
