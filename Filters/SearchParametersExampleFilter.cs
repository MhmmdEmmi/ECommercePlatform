using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace ECommercePlatform.Filters
{
    public class SearchParametersExampleFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.DeclaringType?.Name == "ProductsController" &&
                context.MethodInfo.Name == "GetProducts")
            {
                // استفاده از حلقه foreach به جای ForEach
                if (operation.Parameters != null)
                {
                    foreach (var p in operation.Parameters)
                    {
                        if (p.Name == "search")
                            p.Example = new OpenApiString("laptop");
                        else if (p.Name == "minPrice")
                            p.Example = new OpenApiString("100");
                        else if (p.Name == "maxPrice")
                            p.Example = new OpenApiString("1000");
                    }
                }
            }
        }
    }
}