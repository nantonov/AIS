import defaultCompany from '../common/defaultDTO/defaultCompany';
import { Company } from '../interfaces/company/company';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

export const getAllCompaniesService = async (): Promise<Company[]> => {
  const result = await axiosInstance.get<Company[]>(Config.COMPANY_URL).then((res) => res.data);
  return result || [];
};

export const getCompanyByIdService = async (companyId: number): Promise<Company> => {
  const result = await axiosInstance
    .get<Company>(`${Config.COMPANY_URL}/${companyId}`)
    .then((res) => res.data);
  return result || defaultCompany;
};

export const deleteCompanyService = (companyId: number): Promise<any> =>
  axiosInstance.delete(`${Config.COMPANY_URL}/${companyId}`);

export const createCompanyService = (company: Company): Promise<any> =>
  axiosInstance.post(Config.COMPANY_URL, { ...company });
export const updateCompanyService = (company: Company): Promise<boolean> =>
  axiosInstance.put(Config.COMPANY_URL, { ...company }, { params: { id: company.id } });
