import { ISession } from "../../DTO/ISession";

export const defaultSession: ISession = {
    id: 0,
    startedAt: "",
    companyId: 0,
    company: null,
    employeeId: 0,
    employee: null,
    intervieweeId: 0,
    interviewee: null,
    finishedAt: "",
    questionAreaId: "",
    questionArea: null,
    questionIntervieweeAnswers: null
}