using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLearningRoadmap.Models
{
    /// <summary>
    /// Represents the C# learning roadmap.
    /// </summary>
    public class CSharpLevel : LanguageLevel
    {
        public CSharpLevel(Level level) : base(Language.CSharp, level) { }

        /// <summary>
        /// Assigns learning resources specific to C#
        /// </summary>
        protected override void AssignRoadmap()
        {
            LearningResources[Level.Beginner] = "C# Beginner Guide: https://learn.microsoft.com/en-us/dotnet/csharp/";
            LearningResources[Level.Intermediate] = "Intermediate C# Guide: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/";
            LearningResources[Level.Advanced] = "Advanced C# Topics: https://dotnet.microsoft.com/en-us/platform/aspnet";
        }
    }
}
