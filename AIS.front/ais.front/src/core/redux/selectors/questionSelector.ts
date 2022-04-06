import { InitQuestionState } from '../reducer/questionReducer';
import { RootState } from '../reducer/rootReducer';

const questionSelector = (state: RootState): InitQuestionState => state.question;

export default questionSelector;
