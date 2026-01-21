using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Core_binding.CustomBindings
{
    public class CommaSeparatedProvider:IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if(context.Metadata.ModelType == typeof(List<int>))
            {
                return new CommonSeparatedModel();
            }
            return null;
        }          
    }
}
