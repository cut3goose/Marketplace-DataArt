using System;
using System.Linq;
using Microsoft.OpenApi.Models;
using OnlineShop.Product.Domain.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OnlineShop.Filters
{
    public class SwaggerFileOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileUploadMime = "multipart/form-data";

            if (operation.RequestBody == null ||
                !operation.RequestBody.Content
                    .Any(x => x.Key.Equals(fileUploadMime, StringComparison.InvariantCultureIgnoreCase)))
            {
                return;
            }

            var fileParams = context.MethodInfo
                .GetParameters()
                .Where(p => p.ParameterType == typeof(PhotoCreateModel));

            var file = fileParams
                .Select(p => p.ParameterType.GetProperty(nameof(PhotoCreateModel.File)));

            operation.RequestBody.Content[fileUploadMime].Schema.Properties = file
                .ToDictionary(k => k.Name, v => new OpenApiSchema()
                {
                    Type = "string",
                    Format = "binary"
                });
        }
    }
}
