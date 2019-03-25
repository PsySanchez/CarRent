using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRent
{
  public class ErrorModel
  {
    public List<string> errors { get; set; } = new List<string>();

    public void AddError(string error)
    {
      errors.Add(error);
    }
  }
}
