using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLearningRoadmap.Models
{
    /// <summary>
    /// Represents the Java learning roadmap.
    /// </summary>
    public class JavaLevel : LanguageLevel
    {
        public JavaLevel(Level level) : base(Language.Java, level) { }

        /// <summary>
        /// Assigns learning resources specific to Java.
        /// </summary>
        protected override void AssignRoadmap()
        {
            LearningResources[Level.Beginner] = "Java for Beginners: https://www.w3schools.com/java/";
            LearningResources[Level.Intermediate] = "Java Intermediate Concepts: https://docs.oracle.com/javase/tutorial/";
            LearningResources[Level.Advanced] = "Advanced Java Programming: https://developer.oracle.com/java/";
        }
    }
}
