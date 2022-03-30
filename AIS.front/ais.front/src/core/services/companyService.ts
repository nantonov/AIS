import defaultCompany from '../common/defaultDTO/defaultCompany';
import { Company } from '../interfaces/company/company';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

class CompanyService {
  public static async getAll(): Promise<Company[]> {
    const result = await axiosInstance
      .get<Company[]>(Config.COMPANY_URL)
      .then((res) => res.data);

    return result || [];
  }

  public static async getById(companyId: number): Promise<Company> {
    const result = await axiosInstance
      .get<Company>(`${Config.COMPANY_URL}/${companyId}`)
      .then((res) => res.data);

    return result || defaultCompany;
  }

  public static deleteById(companyId: number): Promise<any> {
    return axiosInstance.delete(`${Config.COMPANY_URL}/${companyId}`);
  }

  public static create(company: Company): Promise<any> {
    return axiosInstance.post(Config.COMPANY_URL, { ...company });
  }

  public static update(company: Company): Promise<boolean> {
    return axiosInstance.put(
      Config.COMPANY_URL,
      { ...company },
      { params: { id: company.id } }
    );
  }
}

export default CompanyService;
