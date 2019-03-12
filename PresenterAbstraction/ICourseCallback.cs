using PresenterAbstraction.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenterAbstraction
{
    public interface ICourseCallback
    {
        void Notify(CourseResponse response);
    }
}
