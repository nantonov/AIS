import { ShortCompany } from '../company/shortCompany';
import { ShortEmployee } from '../employee/shortEmployee';
import { ShortInterviewee } from '../interviewee/shortInterviewee';
import { ShortQuestionArea } from '../questionArea/shortQuestionArea';
import { ShortQuestionIntervieweeAnswer } from '../questionIntervieweeAnswer/shortQuestionIntervieweeAnswer';

export interface Session {
  id: number;
  startedAt: string;
  companyId: number;
  company: ShortCompany | null;
  employeeId: number;
  employee: ShortEmployee | null;
  intervieweeId: number;
  interviewee: ShortInterviewee | null;
  finishedAt: string;
  questionAreaId: string;
  questionArea: ShortQuestionArea | null;
  questionIntervieweeAnswers: ShortQuestionIntervieweeAnswer | null;
}
