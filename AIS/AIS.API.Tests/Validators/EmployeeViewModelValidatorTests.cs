﻿using AIS.API.Validators;
using AIS.API.ViewModels.Employee;
using Xunit;

namespace AIS.API.Tests.Validators
{
    public class EmployeeViewModelValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new EmployeeViewModelValidator();

            var model = new EmployeeViewModel
            {
                Id = 2,
                Name = "asdasd",
                CompanyId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_ModelWithoutId_ReturnsFalse()
        {
            var validator = new EmployeeViewModelValidator();

            var model = new EmployeeViewModel
            {
                Name = "asdasd",
                CompanyId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.Equal(1, result.Errors.Count);
            Assert.Equal(result.Errors[0].PropertyName, "Id");
        }

        [Fact]
        public void Validate_ModelWithoutName_ReturnsFalse()
        {
            var validator = new EmployeeViewModelValidator();

            var model = new EmployeeViewModel
            {
                Id = 2,
                CompanyId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.Equal(1, result.Errors.Count);
            Assert.Equal(result.Errors[0].PropertyName, "Name");
        }

        [Fact]
        public void Validate_ModelWithoutCompanyId_ReturnsFalse()
        {
            var validator = new EmployeeViewModelValidator();

            var model = new EmployeeViewModel
            {
                Id = 2,
                Name = "asdasd"
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.Equal(1, result.Errors.Count);
            Assert.Equal(result.Errors[0].PropertyName, "CompanyId");
        }

        [Fact]
        public void Validate_IdLessThanOne_ReturnsFalse()
        {
            var validator = new EmployeeViewModelValidator();

            var model = new EmployeeViewModel
            {
                Id = 0,
                Name = "asdasd",
                CompanyId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.Equal(1, result.Errors.Count);
            Assert.Equal(result.Errors[0].PropertyName, "Id");
        }

        [Fact]
        public void Validate_CompanyIdLessThanOne_ReturnsFalse()
        {
            var validator = new EmployeeViewModelValidator();

            var model = new EmployeeViewModel
            {
                Id = 2,
                Name = "asdasd",
                CompanyId = 0
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.Equal(1, result.Errors.Count);
            Assert.Equal(result.Errors[0].PropertyName, "CompanyId");
        }

        [Fact]
        public void Validate_NameLengthLessThanThree_ReturnsFalse()
        {
            var validator = new EmployeeViewModelValidator();

            var model = new EmployeeViewModel
            {
                Id = 2,
                Name = "as",
                CompanyId = 1
            };

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.Equal(1, result.Errors.Count);
            Assert.Equal(result.Errors[0].PropertyName, "Name");
        }
    }
}
