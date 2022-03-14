import axiosInstance from "../utils/getAxious";
import {Config} from "../config";

export class QuestionAreasQuestionSetsService {
    public static deleteByTwoIds(questionAreaId: number, questionSetId: number): Promise<any> {
        return axiosInstance.delete(
            Config.DELETE_BY_TWO_IDS_QUESTION_AREA + `?questionAreaId=${questionAreaId}` + `&questionSetId=${questionSetId}`);
    }
}
