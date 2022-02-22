import { ICompany } from "./ICompany";

export interface IInterviewee{
    id: number,
    name: string,
    appliesFor: string,
    companyId: number,
    company: ICompany | null
}