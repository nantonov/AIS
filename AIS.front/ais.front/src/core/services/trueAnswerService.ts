import defaultTrueAnswer from '../common/defaultDTO/defaultTrueAnswer';
import { TrueAnswer } from '../interfaces/trueAnswer/trueAnswer';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

class TrueAnswerService {
  public static async getAll(): Promise<TrueAnswer[]> {
    const result = await axiosInstance
      .get<TrueAnswer[]>(Config.TRUE_ANSWER_URL)
      .then((res) => res.data);

    return result || [];
  }

  public static async getById(trueAnswerId: number): Promise<TrueAnswer> {
    const result = await axiosInstance
      .get<TrueAnswer>(`${Config.TRUE_ANSWER_URL}/${trueAnswerId}`)
      .then((res) => res.data);

    return result || defaultTrueAnswer;
  }

  public static deleteById(trueAnswerId: number): Promise<any> {
    return axiosInstance.delete(`${Config.TRUE_ANSWER_URL}/${trueAnswerId}`);
  }

  public static create(trueAnswer: TrueAnswer): Promise<any> {
    return axiosInstance.post(Config.TRUE_ANSWER_URL, { ...trueAnswer });
  }

  public static update(trueAnswer: TrueAnswer): Promise<boolean> {
    return axiosInstance.put(
      Config.TRUE_ANSWER_URL,
      { ...trueAnswer },
      { params: { id: trueAnswer.id } }
    );
  }
}

export default TrueAnswerService;
