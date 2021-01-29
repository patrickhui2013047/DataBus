using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBus
{
    /// <summary>
    /// A Base class of general result
    /// </summary>
    public class ResultBase : IResult<object>
    {
        public object Result { get; set; }
        public bool IsNull { get; set; }
        public object Message { get; set; }
        public static ResultBase NullResult(object message)
        {
            return new ResultBase
            {
                IsNull = true,
                Result = null,
                Message = message
            };
        }
    }
}
