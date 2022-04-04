import { Session } from '../../interfaces/session/session';

const defaultSession: Session = {
  id: 0,
  startedAt: '',
  companyId: 0,
  company: null,
  employeeId: 0,
  employee: null,
  intervieweeId: 0,
  interviewee: null,
  finishedAt: '',
  questionAreaId: '',
  questionArea: null,
  questionIntervieweeAnswers: null,
};

export default defaultSession;
