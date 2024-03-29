﻿namespace Contents.API.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public ICollection<ContentDto> Contents { get; set; } = new List<ContentDto>();
    }
}
