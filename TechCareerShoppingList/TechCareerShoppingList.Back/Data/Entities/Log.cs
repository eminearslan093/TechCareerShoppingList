using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareerShoppingList.Back.Data.Entities
{
    public class Log
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[Required]
        public DateTime? LogTime { get; set; }

        //[Column(TypeName = "nvarchar(100)")]
        public string? description { get; set; }

        public  User User { get; set; }
        public Log()
        {
            User = new User();
        }
    }
}
