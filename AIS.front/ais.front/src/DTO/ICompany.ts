import { IEmployee } from "./IEmployee";
import { IInterviewee } from "./IInterviewee";

export interface ICompany{
    id: number,
    name: string,
    employees: IEmployee | null,
    interviewees: IInterviewee | null
}