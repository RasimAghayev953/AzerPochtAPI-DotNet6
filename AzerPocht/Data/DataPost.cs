using Microsoft.EntityFrameworkCore;

namespace AzerPocht.Data
{
    public class DataPost:DbContext
    {
        public DataPost(DbContextOptions<DataPost> options) : base(options) { }
        public DbSet<AzerPochtModel> AzerPochtModels {  get; set; }

    }
}
