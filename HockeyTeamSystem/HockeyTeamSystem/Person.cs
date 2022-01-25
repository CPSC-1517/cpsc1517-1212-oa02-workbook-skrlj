using System.Text.RegularExpressions; // for Regex class

namespace HockeyTeamSystem
{
    public class Person
    {
        // Define an auto implemented property with a private set for the full name
        // Private set property can only be assigned a value in the constructor or an instance method
        public string FullName { get; private set; }

        // Define a greedy constructor that takes a fullName as a parameter.
        // Constructors are used to create instance of an object and also to assign meaningful values
        // to the fields/properties of the class.
        public Person(string fullName)
        {
            // Validate that the fullName parameter is not null, whitespaces, or an empty string
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentNullException("Person FullName cannot be empty, null, or a whitespace");
            }

            // Validate that the fullName parameter contains only letters a-z and up to two space character.
            // @"" is a literal string where there is not meaning to any of the characters
            // ^ = start of the input
            // $ = end of input
            // [] = range of characters
            // {3,} = at least 3
            // {,2} = up to 2
            var fullNameCheck = new Regex(@"^[a-zA-Z ]{3,}$");
            if (fullNameCheck.IsMatch(fullName) == false)
            {
                throw new ArgumentException("Person FullName must contain at least 3 characters.");
            }

            // the keyword "this" refers to the current object and is used to access a field or property
            // of the current object
            this.FullName = fullName.Trim();
        }
    }
}
