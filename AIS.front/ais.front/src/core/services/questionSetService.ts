import { defaultQuestionSet } from '../common/defaultDTO/defaultQuestionSet';
import { QuestionSet, QuestionSetAddState } from '../interfaces/questionSet/questionSet';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

class QuestionSetService {
  public static async getAll(): Promise<QuestionSet[]> {
    const result = await axiosInstance
      .get<QuestionSet[]>(Config.QUESTION_SET_URL)
      .then((res) => res.data);

    return result || [];
  }

  public static async getById(questionSetId: number): Promise<QuestionSet> {
    const result = await axiosInstance
      .get<QuestionSet>(`${Config.QUESTION_SET_URL}/${questionSetId}`)
      .then((res) => res.data);

    return result || defaultQuestionSet;
  }

  public static deleteById(questionSetId: number): Promise<any> {
    return axiosInstance.delete(`${Config.QUESTION_SET_URL}/${questionSetId}`);
  }

  public static create(questionSet: QuestionSet): Promise<any> {
    return axiosInstance.post(Config.QUESTION_SET_URL, { ...questionSet });
  }

  public static update(questionSet: QuestionSet): Promise<boolean> {
    return axiosInstance.put(
      Config.QUESTION_SET_URL,
      { ...questionSet },
      { params: { id: questionSet.id } }
    );
  }

  public static addQuestionSet(questionSetAdd: QuestionSetAddState): Promise<any> {
    return axiosInstance.post(
      Config.QUESTION_SET_URL,
      { ...questionSetAdd },
      { params: { questionSetAdd } }
    );
  }
}

export default QuestionSetService;
