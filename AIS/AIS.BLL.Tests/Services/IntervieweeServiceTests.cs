using System;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.BLL.Services;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace AIS.BLL.Tests.Services
{
    public class IntervieweeServiceTests
    {
        private readonly IGenericService<Interviewee> _service;
        private readonly Mock<IIntervieweeRepository> _intervieweeRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        public IntervieweeServiceTests()
        {
            _service = new IntervieweeService(_intervieweeRepoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetInterviewees_HasData_ReturnsIntervieweeList()
        {
            List<Interviewee> intervieweeList = new()
            {
                new()
                {
                    Id = 9,
                    Name = "Test",
                    AppliesFor = "Test",
                    CompanyId = 1
                }
            };
            List<IntervieweeEntity> intervieweeEntityList = new()
            {
                new()
                {
                    Id = 9,
                    Name = "Test",
                    AppliesFor = "Test",
                    CompanyId = 1
                }
            };
            _mapperMock.Setup(x => x.Map<IEnumerable<Interviewee>>(It.IsAny<IEnumerable<IntervieweeEntity>>()))
                .Returns(intervieweeList);
            _intervieweeRepoMock.Setup(x => x.Get(default)).ReturnsAsync(intervieweeEntityList);
            var result = await _service.Get(default);
            Assert.NotNull(result);
            Assert.Equal(intervieweeList.Count, result.Count());
            result.ShouldBeEquivalentTo(intervieweeList);
        }

        [Fact]
        public async Task GetIntervieweeById_ValidId_ReturnsIntervieweeById()
        {
            var interviewee = new Interviewee()
            {
                Id = 9,
                Name = "Test",
                AppliesFor = "Test",
                CompanyId = 1
            };
            var intervieweeEntity = new IntervieweeEntity()
            {
                Id = 9,
                Name = "Test",
                AppliesFor = "Test",
                CompanyId = 1
            };

            _mapperMock.Setup(x => x.Map<IntervieweeEntity>(It.IsAny<Interviewee>())).Returns(intervieweeEntity);
            _intervieweeRepoMock.Setup(x => x.GetById(6, default)).ReturnsAsync(intervieweeEntity);
            _mapperMock.Setup(x => x.Map<Interviewee>(It.IsAny<IntervieweeEntity>())).Returns(interviewee);
            // Act
            var result = await _service.GetById(interviewee.Id, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(interviewee.CompanyId, result.CompanyId);
            Assert.Equal(interviewee.Name, result.Name);
        }

        [Fact]
        public async Task AddInterviewee_ValidInterviewee_ReturnsInterviewee()
        {
            var interviewee = new Interviewee()
            {
                Name = "Test",
                AppliesFor = "Test",
                CompanyId = 1
            };
            var intervieweeEntity = new IntervieweeEntity()
            {
                Name = "Test",
                AppliesFor = "Test",
                CompanyId = 1
            };
            _mapperMock.Setup(x => x.Map<IntervieweeEntity>(It.IsAny<Interviewee>())).Returns(intervieweeEntity);
            _intervieweeRepoMock.Setup(x => x.Add(It.IsAny<IntervieweeEntity>(), default))
                .ReturnsAsync(intervieweeEntity);
            _mapperMock.Setup(x => x.Map<Interviewee>(It.IsAny<IntervieweeEntity>())).Returns(interviewee);
            // Act
            var result = await _service.Add(interviewee, default);

            // Assert
            Assert.Equal(interviewee, result);
            Assert.Equal(interviewee.Name, result.Name);
            Assert.Equal(interviewee.CompanyId, result.CompanyId);
        }

        [Fact]
        public void GetIntervieweeByPredicate_ValidPredicate_ReturnsIntervieweeList()
        {
            var intervieweeEntity = new List<IntervieweeEntity>
            {
                new()
                {
                    Name = "Test",
                    AppliesFor = "Test",
                    CompanyId = 1
                }
            };

            var interviewee = new IntervieweeEntity()
            {
                Name = "Test",
                AppliesFor = "Test",
                CompanyId = 1
            };

            var model = new Interviewee()
            {
                Name = "Test",
                AppliesFor = "Test",
                CompanyId = 1
            };

            _mapperMock.Setup(x => x.Map<IntervieweeEntity>(It.IsAny<Interviewee>())).Returns(interviewee);
            _intervieweeRepoMock.Setup(x => x.Add(intervieweeEntity[0], default)).ReturnsAsync(interviewee);
            _mapperMock.Setup(x => x.Map<Interviewee>(It.IsAny<IntervieweeEntity>())).Returns(model);
            var result = _service.Get(x => x.CompanyId == intervieweeEntity[0].CompanyId, default);
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task PutInterviewee_ValidInterviewee_ReturnsInterviewee()
        {
            var intervieweeEntity = new IntervieweeEntity()
            {
                Id = 1,
                Name = "Test",
                AppliesFor = "Test",
                CompanyId = 1
            };
            var interviewee = new Interviewee()
            {
                Id = 1,
                Name = "Test",
                AppliesFor = "Test",
                CompanyId = 1
            };

            _mapperMock.Setup(x => x.Map<IntervieweeEntity>(It.IsAny<Interviewee>())).Returns(intervieweeEntity);
            _intervieweeRepoMock.Setup(x => x.Update(intervieweeEntity, default)).ReturnsAsync(() => intervieweeEntity);
            _mapperMock.Setup(x => x.Map<Interviewee>(It.IsAny<IntervieweeEntity>())).Returns(interviewee);
            var expected = await _service.Put(interviewee, default);
            Assert.NotNull(expected);
            Assert.Equal(interviewee, expected);
            Assert.Equal(interviewee.Name, expected.Name);
        }

        [Fact]
        public void DeleteSession_ValidSession_ReturnsNotImplementedException()
        {
            var interviewee = new Interviewee()
            {
                Id = 1,
                Name = "Test",
                AppliesFor = "Test",
                CompanyId = 1
            };
            Action act = () => _service.Delete(interviewee, default);
            act.Should().Throw<NotImplementedException>();
        }

        [Fact]
        public async Task DeleteInterviewee_ValidId_ReturnsNull()
        {
            var intervieweeEntity = new IntervieweeEntity()
            {
                Id = 1,
                Name = "Test",
                AppliesFor = "Test",
                CompanyId = 1
            };
            var interviewee = new Interviewee()
            {
                Id = 1,
                Name = "Test",
                AppliesFor = "Test",
                CompanyId = 1
            };

            _mapperMock.Setup(x => x.Map<IntervieweeEntity>(It.IsAny<Interviewee>())).Returns(intervieweeEntity);
            _intervieweeRepoMock.Setup(x => x.Delete(intervieweeEntity, default));
            _mapperMock.Setup(x => x.Map<Interviewee>(It.IsAny<Interviewee>())).Returns(interviewee);
            _intervieweeRepoMock.Setup(x => x.GetById(interviewee.Id, default)).ReturnsAsync(intervieweeEntity);
            await _service.Delete(interviewee.Id, default).ShouldNotThrowAsync();
        }
    }
}