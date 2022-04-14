import React, { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import Typography from '@mui/material/Typography';
import { Button, TextField } from '@mui/material';
import styled from 'styled-components';
import { Question } from '../../../core/interfaces/question/question';
import { TrueAnswer } from '../../../core/interfaces/trueAnswer/trueAnswer';
import defaultTrueAnswer from '../../../core/common/defaultDTO/defaultTrueAnswer';
import { deleteQuestionById, putQuestion } from '../../../core/redux/thunk/questionThunk';
import { putTrueAnswer } from '../../../core/redux/thunk/trueAnswerThunk';

interface Props {
  item: Question;
}

const ButtonsContainer = styled.div`
  margin-top: 1em;
  display: flex;
  flex-direction: row;
  justify-content: space-around;
`;

export const QuestionForm: React.FC<Props> = ({ item }) => {
  const [question, setQuestion] = useState<Question>(item);
  const [trueAnswer, setTrueAnswer] = useState<TrueAnswer>(defaultTrueAnswer);
  const dispatch = useDispatch();

  useEffect(() => {
    if (item.trueAnswer) {
      setTrueAnswer((prev: TrueAnswer) => ({
        ...prev,
        questionId: item.id,
        id: item.trueAnswer!.id,
        text: item.trueAnswer!.text,
      }));
    }
  }, []);

  const saveAction = () => {
    dispatch(putQuestion(question));
    dispatch(putTrueAnswer(trueAnswer));
  };

  const handlerClickDelete = () => {
    dispatch(deleteQuestionById(question.id));
  };

  return (
    <div>
      <Typography> Update Question</Typography>
      <TextField
        fullWidth
        type="text"
        value={question.text}
        onChange={(event) => {
          setQuestion((prev: Question) => ({ ...prev, text: event.target.value }));
        }}
      />

      <Typography pt={2}> True Answer</Typography>
      <TextField
        fullWidth
        type="text"
        value={trueAnswer.text}
        onChange={(event) => {
          setTrueAnswer((prev: TrueAnswer) => ({ ...prev, text: event.target.value }));
        }}
      />

      <ButtonsContainer>
        <Button variant="contained" onClick={saveAction}>
          {' '}
          Confirm
        </Button>
        <Button variant="contained" onClick={handlerClickDelete}>
          Delete
        </Button>
      </ButtonsContainer>
    </div>
  );
};
