using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.BLL.Services;
using AIS.BLL.Tests.Entities;
using AIS.BLL.Tests.Models;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AIS.BLL.Tests.Services
{
    public class QuestionAreaServiceTest
    {
        private readonly IQuestionAreaService _questionAreaService;
        private readonly Mock<IQuestionAreaRepository> _questionAreaMockRepository = new();
        private readonly Mock<IQuestionAreasQuestionSetsRepository> _questionAreasQuestionSetsRepositoryMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        public QuestionAreaServiceTest()
        {
            _questionAreaService = new QuestionAreaService(_questionAreaMockRepository.Object, _questionAreasQuestionSetsRepositoryMock.Object,
                _mapperMock.Object);
        }

        [Fact]
        public async Task GetById_ValidQuestionSet_ReturnsValidData()
        {
            var questionAreaModel = ValidQuestionAreaModels.questionAreaModel;
            var questionAreaEntity = ValidQuestionAreaEntities.questionAreaEntity;

            _mapperMock.Setup(x => x.Map<QuestionAreaEntity>(It.IsAny<QuestionArea>())).Returns(questionAreaEntity);
            _questionAreaMockRepository.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(questionAreaEntity);
            _mapperMock.Setup(x => x.Map<QuestionArea>(It.IsAny<QuestionAreaEntity>())).Returns(questionAreaModel);

            var actual = await _questionAreaService.GetById(questionAreaModel.Id, default);

            actual.ShouldBeEquivalentTo(questionAreaModel);
        }

        [Fact]
        public async Task DeleteById_SuccessDelete()
        {
            _questionAreaMockRepository.Setup(x => x.Delete(It.IsAny<int>(), default));
            await _questionAreaService.Delete(5, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task Update_ValidData_ReturnValidData()
        {
            var questionAreaModel = ValidQuestionAreaModels.questionAreaModel;
            var questionAreaEntity = ValidQuestionAreaEntities.questionAreaEntity;

            _mapperMock.Setup(x => x.Map<QuestionAreaEntity>(It.IsAny<QuestionArea>())).Returns(questionAreaEntity);
            _questionAreaMockRepository.Setup(x => x.Update(It.IsAny<QuestionAreaEntity>(), default)).ReturnsAsync(questionAreaEntity);
            _mapperMock.Setup(x => x.Map<QuestionArea>(It.IsAny<QuestionAreaEntity>())).Returns(questionAreaModel);

            var actual = await _questionAreaService.Put(questionAreaModel, default);

            actual.ShouldBeEquivalentTo(questionAreaModel);
        }

        [Fact]
        public async Task Add_ValidData_ReturnValidData()
        {
            var questionAreaModel = ValidQuestionAreaModels.questionAreaAddModel;
            var questionAreaEntity = ValidQuestionAreaEntities.questionAreaAddEntity;

            _mapperMock.Setup(x => x.Map<QuestionAreaEntity>(It.IsAny<QuestionArea>())).Returns(questionAreaEntity);
            _questionAreaMockRepository.Setup(x => x.Add(It.IsAny<QuestionAreaEntity>(), default)).ReturnsAsync(questionAreaEntity);
            _mapperMock.Setup(x => x.Map<QuestionArea>(It.IsAny<QuestionAreaEntity>())).Returns(questionAreaModel);

            var actual = await _questionAreaService.Add(questionAreaModel, default);

            actual.Name.ShouldBeEquivalentTo(questionAreaModel.Name);
        }

        [Fact]
        public async Task GetAll_ReturnValidData()
        {
            var questionAreaModelList = ValidQuestionAreaModels.questionAreaModelList;
            var questionAreaEntityList = ValidQuestionAreaEntities.questionAreaModelList;

            _questionAreaMockRepository.Setup(x => x.Get(default)).ReturnsAsync(questionAreaEntityList);
            _mapperMock.Setup(x => x.Map<IEnumerable<QuestionArea>>(It.IsAny<IEnumerable<QuestionAreaEntity>>()))
                .Returns(questionAreaModelList);

            var actual = await _questionAreaService.Get(default);

            actual.ShouldBeEquivalentTo(questionAreaModelList);
        }
    }
}
