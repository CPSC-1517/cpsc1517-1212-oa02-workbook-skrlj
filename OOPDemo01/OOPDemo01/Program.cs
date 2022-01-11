// See https://aka.ms/new-console-template for more information

// Prompt user for Course name and number
Console.Write("Enter the course number: ");
string courseNo = Console.ReadLine();
Console.Write("Enter the course name: ");
string courseName = Console.ReadLine();
Console.WriteLine();

// Create a Course with the required properties
Course newCourse = new Course(courseNo, courseName);
int exitChoice = 0;
int menuChoice;

do
{
    Console.WriteLine("1. Add a Student to the Course");
    Console.WriteLine("2. Remove a Student from the Course");
    Console.WriteLine("3. Recieve number of students in the Course");
    Console.WriteLine("0. Exit menu");
    Console.Write("Your choice: ");
    menuChoice = int.Parse(Console.ReadLine());
    Console.WriteLine();

    switch(menuChoice)
    {
        case 1:
            {
                Console.Write("Enter the name of the student: ");
                newCourse.AddStudent(Console.ReadLine());
                Console.WriteLine();
            }
            break;

        case 2:
            {
                Console.WriteLine($"Current Students in {courseName}");
                foreach(string s in newCourse.Students)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.Write("Enter the name of the student to remove: ");
                newCourse.DropStudent(Console.ReadLine());
                Console.WriteLine();
            }
            break;

        case 3:
            {
                Console.WriteLine(newCourse.StudentCount());
                Console.WriteLine();
            }
            break;

        case 0:
            {
                Console.WriteLine("Goodbye!");
            }
            break;

        default:
            {
                Console.WriteLine("Invalid menu choice. Try again.");
                Console.WriteLine();
            }
            break;
    }
} while (menuChoice != exitChoice);

public class Course
{
    private List<string> _students = new List<string>();
    public string CourseNo { get; set; }
    public string CourseName { get; set; }
    public List<string> Students { get; set; }
    
    public Course(string courseNo, string courseName)
    {
        CourseNo = courseNo;
        CourseName = courseName;
        Students = _students;
    }

    public void AddStudent(string student)
    {
        Students.Add(student);
    }

    public void DropStudent(string student)
    {
        Students.Remove(student);
    }

    public int StudentCount()
    {
        return Students.Count();
    }
}

