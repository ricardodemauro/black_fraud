using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.DI
{
    public interface IHandler<TRq, TRs>
        where TRq : class
        where TRs : class
    {
        TRs Handle(TRq rq);
    }
}
