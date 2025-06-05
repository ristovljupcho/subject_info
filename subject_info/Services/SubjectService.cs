using System;
using System.Collections.Generic;
using System.Linq;
using subject_info.Entities;
using subject_info.Repositories;

namespace subject_info.Services
{
    /// <summary>
    /// Provides operations for retrieving and displaying subject information.
    /// </summary>
    public class SubjectService
    {
        private readonly ISubjectRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubjectService"/> class
        /// and loads subjects from the underlying data source.
        /// </summary>
        /// <param name="repository">The subject repository used for data access.</param>
        public SubjectService(ISubjectRepository repository)
        {
            this.repository = repository;
            repository.LoadSubjects();
        }

        /// <summary>
        /// Retrieves the names of all loaded subjects.
        /// </summary>
        /// <returns>
        /// A list of subject names.
        /// </returns>
        public List<string> GetAllSubjectNames() =>
            repository.GetAllSubjects().Select(s => s.Name).ToList();

        /// <summary>
        /// Prints the details of a subject with the specified name.
        /// </summary>
        /// <param name="name">The name of the subject to display details for.</param>
        /// <remarks>
        /// If the subject is not found, a message is printed to the console.
        /// </remarks>
        public void PrintSubjectDetails(string name)
        {
            var subject = repository.GetSubjectByName(name);
            if (subject == null)
                Console.WriteLine("Subject not found.");
            else
                Console.WriteLine(subject.GetDetails());
        }
    }
}
