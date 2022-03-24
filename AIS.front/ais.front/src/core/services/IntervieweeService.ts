import { defaultInterviewee } from "../common/defaultDTO/defaultInterviewee";
import { Interviewee } from "../interfaces/interviewee";
import axiosInstance from "../../config/getAxious";
import {INTERVIEWEE_URL} from "../constants/UrlConstants";


export class IntervieweeService {
    public static async getAll(): Promise<Interviewee[]> {
        const result = await axiosInstance.get<Interviewee[]>(INTERVIEWEE_URL)
            .then((result) => result.data)
            .catch(({ response }) => console.log(response.data));

        return result || [];
    }

    public static async getById(intervieweeId: number): Promise<Interviewee> {
        const result = await axiosInstance.get<Interviewee>(
            INTERVIEWEE_URL+`/${intervieweeId}`)
            .then((result) => result.data)
            .catch((err) => console.log(err));

        return result || defaultInterviewee;
    }

    public static deleteById(intervieweeId: number): Promise<any> {
        return axiosInstance.delete(
            INTERVIEWEE_URL+`/${intervieweeId}`);
    }

    public static create(interviewee: Interviewee): Promise<any> {
        return axiosInstance.post(
            INTERVIEWEE_URL , { ...interviewee });
    }

    public static update(interviewee: Interviewee): Promise<boolean> {
        return axiosInstance.put(
            INTERVIEWEE_URL, { ...interviewee }, { params: { id: interviewee.id } });
    }
}
