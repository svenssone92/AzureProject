using Microsoft.EntityFrameworkCore;
using System;
using WebbAPI.Models;

namespace WebbAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<BasicModel> BasicModels { get; set; }
    }
}
