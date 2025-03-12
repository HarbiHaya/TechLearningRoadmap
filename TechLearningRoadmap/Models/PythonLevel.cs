using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLearningRoadmap.Models
{
    /// <summary>
    /// Represents the Python learning roadmap.
    /// </summary>
    public class PythonLevel : LanguageLevel
    {
        public PythonLevel(Level level) : base(Language.Python, level) { }

        /// <summary>
        /// Assigns learning resources specific to Python.
        /// </summary>
        protected override void AssignRoadmap()
        {
            LearningResources[Level.Beginner] = "Python Basics: https://www.python.org/about/gettingstarted/";
            LearningResources[Level.Intermediate] = "Python Intermediate Guide: https://realpython.com/";
            LearningResources[Level.Advanced] = "Advanced Python Topics: https://docs.python.org/3/tutorial/advanced.html";
        }
    }
}
