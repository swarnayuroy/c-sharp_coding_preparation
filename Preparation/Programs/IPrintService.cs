using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programs
{
    public interface IPrintService
    {
        Task PrintResult(object data, string message);
    }
}
