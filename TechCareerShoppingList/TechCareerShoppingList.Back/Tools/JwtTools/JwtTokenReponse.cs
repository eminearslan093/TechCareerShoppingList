namespace TechCareerShoppingList.Back.Tools.JwtTools
{
    public class JwtTokenReponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpireDate { get; set; }
        public JwtTokenReponse(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }
    }
}
