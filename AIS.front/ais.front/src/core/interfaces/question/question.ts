import { ShortQuestionSet } from '../questionSet/shortQuestionSet';
import { ShortTrueAnswer } from '../trueAnswer/shortTrueAnswer';

export interface Question {
  id: number;
  text: string;
  questionSetid: number;
  questionSet: ShortQuestionSet | null;
  trueAnswer: ShortTrueAnswer | null;
}
