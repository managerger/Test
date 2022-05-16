using MSProject;
using System;
using System.IO;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var msProjectAnalyzer = new MSProjectAnalyzer();
            var currentProjectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            var projectToTest = Path.Combine(currentProjectDir, "ConsoleApp.csproj");
            var projectFilesList = msProjectAnalyzer.GetProjectItems(projectToTest);
        }
    }
}