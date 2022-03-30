import defaultEmployee from '../common/defaultDTO/defaultEmployee';
import { Employee } from '../interfaces/employee/employee';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

class EmployeeService {
  public static async getAll(): Promise<Employee[]> {
    const result = await axiosInstance
      .get<Employee[]>(Config.EMPLOYEE_URL)
      .then((res) => res.data);

    return result || [];
  }

  public static async getById(companyId: number): Promise<Employee> {
    const result = await axiosInstance
      .get<Employee>(`${Config.EMPLOYEE_URL}/${companyId}`)
      .then((res) => res.data);

    return result || defaultEmployee;
  }

  public static deleteById(companyId: number): Promise<any> {
    return axiosInstance.delete(`${Config.EMPLOYEE_URL}/${companyId}`);
  }

  public static create(company: Employee): Promise<any> {
    return axiosInstance.post(Config.EMPLOYEE_URL, { ...company });
  }

  public static update(company: Employee): Promise<boolean> {
    return axiosInstance.put(
      Config.EMPLOYEE_URL,
      { ...company },
      { params: { id: company.id } }
    );
  }
}

export default EmployeeService;
