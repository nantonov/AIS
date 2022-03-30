import { ShortQuestion } from '../question/shortQuestion';

export interface TrueAnswer {
  id: number;
  text: string;
  questionId: number;
  question: ShortQuestion | null;
}
