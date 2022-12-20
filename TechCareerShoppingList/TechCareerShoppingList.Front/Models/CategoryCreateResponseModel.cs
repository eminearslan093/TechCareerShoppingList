using System.ComponentModel.DataAnnotations;


namespace TechCareerShoppingList.Front.Models
{
    public class CategoryCreateResponseModel
    {
        [Required(ErrorMessage = "Kategory adı boş olamaz.")]
        public string? Definition { get; set; }
    }
}
