using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Blog.Api
{
    public class SwaggerNullableParameterFilter : IParameterFilter
    {
        public void Apply(IOpenApiParameter parameter, ParameterFilterContext context)
        {
            if (context.ParameterInfo != null
                && context.ParameterInfo.ParameterType.IsGenericType
                && context.ParameterInfo.ParameterType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (parameter is OpenApiParameter openApiParameter)
                {
                    openApiParameter.Required = false;
                }
            }
        }
    }
}
