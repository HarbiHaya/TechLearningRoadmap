
// Shahad Alamoudi 
// 2309063
// COCS307 - Assignment 1

namespace TechLearningRoadmap.Models
{
    
    /// Python learning roadmap

    public class PythonLevel : LanguageLevel
    {
        public PythonLevel(Level level) : base(Language.Python, level) { }

    
        //  learning resources recpmmended to Python
     
        protected override void AssignRoadmap() // protected to allow only subclasses to access
      
        {
            LearningResources[Level.Beginner] = "Learn Python Fundamentals: https://cs50.harvard.edu/python/2022/?utm_source";
            LearningResources[Level.Intermediate] = "Python Intermediate Guide: Enhance Python Skills with Intermediate Topics: https://realpython.com/tutorials/intermediate/?utm_source"; 
            LearningResources[Level.Advanced] = "Advanced Python Topics: https://www.youtube.com/playlist?list=PLDVrhnY7hFVoA0N5NhRA9lPur5dxXBujy";
        }
    }
}
