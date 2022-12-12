using IdentityExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityExample.Data.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasData(new Position
            {
                Id = 1,
                Name = "Software Engineer I",
            },
            new Position
            {
                Id = 2,
                Name = "Software Engineer II",
            },
            new Position
            {
                Id = 3,
                Name = "Senior Software Engineer",
            },
            new Position
            {
                Id = 4,
                Name = "Principal Software Engineer",
            },
            new Position
            {
                Id = 5,
                Name = "Senior Principal Software Engineer",
            });
        }
    }
}
