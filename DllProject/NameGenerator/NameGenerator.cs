using System;
using System.Collections.Generic;

namespace NameGenerator
{
    public class EnglishNameGenerator
    {
        private static readonly List<string> FirstNames = new List<string>
        {
            "James", "John", "Robert", "Michael", "William",
            "David", "Richard", "Joseph", "Thomas", "Charles",
            "Mary", "Patricia", "Jennifer", "Linda", "Elizabeth",
            "Barbara", "Susan", "Jessica", "Sarah", "Karen"
        };

        private static readonly List<string> LastNames = new List<string>
        {
            "Smith", "Johnson", "Williams", "Brown", "Jones",
            "Miller", "Davis", "Garcia", "Rodriguez", "Wilson",
            "Anderson", "Taylor", "Moore", "Jackson", "Martin",
            "Lee", "Thompson", "White", "Harris", "Clark"
        };

        private static readonly Random Random = new Random();

        public static string GenerateRandomName()
        {
            string firstName = FirstNames[Random.Next(FirstNames.Count)];
            string lastName = LastNames[Random.Next(LastNames.Count)];
            return $"{firstName} {lastName}";
        }
    }
}