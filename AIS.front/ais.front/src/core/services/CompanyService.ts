import { defaultCompany } from "../common/defaultDTO/defaultCompany";
import { Company } from "../interfaces/company";
import axiosInstance from "../../config/getAxious";
import {COMPANY_URL} from "../constants/UrlConstants";


export class CompanyService {
    public static async getAll(): Promise<Company[]> {
        const result = await axiosInstance.get<Company[]>(COMPANY_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(companyId: number): Promise<Company> {
        const result = await axiosInstance.get<Company>(
            COMPANY_URL+`/${companyId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultCompany;
    }

    public static deleteById(companyId: number): Promise<any> {
        return axiosInstance.delete(
            COMPANY_URL+`/${companyId}`);
    }

    public static create(company: Company): Promise<any> {
        return axiosInstance.post(
            COMPANY_URL, { ...company });
    }

    public static update(company: Company): Promise<boolean> {
        return axiosInstance.put(
            COMPANY_URL, { ...company }, { params: { id: company.id } });
    }
}
