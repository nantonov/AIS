import { ICompany } from "./ICompany";
import { IEmployee } from "./IEmployee";
import { IInterviewee } from "./IInterviewee";
import { IQuestionArea } from "./IQuestionArea";
import { IQuestionIntervieweeAnswer } from "./IQuestionIntervieweeAnswer";

export interface ISession{
    id: number,
    startedAt: string,
    companyId: number,
    company: ICompany | null,
    employeeId: number,
    employee: IEmployee | null,
    intervieweeId: number,
    interviewee:IInterviewee | null,
    finishedAt: string,
    questionAreaId: string,
    questionArea: IQuestionArea | null,
    questionIntervieweeAnswers: IQuestionIntervieweeAnswer | null
}