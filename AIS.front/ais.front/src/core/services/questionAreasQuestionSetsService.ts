import axiosInstance from '../../config/getAxious';
import Config from '../../config/config';

export const deleteByTwoIdsAreaSet = (
  questionAreaId: number,
  questionSetId: number
): Promise<any> =>
  axiosInstance.delete(
    `${Config.DELETE_BY_TWO_IDS_QUESTION_AREA}?questionAreaId=${questionAreaId}&questionSetId=${questionSetId}`
  );
