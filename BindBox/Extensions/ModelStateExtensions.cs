using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace BindBox.Extensions
{
    public static class ModelStateExtensions
    {
        public static void RemoveAll(this ModelStateDictionary modelState,params string[] names)
        {
            foreach (var item in names)
            {
                modelState.Remove(item);
            }
        }
    }
}
