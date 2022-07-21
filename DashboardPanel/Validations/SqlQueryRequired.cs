using DashboardPanel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardPanel.Validations
{
    public class SqlQueryRequired : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (Grafik)validationContext.ObjectInstance;
            if(model.WidgetTip==1)
            {
                if(value==null||value.ToString()==string.Empty)
                {
                    return new ValidationResult("sorgu girilmelidir");
                }
                
            }
            return ValidationResult.Success;
        }
       
    }
}
