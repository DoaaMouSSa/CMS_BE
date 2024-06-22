namespace cms_be.Models
{
    public class AuthModel
    {
        public bool IsAuthenticated { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        /// <summary>
        /// public string Token { get; set; }
        /// </summary>
        //public DateTime ExpirationDate { get; set; }
    }
}
