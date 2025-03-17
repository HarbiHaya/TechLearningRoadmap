
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
            LearningResources[Level.Beginner] = "Java for Beginners:  https://www.w3schools.com/java/";
            LearningResources[Level.Intermediate] = "Java Intermediate Concepts: https://docs.oracle.com/javase/tutorial/";
            LearningResources[Level.Advanced] = "Advanced Java Programming: https://developer.oracle.com/java/";
        }
    }
}
