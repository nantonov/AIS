using AIS.API.Validators.Session;
using AIS.API.ViewModels.Session;
using Shouldly;
using Xunit;

namespace AIS.API.Tests.Validators.Session
{
    public class SessionUpdateViewModelValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new SessionUpdateViewModelValidator();
            var model = new SessionUpdateViewModel
            {
                QuestionAreaId = 1,
                CompanyId = 1,
                EmployeeId = 1,
                IntervieweeId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Validate_WithoutQuestionAreaId_ReturnsFalse()
        {
            var validator = new SessionUpdateViewModelValidator();
            var model = new SessionUpdateViewModel
            {
                CompanyId = 1,
                EmployeeId = 1,
                IntervieweeId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionAreaId));
        }

        [Fact]
        public void Validate_WithoutCompanyId_ReturnsFalse()
        {
            var validator = new SessionUpdateViewModelValidator();
            var model = new SessionUpdateViewModel
            {
                QuestionAreaId = 1,
                EmployeeId = 1,
                IntervieweeId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.CompanyId));
        }

        [Fact]
        public void Validate_WithoutEmployeeId_ReturnsFalse()
        {
            var validator = new SessionUpdateViewModelValidator();
            var model = new SessionUpdateViewModel
            {
                QuestionAreaId = 1,
                CompanyId = 1,
                IntervieweeId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.EmployeeId));
        }

        [Fact]
        public void Validate_WithoutIntervieweeId_ReturnsFalse()
        {
            var validator = new SessionUpdateViewModelValidator();
            var model = new SessionUpdateViewModel
            {
                QuestionAreaId = 1,
                CompanyId = 1,
                EmployeeId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.IntervieweeId));
        }

        [Fact]
        public void Validate_QuestionAreaIdLessThanOne_ReturnsFalse()
        {
            var validator = new SessionUpdateViewModelValidator();
            var model = new SessionUpdateViewModel
            {
                QuestionAreaId = 0,
                CompanyId = 1,
                EmployeeId = 1,
                IntervieweeId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.QuestionAreaId));
        }

        [Fact]
        public void Validate_CompanyIdLessThanOne_ReturnsFalse()
        {
            var validator = new SessionUpdateViewModelValidator();
            var model = new SessionUpdateViewModel
            {
                QuestionAreaId = 1,
                CompanyId = 0,
                EmployeeId = 1,
                IntervieweeId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.CompanyId));
        }

        [Fact]
        public void Validate_EmployeeIdLessThanOne_ReturnsFalse()
        {
            var validator = new SessionUpdateViewModelValidator();
            var model = new SessionUpdateViewModel
            {
                QuestionAreaId = 1,
                CompanyId = 1,
                EmployeeId = 0,
                IntervieweeId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.EmployeeId));
        }

        [Fact]
        public void Validate_IntervieweeIdLessThanOne_ReturnsFalse()
        {
            var validator = new SessionUpdateViewModelValidator();
            var model = new SessionUpdateViewModel
            {
                QuestionAreaId = 1,
                CompanyId = 1,
                EmployeeId = 1,
                IntervieweeId = 0
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.IntervieweeId));
        }
    }
}
