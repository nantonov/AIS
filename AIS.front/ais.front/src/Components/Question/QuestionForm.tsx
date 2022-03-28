import React, { useState } from 'react';
//import './style.css';
import Typography from '@mui/material/Typography';
import { IQuestion } from '../../DTO/IQuestion';
import {Button, TextField} from "@mui/material";
import { Field, InjectedFormProps, reduxForm } from 'redux-form';
import ReduxFormInput from './ReduxFormInput';
import { InputField } from './Input';
import { Save } from '@material-ui/icons';
import { ITrueAnswer } from '../../DTO/ITrueAnswer';
import { defaultTrueAnswer } from '../../common/defaultDTO/defaultTrueAnswer';
import styled from "styled-components";

interface propsFromComponent {
    item: IQuestion;
    deleteQuestion: (id :number) => void,
    updateQuestion:(question :IQuestion) =>void
}
interface propsFromDispatch { 
}

type Props = propsFromComponent & propsFromDispatch;

export const QuestionForm: React.FC<Props> = ({item,deleteQuestion,updateQuestion}) => {
  const [question, setQuestion] = useState<IQuestion>(item);
  const [trueAnswer, setTrueAnswer] = useState<ITrueAnswer>(item.trueAnswer || defaultTrueAnswer);

  const ButtonsContainer = styled.div`
      margin-top: 1em;
      display: flex;
      flex-direction: row;
      justify-content: space-around;
    `;

  const saveAction = () => {
    updateQuestion(question);
    //alert('Question: '+question.text+" Answer: "+trueAnswer.text);
    // const action = isEdit ? UserProjectService.update : UserProjectService.create;
    // action(projectInfo)
    //   .then(() => {
    //     setToastMessage({ text: `Проект ${isEdit ? 'изменен' : 'добавлен'}`, severity: 'success', visible: true });
    //     history.push('/myProject');
    //   })
    //   .catch(({ response }) => {
    //     setErrorInfo(response.data);
    //   });
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
                  setQuestion((prev: IQuestion) => ({ ...prev, text: event.target.value }))
                }}
              />
  
            <Typography pt={2}> True Answer</Typography>
            
            <TextField fullWidth
                type='text'
                value={trueAnswer.text}
                onChange={(event) => {
                  setTrueAnswer((prev: ITrueAnswer) => ({ ...prev, text: event.target.value }))
                }}
              />
            
            <ButtonsContainer>
              <Button variant="contained" onClick={saveAction}> Confirm</Button>
              <Button variant="contained" onClick={handlerClickDelete}>Delete</Button>
            </ButtonsContainer>
      </div>
    )
}
