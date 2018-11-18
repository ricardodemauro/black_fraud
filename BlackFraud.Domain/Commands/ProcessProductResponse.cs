using BlackFraud.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.Domain.Commands
{
    public class ProcessProductResponse : IHandler<ProcessProductRequest, ProcessProductResponse>
    {
        public ProcessProductResponse Handle(ProcessProductRequest rq)
        {
            throw new NotImplementedException();
        }
    }
}
