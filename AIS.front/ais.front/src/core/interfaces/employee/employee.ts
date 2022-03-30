import { ShortCompany } from '../company/shortCompany';

export interface Employee {
  id: number;
  name: string;
  companyId: number;
  company: ShortCompany | null;
}
