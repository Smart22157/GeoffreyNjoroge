// Models/AssignmentDbContext.cs
// Models/AssignmentDbContext.cs
using Geoffrey_Muchangi.Models;
using System.Data.Entity;

public class AssignmentDbContext : DbContext
{
    public AssignmentDbContext() : base("name=AccessDbConnection")
    {
    }

    public DbSet<Table1> Table1 { get; set; }
    public DbSet<Table2> Table2 { get; set; }
    public DbSet<Table3> Table3 { get; set; }
}

