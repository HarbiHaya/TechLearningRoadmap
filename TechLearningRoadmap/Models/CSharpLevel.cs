
// Shahad Alamoudi 
// 2309063
// COCS307 - Assignment 1

namespace TechLearningRoadmap.Models
{

    // C# learning roadmap

    public class CSharpLevel : LanguageLevel
    {
        public CSharpLevel(Level level) : base(Language.CSharp, level) { }

  
        //  learning resources for C#
        protected override void AssignRoadmap()
        {
            LearningResources[Level.Beginner] = "Learn C# Basics: https://cursa.app/en/free-course/c-sharp-for-beginner-gdh?utm_source";
            LearningResources[Level.Intermediate] = "Object - Oriented Development in C#: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop?utm_source"; 
            LearningResources[Level.Advanced] = "Master C# with Real-World Applications https://www.youtube.com/watch?v=zFY8b1C1d3k";
        }
    }
}
