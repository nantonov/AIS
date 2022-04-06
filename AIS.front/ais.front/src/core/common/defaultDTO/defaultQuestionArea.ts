import { QuestionArea, QuestionAreaAdd } from '../../interfaces/questionArea/questionArea';

const defaultQuestionArea: QuestionArea = {
  id: 0,
  name: '',
  questionSets: [],
};

export const defaultQuestionAreaAdd: QuestionAreaAdd = {
  name: '',
  questionSetsIds: [],
};

export default defaultQuestionArea;
