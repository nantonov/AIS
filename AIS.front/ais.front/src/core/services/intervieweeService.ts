import defaultInterviewee from '../common/defaultDTO/defaultInterviewee';
import { Interviewee } from '../interfaces/interviewee/interviewee';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

class IntervieweeService {
  public static async getAll(): Promise<Interviewee[]> {
    const result = await axiosInstance
      .get<Interviewee[]>(Config.INTERVIEWEE_URL)
      .then((res) => res.data);

    return result || [];
  }

  public static async getById(intervieweeId: number): Promise<Interviewee> {
    const result = await axiosInstance
      .get<Interviewee>(`${Config.INTERVIEWEE_URL}/${intervieweeId}`)
      .then((res) => res.data);

    return result || defaultInterviewee;
  }

  public static deleteById(intervieweeId: number): Promise<any> {
    return axiosInstance.delete(`${Config.INTERVIEWEE_URL}/${intervieweeId}`);
  }

  public static create(interviewee: Interviewee): Promise<any> {
    return axiosInstance.post(Config.INTERVIEWEE_URL, { ...interviewee });
  }

  public static update(interviewee: Interviewee): Promise<boolean> {
    return axiosInstance.put(
      Config.INTERVIEWEE_URL,
      { ...interviewee },
      { params: { id: interviewee.id } }
    );
  }
}

export default IntervieweeService;
