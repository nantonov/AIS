import { ShortQuestion } from '../question/shortQuestion';
import { ShortSession } from '../session/shortSession';

export interface QuestionIntervieweeAnswer {
  id: number;
  text: string;
  mark: number;
  sessionId: number;
  session: ShortSession | null;
  questionId: number;
  question: ShortQuestion | null;
}
