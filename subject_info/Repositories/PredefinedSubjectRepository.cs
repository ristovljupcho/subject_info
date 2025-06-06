﻿using subject_info.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subject_info.Repositories
{
    /// <summary>
    /// A repository that manages subject that are hardcoded in the class.
    /// </summary>
    /// <remarks>
    /// This class implements the <see cref="ISubjectRepository"/> interface 
    /// that provides crucial methods for retriving and managing subjects.
    /// </remarks>
    public class PredefinedSubjectRepository : ISubjectRepository
    {
        private List<Subject> subjects = new();

        /// <summary>
        /// Load subjects by generating new subject instances with additional coresponding literature.
        /// </summary>
        public void LoadSubjects()
        {
            subjects.Clear();

            subjects.Add(new Subject(1, "Physics", "Study of matter and energy", 4, "Core subject")
            {
                Literature = new List<Literature>
                {
                    new Literature(1L, "Fundamentals of Physics", 2020, 1, new List<string> { "Robert Wilson" }),
                    new Literature(2L, "Quantum Mechanics Intro", 2019, 1, new List<string> { "Emily Davis" }),
                    new Literature(3L, "Classical Mechanics", 2017, 1, new List<string> { "Michael Chen" })
                }
            });

            subjects.Add(new Subject(2, "History", "Exploration of past events", 3, "Social studies core")
            {
                Literature = new List<Literature>
                {
                    new Literature(4L, "World History Overview", 2018, 2, new List<string> { "Sarah Thompson" }),
                    new Literature(5L, "Ancient Civilizations", 2021, 2, new List<string> { "David Lee" }),
                    new Literature(6L, "Modern History", 2015, 2, new List<string> { "Laura Martinez" })
                }
            });

            subjects.Add(new Subject(3, "Computer Science", "Study of computation and programming", 3, "Elective")
            {
                Literature = new List<Literature>
                {
                    new Literature(7L, "Programming Fundamentals", 2022, 3, new List<string> { "James Kim" }),
                    new Literature(8L, "Data Structures", 2020, 3, new List<string> { "Anna Patel" }),
                    new Literature(9L, "Algorithms Unlocked", 2019, 3, new List<string> { "Thomas Nguyen" })
                }
            });
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