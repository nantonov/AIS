import axiosInstance from "../../config/getAxious";
import {Config} from "../../config/config";

export class QuestionsQuestionSetsService {
    public static deleteByTwoIds(questionSetId: number, questionId: number): Promise<any> {
        return axiosInstance.delete(
            Config.DELETE_BY_TWO_IDS_QUESTION + `?questionSetId=${questionSetId}` + `&questionId=${questionId}`);
    }
}
