import defaultEmployee from '../common/defaultDTO/defaultEmployee';
import { Employee } from '../interfaces/employee/employee';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

export const getEmployeesAllService = async (): Promise<Employee[]> => {
  const result = await axiosInstance.get<Employee[]>(Config.EMPLOYEE_URL).then((res) => res.data);

  return result || [];
};

export const getEmployeeByIdService = async (
  companyId: number,
  accessToken: string
): Promise<Employee> => {
  const result = await axiosInstance
    .get<Employee>(`${Config.EMPLOYEE_URL}/${companyId}`, {
      headers: {
        Authorization: `Bearer ${accessToken}`,
      },
    })
    .then((res) => res.data);

  return result || defaultEmployee;
};

export const deleteEmployeeServcie = (companyId: number): Promise<any> =>
  axiosInstance.delete(`${Config.EMPLOYEE_URL}/${companyId}`);

export const createEmployeeService = (company: Employee): Promise<any> =>
  axiosInstance.post(Config.EMPLOYEE_URL, { ...company });

export const updateEmployeeService = (company: Employee): Promise<boolean> =>
  axiosInstance.put(Config.EMPLOYEE_URL, { ...company }, { params: { id: company.id } });
