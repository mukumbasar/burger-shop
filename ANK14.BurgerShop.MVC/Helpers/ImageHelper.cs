namespace ANK14.BurgerShop.MVC.Helpers
{
    public static class ImageHelper
    {
        public static async Task<string> Insert(IFormFile imageFile)
        {
            if (imageFile != null)
            {
                string imageExtension = Path.GetExtension(imageFile.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await imageFile.CopyToAsync(stream);

                return $"/images/{imageName}";
            }

            string defaultPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{"default"}");

            return $"/images/default";
        }
    }
}
