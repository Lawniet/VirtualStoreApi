using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public interface IApplicationResponse
    {
        public object Result { get; set; }
        bool IsValid { get; set; }
        List<string> Messages { get; set; }
    }
}
