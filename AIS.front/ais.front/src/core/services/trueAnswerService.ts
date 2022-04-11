import defaultTrueAnswer from '../common/defaultDTO/defaultTrueAnswer';
import { TrueAnswer } from '../interfaces/trueAnswer/trueAnswer';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

export const getAllTrueAnswersService = async (): Promise<TrueAnswer[]> => {
  const result = await axiosInstance
    .get<TrueAnswer[]>(Config.TRUE_ANSWER_URL)
    .then((res) => res.data);

  return result || [];
};

export const getTrueAnswerByIdService = async (trueAnswerId: number): Promise<TrueAnswer> => {
  const result = await axiosInstance
    .get<TrueAnswer>(`${Config.TRUE_ANSWER_URL}/${trueAnswerId}`)
    .then((res) => res.data);

  return result || defaultTrueAnswer;
};

export const deleteTrueAnswerService = (trueAnswerId: number): Promise<any> =>
  axiosInstance.delete(`${Config.TRUE_ANSWER_URL}/${trueAnswerId}`);

export const createTrueAnswerService = (trueAnswer: TrueAnswer): Promise<any> =>
  axiosInstance.post(Config.TRUE_ANSWER_URL, { ...trueAnswer });

export const updateTrueAnswerService = (trueAnswer: TrueAnswer): Promise<boolean> =>
  axiosInstance.put(Config.TRUE_ANSWER_URL, { ...trueAnswer }, { params: { id: trueAnswer.id } });
