using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using TechLearningRoadmap.Models;

namespace TechLearningRoadmap.Services
{
    /// <summary>
    /// Service to fetch the correct roadmap based on user selection.
    /// </summary>
    public class RoadmapService
    {
        /// <summary>
        /// Retrieves the appropriate roadmap based on language and level.
        /// </summary>
        public static LanguageLevel GetRoadmap(Language language, Level level)
        {
            return language switch
            {
                Language.CSharp => new CSharpLevel(level),
                Language.Java => new JavaLevel(level),
                Language.Python => new PythonLevel(level),
                _ => throw new ArgumentException("Invalid Language Selection.")
            };
        }
    }
}

