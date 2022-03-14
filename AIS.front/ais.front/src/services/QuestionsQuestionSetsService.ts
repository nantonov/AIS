import axiosInstance from "../utils/getAxious";
import {Config} from "../config";

export class QuestionsQuestionSetsService {
    public static deleteByTwoIds(questionSetId: number, questionId: number): Promise<any> {
        return axiosInstance.delete(
            Config.DELETE_BY_TWO_IDS_QUESTION + `?questionSetId=${questionSetId}` + `&questionId=${questionId}`);
    }
}
