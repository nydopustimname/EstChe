using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class OperationInfo
    {
       public OperationInfo(bool isSuccess, string message, string property)
        {
            IsSuccess = isSuccess;
            Message = message;
            Property = property;
        }

        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }
    }

}
