using EmployeeManagement.Models.Departments;
using System;

namespace XunitTest
{
    public class DepartmentUnitTest
    {
        [Fact]
        public void Add_Department_Test()
        {
            // Arrange
            string expectedDepartName = "HR";
            var expectedDepartId = new Guid();
            Department testDepartment = new Department { Id = expectedDepartId, Name = expectedDepartName };

            // Act
            string actualDepartmentName = testDepartment.Name;
            var actualDepartId = testDepartment.Id;
                  
            // Assert
            Assert.Equal(expectedDepartName, actualDepartmentName);
            Assert.Equal(expectedDepartId, actualDepartId);

        }
        [Fact]
        public void DepartmentNameNotNull()
        {
            //Arrange
            string expectedName = null;
            var expectedDepartId = new Guid();



            //Act

            var caughtNameException = Assert.Throws<ArgumentException>(() =>
                                       new Department { Id = expectedDepartId,Name = expectedName});

            //Assert

            Assert.Equal("Name can't be empty/null Please Fill the Name", caughtNameException.Message);

        }
    }
}