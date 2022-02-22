import { defaultCompany } from "../common/defaultDTO/defaultCompany";
import { Config } from "../config";
import { ICompany } from "../DTO/ICompany";
import axiosInstance from "../utils/getAxious";


export class CompanyService {
    public static async getAll(): Promise<ICompany[]> {
        const result = await axiosInstance.get<ICompany[]>(Config.COMPANY_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(companyId: number): Promise<ICompany> {
        const result = await axiosInstance.get<ICompany>(
            Config.COMPANY_URL+`/${companyId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultCompany;
    }

    public static deleteById(companyId: number): Promise<any> {
        return axiosInstance.delete(
            Config.COMPANY_URL+`/${companyId}`);
    }

    public static create(company: ICompany): Promise<any> {
        return axiosInstance.post(
            Config.COMPANY_URL, { ...company });
    }

    public static update(company: ICompany): Promise<boolean> {
        return axiosInstance.put(
            Config.COMPANY_URL, { ...company }, { params: { id: company.id } });
    }
}