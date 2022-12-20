using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TechCareerShoppingList.Back.Convert
{

    //bu sınıfı kullanmama gerk kalmadı
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d))
        { }
    }
}
