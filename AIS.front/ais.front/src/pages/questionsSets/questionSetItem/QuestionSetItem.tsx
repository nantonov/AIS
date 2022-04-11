import React from 'react';
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { QuestionSet } from '../../../core/interfaces/questionSet/questionSet';
import QuestionSetContainer from '../../../core/components/itemContainer/ItemContainer';
import { QuestionSetDescriptionDiv, QuestionSetHeader, QuestionSetNameText } from './styled/style';
import MainRoutes from '../../../core/constants/mainRoutes';
import { DeleteIconButtonContainer } from '../../../core/components/deleteIconButtonContainer/DeleteIconButtonContainer';
import { IconButtonContainer } from '../../../core/components/iconButtonContainer/IconButtonContainer';
import { deleteQuestionSetById } from '../../../core/redux/thunk/questionSetThunk';

interface Props {
  questionSet: QuestionSet;
}

const QuestionSetItem: React.FC<Props> = ({ questionSet }) => {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const routeChange = (id: number) => () => {
    const path = `/${MainRoutes.questionSet}/${id}`;
    navigate(path);
  };

  const DeleteQuestionSetById = (questionSetId: number) => () => {
    dispatch(deleteQuestionSetById(questionSetId));
  };

  return (
    <QuestionSetContainer onClick={routeChange(questionSet.id)}>
      <QuestionSetHeader>{questionSet.name}</QuestionSetHeader>
      <QuestionSetDescriptionDiv>
        <QuestionSetNameText>{questionSet.name}</QuestionSetNameText>
        <IconButtonContainer aria-label="delete">
          <DeleteIconButtonContainer onClick={DeleteQuestionSetById(questionSet.id)} />
        </IconButtonContainer>
      </QuestionSetDescriptionDiv>
    </QuestionSetContainer>
  );
};

export default QuestionSetItem;
