using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TicketSystem.DAL;

namespace TicketSystem.DAL.Models;

public class TicketContext : DbContext
{
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Developer> Developers => Set<Developer>();

    public TicketContext(DbContextOptions<TicketContext> options): base(options)
    {


    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        base.OnModelCreating(modelBuilder);
        var _departments = JsonSerializer.Deserialize<List<Department>>("""[{"Id":1,"Name":"Automotive \u0026 Baby"},{"Id":2,"Name":"Lolo \u0026 Baby"},{"Id":3,"Name":"Baby \u0026 Baby"}]""") ?? new();
        var _developers = JsonSerializer.Deserialize<List<Developer>>("""[{"Id":1,"Name":"Freddie"},{"Id":2,"Name":"Jamie"},{"Id":3,"Name":"Geoffrey"}]""") ?? new();
        var _tickets = JsonSerializer.Deserialize<List<Ticket>>("""[{"Id":1,"Description":"Cumque unde dolores placeat reprehenderit et porro minima sit.","Severity":0, "DepartmentId":1 },{"Id":2,"Description":"Cumque unde dolores.","Severity":1, "DepartmentId":2 },{"Id":3,"Description":"Cumque unde dolores placeat reprehenderit et porro minima sit.","Severity":2, "DepartmentId":3 }]""") ?? new();
        modelBuilder.Entity<Ticket>().HasData(_tickets);
        modelBuilder.Entity<Developer>().HasData(_developers);
        modelBuilder.Entity<Department>().HasData(_departments);
    }
}





