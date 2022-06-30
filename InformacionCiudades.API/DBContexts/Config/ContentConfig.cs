using Contents.API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contents.API.DBContexts.Config
{
    public class ContentConfig
    {
        public ContentConfig(EntityTypeBuilder<Content> entityBuilder)
        {
            entityBuilder.Property(x => x.Title).IsRequired().HasMaxLength(50);
        }
    }
}
