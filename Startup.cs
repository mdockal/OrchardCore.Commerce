using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Commerce.Abstractions;
using OrchardCore.Commerce.Drivers;
using OrchardCore.Commerce.Indexes;
using OrchardCore.Commerce.Migrations;
using OrchardCore.Commerce.Models;
using OrchardCore.Commerce.Money;
using OrchardCore.Commerce.Services;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using YesSql.Indexes;

namespace OrchardCore.Commerce
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            // Product
            services.AddSingleton<IIndexProvider, ProductPartIndexProvider>();
            services.AddScoped<IDataMigration, ProductMigrations>();
            services.AddScoped<IContentAliasProvider, ProductPartContentAliasProvider>();
            services.AddScoped<IContentPartDisplayDriver, ProductPartDisplayDriver>();
            services.AddSingleton<ContentPart, ProductPart>();
            // Price
            services.AddScoped<IDataMigration, PriceMigrations>();
            services.AddScoped<IContentPartDisplayDriver, PricePartDisplayDriver>();
            services.AddSingleton<ContentPart, PricePart>();
            services.AddSingleton<IPriceProvider, PriceProvider>();
            // Currency
            services.AddSingleton<ICurrencyProvider, CurrencyProvider>();
            services.AddSingleton<IMoneyService, MoneyService>();
        }
    }
}
