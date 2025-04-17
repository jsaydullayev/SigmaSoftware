using Microsoft.AspNetCore.Mvc.ModelBinding;
using StatusGeneric;

namespace SigmaSoftware.Service.Extensions;
public static class ErrorExtencions
{
    public static void CopyToModel(this IStatusGeneric status, ModelStateDictionary model)
    {
        if (!status.HasErrors)
            return;

        foreach(ErrorGeneric error in status.Errors)
        {
            var ll = error.ErrorResult.MemberNames.FirstOrDefault();
            model.AddModelError(key: error.ErrorResult.MemberNames.Count() == 1 ? error.ErrorResult.MemberNames.First() : "", error.ToString());
        }
    }
}
