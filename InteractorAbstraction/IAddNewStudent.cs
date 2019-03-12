using InteractorAbstraction.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractorAbstraction
{
    public interface IAddNewStudent
    {
        void Execute(StudentRequest student);
    }
}
