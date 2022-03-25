import { Employee } from "./employee";
import { Interviewee } from "./interviewee";

export interface Company{
    id: number,
    name: string,
    employees: Employee | null,
    interviewees: Interviewee | null
}
