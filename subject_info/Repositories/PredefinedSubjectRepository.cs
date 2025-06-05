using subject_info.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subject_info.Repositories
{
    public class PredefinedSubjectRepository : ISubjectRepository
    {
        private List<Subject> subjects = new();

        public void LoadSubjects()
        {
            subjects.Clear();

            subjects.Add(new Subject(1, "Math", "Mathematics subject", 4, "Core subject")
            {
                Literature = new List<Literature>
                {
                    new Literature(1L, "Algebra Essentials", 2015, 1, new List<string> { "John Doe" }),
                    new Literature(2L, "Geometry Basics", 2018, 1, new List<string> { "Jane Smith" })
                }
            });

            subjects.Add(new Subject(2, "English", "English language studies", 3, "Language core")
            {
                Literature = new List<Literature>
                {
                    new Literature(3L, "English Grammar", 2016, 2, new List<string> { "Mary Johnson" })
                }
            });

            subjects.Add(new Subject(3, "Art", "Creative visual expression", 2, "Elective")
            {
                Literature = new List<Literature>
                {
                    new Literature(4L, "Color Theory", 2012, 3, new List<string> { "Alex Brown" })
                }
            });
        }

        public List<Subject> GetAllSubjects() => subjects;
    }
}
