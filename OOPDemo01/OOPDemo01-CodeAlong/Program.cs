// See https://aka.ms/new-console-template for more information
using OOPDemo01_CodeAlong;
// Allows you to access the static methods in the Console class directly
using static System.Console;


// Classic object creation
Course cpsc1517Course = new Course("CPSC1517", "Introduction to Application Development");

// C Sharp new features
// var cpsc1517Course = new Course("CPSC1517", "Introduction to Application Development");
// Course cpsc1517Course = new("CPSC1517", "Introduction to Application Development");

WriteLine($"CourseNo: {cpsc1517Course.CourseNo}");
WriteLine($"CourseName: {cpsc1517Course.CourseName}");

// Add students to the course
//cpsc1517Course.AddStudent("Aaron Fong");
//cpsc1517Course.AddStudent("David L. McKinley");
//cpsc1517Course.AddStudent("Hamza Said");
//cpsc1517Course.AddStudent("Haseeb Memon");
//cpsc1517Course.AddStudent("Allaine Parades");
cpsc1517Course.LoadFromFile("demo1.txt");

// Display all the students in the course
foreach(string currentStudent in cpsc1517Course.Students )
{
    WriteLine(currentStudent);
}

// Remove 2 students from the Course
cpsc1517Course.RemoveStudent("Hamza Said");
cpsc1517Course.RemoveStudent("Haseeb Memon");
cpsc1517Course.RemoveStudent("James Skrlj");

// Save the changes to the file
cpsc1517Course.SaveToFile("demo1.txt");

// Display the number of students
WriteLine($"There are now {cpsc1517Course.StudentCount} students.");
