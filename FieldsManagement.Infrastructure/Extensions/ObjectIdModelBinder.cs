using FieldsManagement.Core.Exceptions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

public class ObjectIdModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        var valueAsString = valueProviderResult.FirstValue;
        if (string.IsNullOrEmpty(valueAsString))
        {
            return Task.CompletedTask;
        }

        if (!Guid.TryParse(valueAsString, out var guid))
        {
            bindingContext.ModelState.TryAddModelError(
                bindingContext.ModelName, "Invalid ObjectId format.");
            return Task.CompletedTask;
        }

        try
        {
            var objectId = new ObjectId(guid);
            bindingContext.Result = ModelBindingResult.Success(objectId);
        }
        catch (UncorrectGuidException)
        {
            bindingContext.ModelState.TryAddModelError(
                bindingContext.ModelName, "Invalid ObjectId value.");
        }

        return Task.CompletedTask;
    }
}