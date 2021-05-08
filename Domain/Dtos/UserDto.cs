using System.Text.Json.Serialization;

namespace Domain.Dtos
{
    public class UserDto
    {
        [JsonIgnore] public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
