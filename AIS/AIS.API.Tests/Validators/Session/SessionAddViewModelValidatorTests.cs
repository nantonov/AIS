using AIS.API.Validators.Session;
using AIS.API.ViewModels.Session;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AIS.API.Tests.Validators.Session
{
    public class SessionAddViewModelValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new SessionAddViewModelValidator();
            var model = new SessionAddViewModel
            {
                QuestionAreaId = 1,
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
            var validator = new SessionAddViewModelValidator();
            var model = new SessionAddViewModel
            {
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
        public void Validate_WithoutEmployeeId_ReturnsFalse()
        {
            var validator = new SessionAddViewModelValidator();
            var model = new SessionAddViewModel
            {
                QuestionAreaId = 1,
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
            var validator = new SessionAddViewModelValidator();
            var model = new SessionAddViewModel
            {
                QuestionAreaId = 1,
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
            var validator = new SessionAddViewModelValidator();
            var model = new SessionAddViewModel
            {
                QuestionAreaId = 0,
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
        public void Validate_EmployeeIdLessThanOne_ReturnsFalse()
        {
            var validator = new SessionAddViewModelValidator();
            var model = new SessionAddViewModel
            {
                QuestionAreaId = 1,
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
            var validator = new SessionAddViewModelValidator();
            var model = new SessionAddViewModel
            {
                QuestionAreaId = 1,
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
