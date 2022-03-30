import defaultQuestion from '../common/defaultDTO/defaultQuestion';
import { Question } from '../interfaces/question/question';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

class QuestionService {
  public static async getAll(): Promise<Question[]> {
    const result = await axiosInstance.get<Question[]>(Config.QUESTION_URL).then((res) => res.data);

    return result || [];
  }

  public static async getById(questionId: number): Promise<Question> {
    const result = await axiosInstance
      .get<Question>(`${Config.QUESTION_URL}/${questionId}`)
      .then((res) => res.data);

    return result || defaultQuestion;
  }

  public static deleteById(questionId: number): Promise<any> {
    return axiosInstance.delete(`${Config.QUESTION_URL}/${questionId}`);
  }

  public static create(question: Question): Promise<any> {
    return axiosInstance.post(Config.QUESTION_URL, { ...question });
  }

  public static update(question: Question): Promise<boolean> {
    return axiosInstance.put(Config.QUESTION_URL, { ...question }, { params: { id: question.id } });
  }
}

export default QuestionService;
