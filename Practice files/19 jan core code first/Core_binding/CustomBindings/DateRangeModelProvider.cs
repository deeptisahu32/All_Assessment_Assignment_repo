using Microsoft.AspNetCore.Mvc.ModelBinding;
using Core_binding.Models;

namespace Core_binding.CustomBindings
{
    public class DateRangeModelProvider:IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            //based on model type meta data , this method will decide to call either the custom binding or not
            //or not 
            if(context.Metadata.ModelType == typeof(DateRange))
            {
                return new DateRangeModelBinder();
            }
            return null;
        }
    }
}
