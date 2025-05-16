using IdeaManager.Data.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaManager.Data
{
    public class IdeaDbContextFactory : IDesignTimeDbContextFactory<IdeaDbContext>
    {
        public IdeaDbContext CreateDbContext(string[] args) {
            var optionBuilder = new DbContextOptionsBuilder<IdeaDbContext>();
            optionBuilder.UseSqlite("Data Source=ideas.db");

            return new IdeaDbContext(optionBuilder.Options);
        
        }

    }
}
