using Contents.API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contents.API.DBContexts.Config
{
    public class UserConfig
    {
        public UserConfig(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.Property(x => x.Username).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Password).IsRequired().HasMaxLength(50);
        }
    }
}
