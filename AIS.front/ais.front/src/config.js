const config = {};

/*if (process.env.APP_ENV === 'development'){
  const devConfig = require('./config.dev.js').default;
  Object.assign(config, devConfig);
}
else {*/
  const localConfig = require('./config.local.js').default;
  Object.assign(config, localConfig);
//}
config.COMPANY_URL = 'api/Company';
config.EMPLOYEE_URL = 'api/Employee';
config.INTERVIEWEE_URL = 'api/Interviewee';
config.QUESTION_URL = 'api/Questions';
config.QUESTION_AREA_URL = 'api/QuestionArea';
config.QUESTION_URL = 'api/Question';
config.QUESTION_AREA_URL = 'api/QuestionsSets';
config.QUESTION_INTERVIEWEE_ANSWER_URL = 'api/QuestionIntervieweeAnswer';
config.QUESTION_SET_URL = 'api/QuestionSet';
config.SESSION_URL = 'api/Session';
config.TRUE_ANSWER_URL = 'api/TrueAnswer';
config.DELETE_BY_TWO_IDS_QUESTION_AREA = 'api/QuestionAreasQuestionSets/deleteByTwoIds'
config.DELETE_BY_TWO_IDS_QUESTION = 'api/QuestionsQuestionSets/deleteByTwoIds'
export const Config = config;
