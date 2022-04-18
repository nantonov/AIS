const config = {
  COMPANY_URL: 'api/Company',
  EMPLOYEE_URL: 'api/Employee',
  INTERVIEWEE_URL: 'api/Interviewee',
  QUESTION_URL: 'api/Questions',
  QUESTION_AREA_URL: 'api/QuestionArea',
  QUESTION_INTERVIEWEE_ANSWER_URL: 'api/QuestionIntervieweeAnswer',
  QUESTION_SET_URL: 'api/QuestionSet',
  SESSION_URL: 'api/Session',
  TRUE_ANSWER_URL: 'api/TrueAnswers',
  DELETE_BY_TWO_IDS_QUESTION_AREA: 'api/QuestionAreasQuestionSets/deleteByTwoIds',
  DELETE_BY_TWO_IDS_QUESTION: 'api/QuestionsQuestionSets/deleteByTwoIds',
};

const localConfig = require('./config.local').default;

Object.assign(config, localConfig);

export default config;
