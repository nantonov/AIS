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
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AIS.BLL.Tests.Services
{
    public class QuestionSetServiceTest
    {
        private readonly IQuestionSetService _questionSetService;
        private readonly Mock<IQuestionSetRepository> _questionSetMockRepository = new();
        private readonly Mock<IQuestionAreasQuestionSetsRepository> _questionAreasQuestionSetsRepositoryMock = new();
        private readonly Mock<IQuestionsQuestionSetsRepository> _questionsQuestionRepositoryMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        public QuestionSetServiceTest()
        {
            _questionSetService = new QuestionSetService(_questionSetMockRepository.Object, _questionAreasQuestionSetsRepositoryMock.Object,
                _questionsQuestionRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetById_ValidQuestionSet_ReturnsValidData()
        {
            var questionSetModel = ValidQuestionSetModels.questionSetModel;
            var questionSetEntity = ValidQuestionSetEntities.questionSetModel;

            _mapperMock.Setup(x => x.Map<QuestionSetEntity>(It.IsAny<QuestionSet>())).Returns(questionSetEntity);
            _questionSetMockRepository.Setup(x => x.GetById(int.MaxValue, default)).ReturnsAsync(questionSetEntity);
            _mapperMock.Setup(x => x.Map<QuestionSet>(It.IsAny<QuestionSet>())).Returns(questionSetModel);

            var actual = await _questionSetService.GetById(questionSetModel.Id, default);

            actual.ShouldBeEquivalentTo(questionSetModel);
        }

        [Fact]
        public async Task DeleteById_SuccessDelete()
        {
            _questionSetMockRepository.Setup(x => x.Delete(int.MaxValue, default));
            await _questionSetService.Delete(5, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task Update_ValidData_ReturnValidData()
        {
            var questionSetModel = ValidQuestionSetModels.questionSetModel;
            var questionSetEntity = ValidQuestionSetEntities.questionSetModel;

            _mapperMock.Setup(x => x.Map<QuestionSetEntity>(It.IsAny<QuestionSet>())).Returns(questionSetEntity);
            _questionSetMockRepository.Setup(x => x.Update(questionSetEntity, default)).ReturnsAsync(questionSetEntity);
            _mapperMock.Setup(x => x.Map<QuestionSet>(It.IsAny<QuestionSetEntity>())).Returns(questionSetModel);

            var actual = await _questionSetService.Put(questionSetModel, default);

            actual.ShouldBeEquivalentTo(questionSetModel);
        }

        [Fact]
        public async Task Add_ValidData_ReturnValidData()
        {
            var questionSetAddModel = ValidQuestionSetModels.questionSetAddModel;
            var questionSetAddEntity = ValidQuestionSetEntities.questionSetAddEntity;

            _mapperMock.Setup(x => x.Map<QuestionSetEntity>(It.IsAny<QuestionSet>())).Returns(questionSetAddEntity);
            _questionSetMockRepository.Setup(x => x.Add(questionSetAddEntity, default)).ReturnsAsync(questionSetAddEntity);
            _mapperMock.Setup(x => x.Map<QuestionSet>(It.IsAny<QuestionSetEntity>())).Returns(questionSetAddModel);
            var actual = await _questionSetService.Add(questionSetAddModel, default);

            actual.Name.ShouldBeEquivalentTo(questionSetAddModel.Name);
        }

        [Fact]
        public async Task GetAll_ReturnValidData()
        {
            var questionSetModelList = ValidQuestionSetModels.questionSetModelList;
            var questionSetEntityList = ValidQuestionSetEntities.questionSetModelList;

            _questionSetMockRepository.Setup(x => x.Get(default)).ReturnsAsync(questionSetEntityList);
            _mapperMock.Setup(x => x.Map<IEnumerable<QuestionSet>>(It.IsAny<IEnumerable<QuestionSetEntity>>()))
                .Returns(questionSetModelList);

            var actual = await _questionSetService.Get(default);

            actual.ShouldBeEquivalentTo(questionSetModelList);
        }
    }
}
