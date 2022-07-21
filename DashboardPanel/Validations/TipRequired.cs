using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardPanel.Validations
{
    public class TipRequired:RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (Convert.ToInt32(value) == -1)
            {
                ErrorMessage = "Tip Seçilmelidir.";
                return false;
            }

            return true;
        }
    }
}
