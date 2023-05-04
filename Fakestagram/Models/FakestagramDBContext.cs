using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Fakestagram.Models
{
    public class FakestagramDBContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        // Tables
        public DbSet<Post> Posts { get; set; }

        // Constructor
        public FakestagramDBContext([NotNullAttribute] DbContextOptions options) : base(options) {
            
        }


    }
}
