using AIS.API.Validators;
using AIS.API.ViewModels.Company;
using AIS.API.ViewModels.Interviewee;
using System.Linq;
using Xunit;

namespace AIS.API.Tests.Validators
{
    public class ChangeIntervieweeViewModelValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new ChangeIntervieweeViewModelValidator();

            var model = new ChangeIntervieweeViewModel
            {
                Name = "asdasd",
                CompanyId = 1,
                AppliesFor = "something..."
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_ModelWithoutName_ReturnsFalse()
        {
            var validator = new ChangeCompanyViewModelValidator();

            var model = new ChangeCompanyViewModel();

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.NotEqual(0, result.Errors.Count);
            Assert.True(result.Errors.Any(x => x.PropertyName == nameof(model.Name)));
        }

        [Fact]
        public void Validate_ModelWithoutCompanyId_ReturnsFalse()
        {
            var validator = new ChangeIntervieweeViewModelValidator();

            var model = new ChangeIntervieweeViewModel
            {
                Name = "asd",
                AppliesFor = "asd"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.NotEqual(0, result.Errors.Count);
            Assert.True(result.Errors.Any(x => x.PropertyName == nameof(model.CompanyId)));
        }

        [Fact]
        public void Validate_ModelWithoutAppliesFor_ReturnsFalse()
        {
            var validator = new ChangeIntervieweeViewModelValidator();

            var model = new ChangeIntervieweeViewModel()
            {
                Name = "asd",
                CompanyId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.NotEqual(0, result.Errors.Count);
            Assert.True(result.Errors.Any(x => x.PropertyName == nameof(model.AppliesFor)));
        }

        [Fact]
        public void Validate_CompanyIdLessThanOne_ReturnsFalse()
        {
            var validator = new ChangeIntervieweeViewModelValidator();

            var model = new ChangeIntervieweeViewModel
            {
                Name = "asd",
                AppliesFor = "asd"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.NotEqual(0, result.Errors.Count);
            Assert.True(result.Errors.Any(x => x.PropertyName == nameof(model.CompanyId)));
        }

        [Fact]
        public void Validate_AppliesForLengthLessThanThree_ReturnsFalse()
        {
            var validator = new ChangeIntervieweeViewModelValidator();

            var model = new ChangeIntervieweeViewModel
            {
                AppliesFor = "as",
                Name = "asd",
                CompanyId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.NotEqual(0, result.Errors.Count);
            Assert.True(result.Errors.Any(x => x.PropertyName == nameof(model.AppliesFor)));
        }

        [Fact]
        public void Validate_NameLengthLessThatThree_ReturnsFalse()
        {
            var validator = new ChangeIntervieweeViewModelValidator();

            var model = new ChangeIntervieweeViewModel
            {
                Name = "as",
                AppliesFor = "asd",
                CompanyId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.NotEqual(0, result.Errors.Count);
            Assert.True(result.Errors.Any(x => x.PropertyName == nameof(model.Name)));
        }
    }
}
