using AIS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS.DAL.Tests.Entity
{
    public static class ValidQuestionAreasEntities
    {
        public static readonly QuestionAreaEntity ValidGetQuestionAreaById = new()
        {
            Name = "Question area name GetQuestionAreaById"
        };

        public static readonly ImmutableList<QuestionAreaEntity> ValidGetQuestionAreas = new List<QuestionAreaEntity>
            {
                new()
                {
                    Name = "Question area GetQuestionAreas 1"
                },
                new()
                {
                    Name = "Question area GetQuestionAreas 2"
                }
            }.ToImmutableList();

        public static readonly QuestionAreaEntity ValidAddQuestionArea = new QuestionAreaEntity
        {
            Name = "Question area AddQuestionArea"
        };

        public static readonly QuestionAreaEntity ValidUpdateQuestionAreaAdded = new QuestionAreaEntity
        {
            Name = "Question area name UpdateQuestionArea add"
        };
        public static readonly QuestionAreaEntity ValidUpdateQuestionAreaUpdated = new QuestionAreaEntity
        {
            Name = "Question area name UpdateQuestionArea update"
        };

        public static readonly ImmutableList<QuestionAreaEntity> ValidGetQuestionAreaByPredicate = new List<QuestionAreaEntity> 
            {
                    new()
                    {
                        Name = "Question area GetQuestionAreaByPredicate"
                    },
                    new QuestionAreaEntity
                    {
                        Name = "Question area GetQuestionAreaByPredicate"
                    },
                }.ToImmutableList();

        public static readonly QuestionAreaEntity ValidDeleteQuestionArea = new QuestionAreaEntity
        {
            Name = "Question area DeleteQuestionArea"
        };
    }
}
