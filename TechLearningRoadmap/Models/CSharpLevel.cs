
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
            LearningResources[Level.Beginner] = "C# Beginner Guide: https://learn.microsoft.com/en-us/dotnet/csharp/";
            LearningResources[Level.Intermediate] = "Intermediate C# Guide: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/";
            LearningResources[Level.Advanced] = "Advanced C# Topics: https://dotnet.microsoft.com/en-us/platform/aspnet";
        }
    }
}
