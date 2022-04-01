import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

class QuestionAreasQuestionSetsService {
  public static deleteByTwoIds(questionAreaId: number, questionSetId: number): Promise<any> {
    return axiosInstance.delete(
      `${Config.DELETE_BY_TWO_IDS_QUESTION_AREA}?questionAreaId=${questionAreaId}&questionSetId=${questionSetId}`
    );
  }
}

export default QuestionAreasQuestionSetsService;
