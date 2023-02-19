using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TechStorageAPI.ApiKey
{
    public class AuthHeader : IOperationFilter
    {
        public void Apply(
        OpenApiOperation operation,
        OperationFilterContext context)
        {
            if (operation.Parameters is null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "ApiKey",
                In = ParameterLocation.Header,
                Description = "Enter Api Key",
                Required = false,
            });
        }
    }
}
