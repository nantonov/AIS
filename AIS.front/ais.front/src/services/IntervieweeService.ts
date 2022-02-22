import { defaultInterviewee } from "../common/defaultDTO/defaultInterviewee";
import { IInterviewee } from "../DTO/IInterviewee";
import axiosInstance from "../utils/getAxious";


export class IntervieweeService {
    static path:string = 'api/Interviewee';
    public static async getAll(): Promise<IInterviewee[]> {
        const result = await axiosInstance.get<IInterviewee[]>(this.path)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(intervieweeId: number): Promise<IInterviewee> {
        const result = await axiosInstance.get<IInterviewee>(
            this.path+`/${intervieweeId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultInterviewee;
    }

    public static deleteById(intervieweeId: number): Promise<any> {
        return axiosInstance.delete(
            this.path+`/${intervieweeId}`);
    }

    public static create(interviewee: IInterviewee): Promise<any> {
        return axiosInstance.post(
            this.path , { ...interviewee });
    }

    public static update(interviewee: IInterviewee): Promise<boolean> {
        return axiosInstance.put(
            this.path, { ...interviewee }, { params: { id: interviewee.id } });
    }
}