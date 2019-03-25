using System;
using System.Web.Http.ModelBinding;

namespace CarRent
{
  public class ErrorsHelper
  {
    // ms contains only the model properties with some validation error in them.
    public static ErrorModel GetErrorModel(ModelStateDictionary ms)
    {
      ErrorModel err = new ErrorModel();
      foreach (var v in ms.Values) // v = Property
        foreach (var e in v.Errors) // e = one error in that property.
          err.AddError(e.ErrorMessage);
      return err;
    }

    public static ErrorModel GetErrorModel(Exception ex)
    {
#if DEBUG
      ErrorModel err = new ErrorModel();
      err.AddError(GetMessage(ex));
      return err;
#else
            ErrorModel err = new ErrorModel();
            err.AddError("Some error occur, please try again.");
            return err;
#endif
    }

    private static string GetMessage(Exception ex) // Recursion
    {
      if (ex.InnerException == null)
        return ex.Message;
      return GetMessage(ex.InnerException);
    }
  }
}
