using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subject_info.Entities
{
    public class Literature
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int YearPublished { get; set; }
        public long SubjectId { get; set; }
        public List<string> Authors { get; set; }

        public Literature(long id, string title, int yearPublished, long subjectId, List<string> authors)
        {
            Id = id;
            Title = title;
            YearPublished = yearPublished;
            SubjectId = subjectId;
            Authors = authors ?? new List<string>();
        }

        public string GetDetails()
        {
            var authorNames = Authors.Count > 0
                ? string.Join(", ", Authors)
                : "Unknown";
            return $"{Title} by {authorNames} ({YearPublished})";
        }
    }
}
