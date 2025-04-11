using System.Net.Cache;
using StudentEfCoreDemo.Domain.Entities;

namespace StudentEfCoreDemo.Domain.Tests
{
    public class StudentTests
    {
        [Fact]
        public void Student_Should_Have_Valid_Properties()
        {
            //Arrange
            var student = new Student
            {
                Id = 1,
                Name = "John Doe",
                Age = 22
            };

            //Act and Assert
            Assert.Equal(1, student.Id);
            Assert.Equal("John Doe", student.Name);
            Assert.Equal(22, student.Age);
        }
    }
}