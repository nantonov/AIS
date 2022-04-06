import { ShortCompany } from '../company/shortCompany';

export interface Interviewee {
  id: number;
  name: string;
  appliesFor: string;
  companyId: number;
  company: ShortCompany | null;
}
