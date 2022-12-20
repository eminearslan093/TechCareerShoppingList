namespace TechCareerShoppingList.Back.Application.Dto
{
    public class ShoppingListDto
    {
        public string? ListName { get; set; }
        public bool State { get; set; }//alışverişe çıkıyorum seçeneği için
        public bool Active { get; set; }// kullanıcı girişini kontrol için, aktif mi değilmi 
        public bool ShoppingOk { get; set; }//alış veriş tamamlandı
        public int UserId { get; set; }
    }
}
