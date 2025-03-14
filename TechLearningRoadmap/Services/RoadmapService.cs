using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TechLearningRoadmap.Models;


namespace TechLearningRoadmap.Services
{

    // manages roadmaps for  programming languages and levels
 
    public class RoadmapService
    {
        
        /// retrieves  appropriate LanguageLevel subclass based on selected language and level
        public static LanguageLevel GetRoadmap(Language language, Level level)
        {
            if (language == Language.None || level == Level.None)
            {
                Console.WriteLine("Error: You have not selected a learning roadmap. Please choose 'Create My Roadmap' first.");
                return null;
            }

            if (language == Language.CSharp)
            {
                return new CSharpLevel(level);
            }
            else if (language == Language.Java)
            {
                return new JavaLevel(level);
            }
            else if (language == Language.Python)
            {
                return new PythonLevel(level);
            }
            else
            {
                throw new ArgumentException("Invalid language selected.");
            }
        }

    }
}



