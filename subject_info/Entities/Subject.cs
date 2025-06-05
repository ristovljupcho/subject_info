using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subject_info.Entities
{
    public class Subject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WeeklyClasses { get; set; }
        public string AdditionalInfo { get; set; } 
        public List<Literature> Literature { get; set; }

        public Subject(long id, string name, string description, int weeklyClasses, string additionalInfo)
        {
            Id = id;
            Name = name;
            Description = description ?? "";
            WeeklyClasses = weeklyClasses;
            AdditionalInfo = additionalInfo ?? "";
            Literature = new List<Literature>();
        }

        private string GetLiteratureDetails()
        {
            return Literature.Count > 0 ? string.Join("\n", Literature.Select(l => l.GetDetails())) : "No literature available";
        }

        public virtual string GetDetails()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Subject: {Name}");
            stringBuilder.AppendLine($"Description: {Description}");
            stringBuilder.AppendLine($"Weekly Classes: {WeeklyClasses}");
            stringBuilder.AppendLine($"Additional Information: {AdditionalInfo} \n");
            stringBuilder.AppendLine("Literature:");

            var literatureDetails = GetLiteratureDetails();
            stringBuilder.AppendLine(literatureDetails);

            return stringBuilder.ToString();
        }
    }
}
