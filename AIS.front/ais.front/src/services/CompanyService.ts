import { defaultCompany } from "../common/defaultDTO/defaultCompany";
import { ICompany } from "../DTO/ICompany";
import axiosInstance from "../utils/getAxious";
import {COMPANY_URL} from "../static/UrlConstants";


export class CompanyService {
    public static async getAll(): Promise<ICompany[]> {
        const result = await axiosInstance.get<ICompany[]>(COMPANY_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(companyId: number): Promise<ICompany> {
        const result = await axiosInstance.get<ICompany>(
            COMPANY_URL+`/${companyId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultCompany;
    }

    public static deleteById(companyId: number): Promise<any> {
        return axiosInstance.delete(
            COMPANY_URL+`/${companyId}`);
    }

    public static create(company: ICompany): Promise<any> {
        return axiosInstance.post(
            COMPANY_URL, { ...company });
    }

    public static update(company: ICompany): Promise<boolean> {
        return axiosInstance.put(
            COMPANY_URL, { ...company }, { params: { id: company.id } });
    }
}
