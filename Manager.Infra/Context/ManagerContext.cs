using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Context;

public class ManagerContext : DbContext
{
    public ManagerContext()
    {}
    public ManagerContext(DbContextOptions<ManagerContext> options) : base(options){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
    {
       
        optionsbuilder.UseSqlServer(
            @"Server=DESKTOP-J8H7BF3\SQLEXPRESS;Initial Catalog=USERMANAGERAPI;Integrated Security=True");
    }
    
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserMap());
    }

}