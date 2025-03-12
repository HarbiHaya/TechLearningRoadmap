using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using TechLearningRoadmap.Models;

using System;
using TechLearningRoadmap.Models;

namespace TechLearningRoadmap.Services
{
    /// <summary>
    /// Manages learning roadmaps for different programming languages and levels.
    /// </summary>
    public class RoadmapService
    {
        /// <summary>
        /// Retrieves the appropriate LanguageLevel subclass based on user-selected language and level.
        /// </summary>
        public static LanguageLevel GetRoadmap(Language language, Level level)
        {
            if (language == Language.None || level == Level.None)
            {
                Console.WriteLine("❌ Error: You have not selected a learning roadmap. Please choose 'Create My Roadmap' first.");
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



