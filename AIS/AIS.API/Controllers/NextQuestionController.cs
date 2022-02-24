using AIS.API.ViewModels.Question;
using AIS.BLL.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NextQuestionController : ControllerBase
    {
        private readonly INextQuestionService _service;
        private readonly IMapper _mapper;

        public NextQuestionController(INextQuestionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<QuestionViewModel> Next(int sessionId, CancellationToken ct)
        { 
            return _mapper.Map<QuestionViewModel>(await _service.Next(sessionId, ct));
        }
    }
}
