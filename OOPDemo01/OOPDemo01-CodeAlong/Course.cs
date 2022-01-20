using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo01_CodeAlong
{
    internal class Course
    {
        #region Define readonly data fields
        public readonly string CourseNo;

        // Define a backing field for CourseName
        private string _CourseName;

        // Define a private set property for CourseName
        public string CourseName
        {
            get { return _CourseName; }
            private set // Can only be changed by methods within this class. External code will not be allowed to change it.
            {
                // Validate that the courseName is not null or an empty string
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidOperationException("Course CourseName value is required.");
                }
                _CourseName = value.Trim();
            }
        }

        public readonly List<string> Students = new List<string>();
        #endregion

        #region Readonly Property
        public int StudentCount
        {
            get { return Students.Count; }
        }
        #endregion

        #region Constructors
        public Course(string courseNo, string courseName)
        {
            // Validate that courseNo is not null or an empty string, and must contain exactly 7
            // characters where the first 4 characters are letters and the last 4 characters are digits
            if ( string.IsNullOrEmpty( courseNo ) )
            {
                throw new ArgumentNullException("CourseNo is required.");
            }
            if (courseNo.Length != 8)
            {
                throw new ArgumentException("CourseNo must contain exactly 8 characters");
            }
            CourseNo = courseNo;

            CourseName = courseName;
        }
        #endregion

        #region Instance-Level Methods
        public void AddStudent(string name)
        {
            Students.Add(name);
        }

        public void RemoveStudent(string name)
        {
            Students.Remove(name);
        }

        public bool SaveToFile(string filepath)
        {
            bool success = false;

            try
            {
                using (StreamWriter writer = new StreamWriter(filepath))
                {
                    // Write the courseNo and courseName to the file
                    writer.WriteLine(CourseNo);
                    writer.WriteLine(CourseName);
                    // Write the name of all the students in the course
                    foreach (string student in Students)
                    {
                        writer.WriteLine(student);
                    }
                    success = true;
                }
            }
            catch
            {
                success = false;
            }

            return success;
        }
        #endregion

        public bool LoadFromFile(string filepath)
        {
            bool success = false;

            try
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    // Read the CourseNo and CourseName from the file
                    var courseNo = reader.ReadLine();
                    var courseName = reader.ReadLine();

                    // Read the student names from the file
                    while(reader.EndOfStream == false)
                    {
                        // ? means that the data type is Nullable meaning they might not have a value 
                        string? lineData = reader.ReadLine();
                        if (!string.IsNullOrEmpty(lineData))
                        {
                            Students.Add(lineData);
                        } 
                    }
                }
            }

            catch
            {
                success = false;
            }
            
            return success;
        }
    }
}
