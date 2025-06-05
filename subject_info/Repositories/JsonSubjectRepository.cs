using subject_info.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace subject_info.Repositories
{
    /// <summary>
    /// A repository that manages subject data stored in a JSON file.
    /// </summary>
    /// <remarks>
    /// This class implements the <see cref="ISubjectRepository"/> interface 
    /// that provides crucial methods for retriving and managing <see cref="Subject"/> objects.
    /// </remarks>
    public class JsonSubjectRepository : ISubjectRepository
    {
        private readonly string path;
        private List<Subject> subjects = new();

        public JsonSubjectRepository(string path) => this.path = path;

        /// <summary>
        /// Loads subject data from JSON file at the specified path.
        /// </summary>
        public void LoadSubjects()
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"The subject data file was not found at path: {path}");

            var json = File.ReadAllText(path);
            var imported = JsonSerializer.Deserialize<List<Subject>>(json);
            subjects = imported ?? new List<Subject>();
        }

        public List<Subject> GetAllSubjects() => subjects;

        public Subject GetSubjectByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Subject name must be provided.", nameof(name));

            var subject = subjects.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (subject == null)
                throw new KeyNotFoundException($"No subject found with the name '{name}'.");

            return subject;
        }
    }
}
