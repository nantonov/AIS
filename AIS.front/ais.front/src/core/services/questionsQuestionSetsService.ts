import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

export const deleteByTwoIdsSetQuestion = (
  questionSetId: number,
  questionId: number
): Promise<any> =>
  axiosInstance.delete(
    `${Config.DELETE_BY_TWO_IDS_QUESTION}?questionSetId=${questionSetId}&questionId=${questionId}`
  );
