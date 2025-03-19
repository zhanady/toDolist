// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TodoListApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}