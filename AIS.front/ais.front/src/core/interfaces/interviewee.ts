import { Company } from "./company";

export interface Interviewee{
    id: number,
    name: string,
    appliesFor: string,
    companyId: number,
    company: Company | null
}
