import { Company } from "./company";

export interface Employee {
    id: number,
    name: string,
    companyId: number,
    company: Company | null
}
