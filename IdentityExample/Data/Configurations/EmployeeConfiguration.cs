using IdentityExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;

namespace IdentityExample.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasIndex(x => x.Contact)
                .IsUnique();

            builder.HasData(new Employee
            {
                Id = 1,
                FirstName = "Nitesh",
                LastName = "Shrestha",
                Address = "Kathmandu",
                Contact = "9843710782",
                Email = "nitesh.shresthax@gmail.com",
                DateOfBirth = new DateOnly(1996, 11, 25),
                PositionId = 1
            },
            new Employee
            {
                Id = 2,
                FirstName = "Aayush",
                LastName = "Malakar",
                Address = "Kathmandu",
                Contact = "9849019203",
                Email = "aayush.malakar@gmail.com",
                DateOfBirth = new DateOnly(1995, 3, 15),
                PositionId = 1
            });
        }
    }
}
