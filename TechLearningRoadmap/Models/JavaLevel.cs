
// Shahad Alamoudi 
// 2309063
// COCS307 - Assignment 1

namespace TechLearningRoadmap.Models
{

    // Java learning roadmap

    public class JavaLevel : LanguageLevel
    {
        public JavaLevel(Level level) : base(Language.Java, level) { }

        // Assigns learning resources specific to Java
        protected override void AssignRoadmap()
        {
            LearningResources[Level.Beginner] = "Learn Programming Basics: https://www.coursera.org/specializations/programming-python-java?utm_source ";
            LearningResources[Level.Intermediate] = "Object-Oriented Programming: https://www.coursera.org/learn/java-programming?utm_source";
            LearningResources[Level.Advanced] = "Advanced Java Programming: Explore Advanced Java Topics (Multithreading, APIs, Databases): https://www.coursera.org/learn/java-programming?utm_source";
        }

    }
}
