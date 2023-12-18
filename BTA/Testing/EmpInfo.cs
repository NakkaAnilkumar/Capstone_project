using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Testing
{
    [TestFixture]
    public class EmpInfoTests
    {
        private EmpInfo _empInfo; // Assuming you have a repository or data context class

        [SetUp]
        public void Setup()
        {
            // Initialize your data context or repository before each test
            _empInfo = new EmpInfo(); // Adjust this based on your actual implementation
        }

        [Test]
        public void EmpInfo_ValidData_ShouldPassValidation()
        {
            // Arrange
            EmpInfo empInfo = new EmpInfo
            {
                Email = "test@example.com",
                Name = "John Doe",
                DateOfJoining = DateTime.Now,
                PassCode = 123456
            };

            // Act
            var validationResults = ValidateModel(empInfo);

            // Assert
            Assert.IsEmpty(validationResults, "Validation should pass");
        }

        [Test]
        public void EmpInfo_MissingEmail_ShouldFailValidation()
        {
            // Arrange
            EmpInfo empInfo = new EmpInfo
            {
                // Missing Email intentionally
                Name = "John Doe",
                DateOfJoining = DateTime.Now,
                PassCode = 123456
            };

            // Act
            var validationResults = ValidateModel(empInfo);

            // Assert
            Assert.IsNotEmpty(validationResults, "Validation should fail");
            Assert.IsTrue(HasErrorMessage(validationResults, "The Email field is required."));
        }

        // Add more test cases as needed...

        private System.Collections.Generic.List<ValidationResult> ValidateModel(object model)
        {
            var validationContext = new ValidationContext(model, null, null);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();

            Validator.TryValidateObject(model, validationContext, validationResults, true);

            return validationResults;
        }

        private bool HasErrorMessage(System.Collections.Generic.List<ValidationResult> validationResults, string errorMessage)
        {
            return validationResults.Any(result => result.ErrorMessage != null && result.ErrorMessage.Contains(errorMessage));
        }
    }
}

