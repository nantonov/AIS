import { QuestionSet } from '../../interfaces/questionSet/questionSet';

export const defaultQuestionSet: QuestionSet = {
  id: 0,
  name: '',
  questionAreaId: 0,
  questionAreas: null,
  questions: [],
};
export const IQuestionSetAddDefault = {
  name: '',
  questionAreaIds: [0],
  questionIds: [0],
};
