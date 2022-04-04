import defaultQuestionArea from '../common/defaultDTO/defaultQuestionArea';
import { QuestionArea } from '../interfaces/questionArea/questionArea';
import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

class QuestionAreaService {
  public static async getAll(): Promise<QuestionArea[]> {
    const result = await axiosInstance
      .get<QuestionArea[]>(Config.QUESTION_AREA_URL)
      .then((res) => res.data);

    return result || [];
  }

  public static async getById(questionAreaId: number): Promise<QuestionArea> {
    const result = await axiosInstance
      .get<QuestionArea>(`${Config.QUESTION_AREA_URL}/${questionAreaId}`)
      .then((res) => res.data);

    return result || defaultQuestionArea;
  }

  public static deleteById(questionAreaId: number): Promise<any> {
    return axiosInstance.delete(`${Config.QUESTION_AREA_URL}/${questionAreaId}`);
  }

  public static create(questionArea: QuestionArea): Promise<any> {
    return axiosInstance.post(Config.QUESTION_AREA_URL, { ...questionArea });
  }

  public static update(questionArea: QuestionArea): Promise<boolean> {
    return axiosInstance.put(
      Config.QUESTION_AREA_URL,
      { ...questionArea },
      { params: { id: questionArea.id } }
    );
  }
}

export default QuestionAreaService;
