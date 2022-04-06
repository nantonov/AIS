import { ShortQuestion } from '../question/shortQuestion';
import { ShortQuestionArea } from '../questionArea/shortQuestionArea';

export interface QuestionSet {
  id: number;
  name: string;
  questionAreaId: number;
  questionAreas: ShortQuestionArea[] | null;
  questions: ShortQuestion[];
}
export interface QuestionSetAddState {
  name: string;
  questionAreaIds: number[];
  questionIds: number[];
}
