using DominoPontaDeQuina.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DominoPontaDeQuina.Migrations;

public class DominoDbContextFactory : IDesignTimeDbContextFactory<DominoDbContext>
{
    public DominoDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DominoDbContext>();
        var connectionString = "Data Source=domino.db";
        optionsBuilder.UseSqlite(connectionString);

        return new DominoDbContext(optionsBuilder.Options);
    }
}