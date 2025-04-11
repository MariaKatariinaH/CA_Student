using Moq;
using StudentEfCoreDemo.Application.Services;
using StudentEfCoreDemo.Domain.Entities;
using StudentEfCoreDemo.Domain.Interfaces;
using System.Net.Cache;

namespace StudentEfCoreDemo.Application.Tests
{
    public class StudentsServiceTests
    {
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        private readonly StudentsService _studentsService;

        public StudentsServiceTests() 
        {
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _studentsService = new StudentsService(_studentRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllStudentsAsync_ShouldReturnStudents()
        {
            //Arrange
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice", Age = 20 },
                new Student { Id = 2, Name = "Bob", Age = 21 }
            };
            _studentRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(students);

            //Act
            var result = await _studentsService.GetAllStudentsAsync();

            //Assert
            Assert.Equal(2,result.Count);
            Assert.Equal("Alice", result[0].Name);
        }

        [Fact]
        public async Task GetStudentByIdAsync_ShouldReturnStudent_WhenStudentExists()
        {
            //Arrange
            var student = new Student { Id = 1, Name = "Charlie", Age = 22 };
            _studentRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(student);

            //Act
            var result = await _studentsService.GetStudentByIdAsync(1);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Charlie", result.Name);
        }
    }
}