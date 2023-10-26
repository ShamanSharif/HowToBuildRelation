using Microsoft.EntityFrameworkCore;

namespace HowToBuildRelation.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) 
    { }
}