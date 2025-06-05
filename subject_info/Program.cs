using System;
using subject_info.Repositories;
using subject_info.Services;

namespace subject_info
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            string jsonPath = Path.Combine(AppContext.BaseDirectory, "subjects.json");

            while (!exit)
            {
                Console.WriteLine("\nChoose data source:");
                Console.WriteLine("1. Predefined Subjects");
                Console.WriteLine("2. Subjects from JSON");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                string input = Console.ReadLine();

                ISubjectRepository repository = null;

                switch (input)
                {
                    case "1":
                        repository = new PredefinedSubjectRepository();
                        break;
                    case "2":
                        repository = new JsonSubjectRepository(jsonPath);
                        break;
                    case "3":
                        exit = true;
                        Console.WriteLine("Goodbye!");
                        continue;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        continue;
                }

                var subjectService = new SubjectService(repository);
                ShowSubjects(subjectService);
            }
        }

        /// <summary>
        /// Helper method that displays a menu of subjects and allows the user to view details for a selected subject.
        /// </summary>
        /// <param name="subjectService">The <see cref="SubjectService"/> used to retrieve and display subject data.</param>
        /// <remarks>
        /// The method repeatedly displays a numbered list of all subject names retrieved from the service.  
        /// Users can select a subject by entering its corresponding number to view its details,  
        /// or choose the "Back" option to return to the previous menu or exit the loop.  
        /// If an invalid option is selected, an error message is shown and the menu is displayed again.
        /// </remarks>
        static void ShowSubjects(SubjectService subjectService)
        {
            var subjectNames = subjectService.GetAllSubjectNames();
            bool back = false;

            while (!back)
            {
                for (int i = 0; i < subjectNames.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {subjectNames[i]}");
                }
                Console.WriteLine($"{subjectNames.Count + 1}. Back");

                Console.Write("Select a subject: ");
                string choice = Console.ReadLine();

                if (int.TryParse(choice, out int index) &&
                    index >= 1 && index <= subjectNames.Count)
                {
                    string selectedName = subjectNames[index - 1];
                    Console.WriteLine(new string('-', 70));
                    subjectService.PrintSubjectDetails(selectedName);
                    Console.WriteLine(new string('-', 70));
                }
                else if (index == subjectNames.Count + 1)
                {
                    back = true;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Try again.");
                }
            }
        }
    }
}
