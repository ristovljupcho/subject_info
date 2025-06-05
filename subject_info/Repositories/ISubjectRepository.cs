using subject_info.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subject_info.Repositories
{
    public interface ISubjectRepository
    {
        void LoadSubjects();
        List<Subject> GetAllSubjects();
    }
}
