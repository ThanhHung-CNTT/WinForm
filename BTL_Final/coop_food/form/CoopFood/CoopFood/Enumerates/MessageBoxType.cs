using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopFood.Enumerates
{
    public enum MessageBoxType
    {
        [Description("Information")] Information,
        [Description("Warning")] Warning,
        [Description("Error")] Error
    }
}
