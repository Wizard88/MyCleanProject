using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractorAbstraction
{
    public interface IGetCourseByID
    {
        void Execute(Guid id);
    }
}
