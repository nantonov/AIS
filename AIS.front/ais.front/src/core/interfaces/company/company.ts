import { ShortEmployee } from '../employee/shortEmployee';

export interface Company {
  id: number;
  name: string;
  employees: ShortEmployee | null;
  interviewees: null;
}
