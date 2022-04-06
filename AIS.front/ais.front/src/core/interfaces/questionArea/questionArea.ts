import { ShortQuestionSet } from '../questionSet/shortQuestionSet';

export interface QuestionArea {
  id: number;
  name: string;
  questionSets: ShortQuestionSet[];
}

export interface QuestionAreaAdd {
  name: string;
  questionSetsIds: number[];
}
