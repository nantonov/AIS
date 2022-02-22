import { ICompany } from "./ICompany";

export interface IEmployee{
    id: number,
    name: string,
    companyId: number,
    company: ICompany | null
}