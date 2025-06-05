using subject_info.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subject_info.Repositories
{
    /// <summary>
    /// Interface that defines methods for managing <see cref="Subject"/> data.
    /// </summary>
    public interface ISubjectRepository
    {
        /// <summary>
        /// Loads subject data from the underlying data source.
        /// </summary>
        void LoadSubjects();

        /// <summary>
        /// Retrieves all loaded subjects.
        /// </summary>
        /// <returns>
        /// A list of all available <see cref="Subject"/> objects.
        /// </returns>
        List<Subject> GetAllSubjects();

        /// <summary>
        /// Retrieves a subject by its name.
        /// </summary>
        /// <param name="name">The name of the subject to search for.</param>
        /// <returns>
        /// The matching <see cref="Subject"/> object.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the input name is null or whitespace.
        /// </exception>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">
        /// Thrown when no subject is found with the given name.
        /// </exception>
        Subject GetSubjectByName(string name);
    }
}
