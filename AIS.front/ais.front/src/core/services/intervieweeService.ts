import defaultInterviewee from '../common/defaultDTO/defaultInterviewee';
import { Interviewee } from '../interfaces/interviewee/interviewee';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

export const getAllIntervieweesService = async (): Promise<Interviewee[]> => {
  const result = await axiosInstance
    .get<Interviewee[]>(Config.INTERVIEWEE_URL)
    .then((res) => res.data);

  return result || [];
};

export const getIntervieweeByIdService = async (intervieweeId: number): Promise<Interviewee> => {
  const result = await axiosInstance
    .get<Interviewee>(`${Config.INTERVIEWEE_URL}/${intervieweeId}`)
    .then((res) => res.data);

  return result || defaultInterviewee;
};

export const deleteIntervieweeService = (intervieweeId: number): Promise<any> =>
  axiosInstance.delete(`${Config.INTERVIEWEE_URL}/${intervieweeId}`);

export const createIntervieweeService = (interviewee: Interviewee): Promise<any> =>
  axiosInstance.post(Config.INTERVIEWEE_URL, { ...interviewee });

export const updateIntervieweeService = (interviewee: Interviewee): Promise<boolean> =>
  axiosInstance.put(Config.INTERVIEWEE_URL, { ...interviewee }, { params: { id: interviewee.id } });
