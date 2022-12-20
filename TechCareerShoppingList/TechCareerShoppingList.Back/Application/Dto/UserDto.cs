namespace TechCareerShoppingList.Back.Application.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        //public string? Name { get; set; }
        //public string? SurName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        //public int RoleId { get; set; }
        public string Role { get; set; } = string.Empty;
        public bool IsExist { get; set; }
    }
}
