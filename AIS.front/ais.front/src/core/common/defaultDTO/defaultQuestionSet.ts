import { IQuestionSet } from "../../DTO/IQuestionSet";

export const defaultQuestionSet: IQuestionSet = {
    id: 0,
    name: "",
    questionAreaId: 0,
    questionAreas: null,
    questions: []
}
export const IQuestionSetAddDefault = {
    name: "",
    questionAreaIds: [0],
    questionIds: [0]
};
