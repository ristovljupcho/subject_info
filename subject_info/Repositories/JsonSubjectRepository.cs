using subject_info.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace subject_info.Repositories
{
    public class JsonSubjectRepository : ISubjectRepository
    {
        private readonly string path;
        private List<Subject> subjects = new();

        public JsonSubjectRepository(string path) => this.path = path;

        public void LoadSubjects()
        {
            if (!File.Exists(path)) return;

            var json = File.ReadAllText(path);
            var imported = JsonSerializer.Deserialize<List<Subject>>(json);
            subjects = imported ?? new List<Subject>();
        }

        public List<Subject> GetAllSubjects() => subjects;
    }
}
