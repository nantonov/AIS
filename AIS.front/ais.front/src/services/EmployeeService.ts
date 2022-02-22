import { defaultEmployee } from "../common/defaultDTO/defaultEmployee";
import { IEmployee } from "../DTO/IEmployee";
import axiosInstance from "../utils/getAxious";


export class EmployeeService {
    static path:string = 'api/Employee';
    public static async getAll(): Promise<IEmployee[]> {
        const result = await axiosInstance.get<IEmployee[]>(this.path)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));
        return result || [];
    }

    public static async getById(companyId: number): Promise<IEmployee> {
        const result = await axiosInstance.get<IEmployee>(
            this.path+`/${companyId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultEmployee;
    }

    public static deleteById(companyId: number): Promise<any> {
        return axiosInstance.delete(
            this.path+`/${companyId}`);
    }

    public static create(company: IEmployee): Promise<any> {
        return axiosInstance.post(
            this.path, { ...company });
    }

    public static update(company: IEmployee): Promise<boolean> {
        return axiosInstance.put(
            this.path, { ...company }, { params: { id: company.id } });
    }
}