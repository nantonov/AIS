import { Company } from "./company";
import { Employee } from "./employee";
import { Interviewee } from "./interviewee";
import { QuestionArea } from "./questionArea";
import { QuestionIntervieweeAnswer } from "./questionIntervieweeAnswer";

export interface Session{
    id: number,
    startedAt: string,
    companyId: number,
    company: Company | null,
    employeeId: number,
    employee: Employee | null,
    intervieweeId: number,
    interviewee:Interviewee | null,
    finishedAt: string,
    questionAreaId: string,
    questionArea: QuestionArea | null,
    questionIntervieweeAnswers: QuestionIntervieweeAnswer | null
}
