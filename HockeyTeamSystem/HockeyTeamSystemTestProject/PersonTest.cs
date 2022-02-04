using Microsoft.VisualStudio.TestTools.UnitTesting;
using HockeyTeamSystem;
using System;

namespace HockeyTeamSystemTestProject
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        [DataRow("Connor McDavid")]
        [DataRow("Ryan Nugent-Hopkins")]
        public void FullName_ValidValue_NoErrors(string fullName)
        {
            Person person1 = new(fullName);
            // Assert class contains methods that can compare results
            Assert.AreEqual(fullName, person1.FullName);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("      \n\t")]
        public void FullName_NoName_ThrowException(string fullName)
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() => {
                Person person1 = new(fullName);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual("Person FullName cannot be empty, null, or a whitespace", exception.ParamName);
        }

        [TestMethod]
        [DataRow("A")]
        [DataRow("AB")]
        [DataRow("A B")]

        public void FullName_InvalidNameLength_ThrowException(string fullName)
        {
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() => {
                Person person1 = new(fullName);
            });

            Assert.IsNotNull(exception);
            Assert.AreEqual("Person FullName must contain at least 5 characters.", exception.Message);
        }

    }
}