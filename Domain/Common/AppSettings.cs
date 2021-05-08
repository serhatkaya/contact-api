namespace Contactbook.Domain.Common
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string JwtKey { get; set; }
        public int JwtExpires { get; set; }
    }
}