import { defaultEmployee } from "../common/defaultDTO/defaultEmployee";
import { IEmployee } from "../DTO/IEmployee";
import axiosInstance from "../utils/getAxious";
import {EMPLOYEE_URL} from "../static/UrlConstants";
import {Config} from "../config";


export class EmployeeService {
    public static async getAll(): Promise<IEmployee[]> {
        const result = await axiosInstance.get<IEmployee[]>(Config.EMPLOYEE_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));
        return result || [];
    }

    public static async getById(companyId: number): Promise<IEmployee> {
        const result = await axiosInstance.get<IEmployee>(
            Config.EMPLOYEE_URL+`/${companyId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultEmployee;
    }

    public static deleteById(companyId: number): Promise<any> {
        return axiosInstance.delete(
            Config.EMPLOYEE_URL+`/${companyId}`);
    }

    public static create(company: IEmployee): Promise<any> {
        return axiosInstance.post(
            Config.EMPLOYEE_URL, { ...company });
    }

    public static update(company: IEmployee): Promise<boolean> {
        return axiosInstance.put(
            Config.EMPLOYEE_URL, { ...company }, { params: { id: company.id } });
    }
}
