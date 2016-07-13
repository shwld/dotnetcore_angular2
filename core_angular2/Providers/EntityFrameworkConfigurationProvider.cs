using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using core_angular2.Models;

namespace core_angular2.Providers
{
    public class EntityFrameworkConfigurationProvider : ConfigurationProvider
    {
        public EntityFrameworkConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        Action<DbContextOptionsBuilder> OptionsAction { get; }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<DefaultContext>();
            OptionsAction(builder);

            using (var dbContext = new DefaultContext(builder.Options))
            {
                // dbContext.Database.EnsureCreated();
            }
        }
    }
}