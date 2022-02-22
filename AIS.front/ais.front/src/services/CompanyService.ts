import { defaultCompany } from "../common/defaultDTO/defaultCompany";
import { ICompany } from "../DTO/ICompany";
import axiosInstance from "../utils/getAxious";


export class CompanyService {
    static path:string = 'api/Company';
    public static async getAll(): Promise<ICompany[]> {
        const result = await axiosInstance.get<ICompany[]>(this.path)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(companyId: number): Promise<ICompany> {
        const result = await axiosInstance.get<ICompany>(
            this.path+`/${companyId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultCompany;
    }

    public static deleteById(companyId: number): Promise<any> {
        return axiosInstance.delete(
            this.path+`/${companyId}`);
    }

    public static create(company: ICompany): Promise<any> {
        return axiosInstance.post(
            this.path, { ...company });
    }

    public static update(company: ICompany): Promise<boolean> {
        return axiosInstance.put(
            this.path, { ...company }, { params: { id: company.id } });
    }
}