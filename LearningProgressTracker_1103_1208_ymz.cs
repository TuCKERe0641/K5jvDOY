// 代码生成时间: 2025-11-03 12:08:38
using System;
using System.Collections.Generic;

namespace LearningProgressTracking
{
    // Represents a learning module and its progress
    public class LearningModule
    {
        public string Name { get; set; }
        public double PercentageComplete { get; set; }

        public LearningModule(string name, double percentageComplete)
        {
            Name = name;
            PercentageComplete = percentageComplete;
        }
    }

    // Tracks the learning progress of a student
    public class LearningProgressTracker
    {
        // Stores the learning modules and their progress
        private Dictionary<string, LearningModule> progressMap = new Dictionary<string, LearningModule>();

        // Adds a new learning module or updates an existing one
        public void AddOrUpdateModule(string moduleName, double percentageComplete)
        {
            if (string.IsNullOrEmpty(moduleName))
            {
                throw new ArgumentException("Module name cannot be null or empty.");
            }

            progressMap[moduleName] = new LearningModule(moduleName, percentageComplete);
        }

        // Retrieves the progress of a learning module
        public LearningModule GetModuleProgress(string moduleName)
        {
            if (string.IsNullOrEmpty(moduleName))
            {
                throw new ArgumentException("Module name cannot be null or empty.");
            }

            if (progressMap.TryGetValue(moduleName, out LearningModule module))
            {
                return module;
            }
            else
            {
                throw new KeyNotFoundException($"No learning module found with the name: {moduleName}");
            }
        }

        // Retrieves all learning modules and their progress
        public IEnumerable<LearningModule> GetAllModulesProgress()
        {
            return progressMap.Values;
        }
    }

    // The main class to execute the learning progress tracking program
    class Program
    {
        static void Main(string[] args)
        {
            LearningProgressTracker tracker = new LearningProgressTracker();

            try
            {
                // Simulate adding and updating learning progress
                tracker.AddOrUpdateModule("Mathematics", 75.0);
                tracker.AddOrUpdateModule("Science", 60.0);
                tracker.AddOrUpdateModule("History", 80.0);

                // Retrieve and display progress of a single module
                LearningModule mathProgress = tracker.GetModuleProgress("Mathematics");
                Console.WriteLine($"Mathematics Progress: {mathProgress.PercentageComplete}%");

                // Retrieve and display progress of all modules
                foreach (var module in tracker.GetAllModulesProgress())
                {
                    Console.WriteLine($"Module: {module.Name}, Progress: {module.PercentageComplete}%");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}