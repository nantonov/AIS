import { defaultInterviewee } from "../common/defaultDTO/defaultInterviewee";
import { Config } from "../config";
import { IInterviewee } from "../DTO/IInterviewee";
import axiosInstance from "../utils/getAxious";


export class IntervieweeService {
    public static async getAll(): Promise<IInterviewee[]> {
        const result = await axiosInstance.get<IInterviewee[]>(Config.INTERVIEWEE_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(intervieweeId: number): Promise<IInterviewee> {
        const result = await axiosInstance.get<IInterviewee>(
            Config.INTERVIEWEE_URL+`/${intervieweeId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultInterviewee;
    }

    public static deleteById(intervieweeId: number): Promise<any> {
        return axiosInstance.delete(
            Config.INTERVIEWEE_URL+`/${intervieweeId}`);
    }

    public static create(interviewee: IInterviewee): Promise<any> {
        return axiosInstance.post(
            Config.INTERVIEWEE_URL , { ...interviewee });
    }

    public static update(interviewee: IInterviewee): Promise<boolean> {
        return axiosInstance.put(
            Config.INTERVIEWEE_URL, { ...interviewee }, { params: { id: interviewee.id } });
    }
}