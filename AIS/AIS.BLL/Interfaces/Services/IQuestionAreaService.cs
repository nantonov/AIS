using AIS.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.BLL.Interfaces.Services
{
    public interface IQuestionAreaService : IGenericService<QuestionArea>
    {
        new Task<QuestionArea> Add(QuestionArea entity, CancellationToken ct);
    }
}
