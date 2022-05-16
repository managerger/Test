using Buildalyzer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MSProject
{
    public class MSProjectAnalyzer
    {
        private readonly IEnumerable<string> _projectItemTypes = new[] { "ClCompile", "ClInclude", "ResourceCompile", "Compile", "EmbeddedResource", "Content", "None" };

        public List<string> GetProjectItems(string projectFilePath)
        {
            AnalyzerManager manager = new AnalyzerManager();
            IProjectAnalyzer analyzer = manager.GetProject(projectFilePath);
            IAnalyzerResults results = analyzer.Build();
            IAnalyzerResult result = results.First();

            List<string> projectItemTypes = new List<string>();
            var projectItemFiles = result.Items.Where(i => _projectItemTypes.Contains(i.Key)).SelectMany(i => i.Value).Select(i => Path.Combine(analyzer.SolutionDirectory, i.ItemSpec)).ToList();

            return projectItemFiles;
        }
    }
}