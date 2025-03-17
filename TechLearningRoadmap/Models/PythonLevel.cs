
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
            LearningResources[Level.Beginner] = "Python Basics: https://www.python.org/about/gettingstarted/";
            LearningResources[Level.Intermediate] = "Python Intermediate Guide: https://realpython.com/";
            LearningResources[Level.Advanced] = "Advanced Python Topics: https://docs.python.org/3/tutorial/advanced.html";
        }
    }
}
