import React, { useState } from 'react';
import Typography from '@mui/material/Typography';
import { Question } from '../../../core/interfaces/question';
import {Button, TextField} from "@mui/material";
import { TrueAnswer } from '../../../core/interfaces/trueAnswer';
import { defaultTrueAnswer } from '../../../core/common/defaultDTO/defaultTrueAnswer';
import styled from "styled-components";


interface propsFromComponent {
    item: Question;
    deleteQuestion: (id :number) => void,
    updateQuestion:(question :Question) =>void
    updateTrueAnswer:(trueAnswer :TrueAnswer) =>void
}
interface propsFromDispatch { 
}

type Props = propsFromComponent & propsFromDispatch;

const ButtonsContainer = styled.div`
      margin-top: 1em;
      display: flex;
      flex-direction: row;
      justify-content: space-around;
    `;

export const QuestionForm: React.FC<Props> = ({item,deleteQuestion,updateQuestion,updateTrueAnswer}) => {
  const [question, setQuestion] = useState<Question>(item);
  const [trueAnswer, setTrueAnswer] = useState<TrueAnswer>(item.trueAnswer || defaultTrueAnswer);

  const saveAction = () => {
    updateQuestion(question);
    updateTrueAnswer(trueAnswer);
  }

  const handlerClickDelete = () =>{
    deleteQuestion(question.id);
  }

    return (
      <div>
            <Typography> Update Question</Typography>
            <TextField fullWidth
                type='text'
                value={question.text}
                onChange={(event) => {
                  setQuestion((prev: Question) => ({ ...prev, text: event.target.value }))
                }}
              />
  
            <Typography pt={2}> True Answer</Typography>
            <TextField fullWidth
                type='text'
                value={trueAnswer.text}
                onChange={(event) => {
                  setTrueAnswer((prev: TrueAnswer) => ({ ...prev, text: event.target.value }))
                }}
              />
            
            <ButtonsContainer>
              <Button variant="contained" onClick={saveAction}> Confirm</Button>
              <Button variant="contained" onClick={handlerClickDelete}>Delete</Button>
            </ButtonsContainer>
      </div>
    )
}

