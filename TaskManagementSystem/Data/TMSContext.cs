using System;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data.DTOs;
using Task = TaskManagementSystem.Data.DTOs.Task;

namespace TaskManagementSystem.Data
{
    public class TMSContext : DbContext
    {
        public TMSContext(DbContextOptions<TMSContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
