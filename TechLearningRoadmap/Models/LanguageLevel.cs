
// Shahad Alamoudi 
// 2309063
// COCS307 - Assignment 1

namespace TechLearningRoadmap.Models
{
    // Abstract class for learning roadmap
    // Assigns programming language-level learning resources
   
    public abstract class LanguageLevel
    {
        protected Dictionary<Level, string> LearningResources; // Learning resources for each level
        public Language LanguageType { get; private set; }
        public Level UserLevel { get; private set; }

        public LanguageLevel(Language language, Level level)
        {
            LanguageType = language;
            UserLevel = level;
            LearningResources = new Dictionary<Level, string>();
            AssignRoadmap();
        }

        // Abstract method to be implemented by subclasses to assign learning resources
        protected abstract void AssignRoadmap();

        // Gets the learning resource based on  user's level 
    
        public string GetLearningResource()
        {
            if (LearningResources.ContainsKey(UserLevel))
            {
                return LearningResources[UserLevel];
            }
            else
            {
                throw new InvalidOperationException("No resources for the selected level.");
            }
        }


        /// Displays the assigned roadmap to the user
        public void DisplayRoadmap()
        {
            try
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Programming Language: {LanguageType}"); 
                Console.WriteLine($"Experience Level: {UserLevel}");
                Console.WriteLine($"Recommended Resource: {GetLearningResource()}");
                Console.WriteLine("--------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
