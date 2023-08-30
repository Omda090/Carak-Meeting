using Carak_Meeting.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Carak_Meeting.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }


        public DbSet<UserCarak> userCaraks { get; set; }
        public DbSet<Product> products { get; set; }

    }
}
