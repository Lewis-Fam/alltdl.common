using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alltdl.Operations
{
    public class Operation<TRequest, TResult>
    {
        public Operation()
        {
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Message { get; set; }

        public TRequest Request { get; set; }

        public TResult Result { get; set; }

        public void Process(TRequest request)
        {
        }
    }
}