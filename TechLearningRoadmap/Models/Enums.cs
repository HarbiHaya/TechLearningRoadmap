using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLearningRoadmap.Models
{
    /// <summary>
    /// Represents available programming languages.
    /// </summary>
    public enum Language
    {
        None,  // ✅ Default value when the user hasn't selected a language
        CSharp,
        Java,
        Python
    }

    /// <summary>
    /// Represents experience levels in a programming language.
    /// </summary>
    public enum Level
    {
        None,  // ✅ Default value when the user hasn't selected a level
        Beginner,
        Intermediate,
        Advanced
    }
}
