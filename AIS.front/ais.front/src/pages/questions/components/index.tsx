import React from 'react';
import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { Question } from '../../../core/interfaces/question';
import {  QuestionForm } from './QuestionForm';
import { TrueAnswer } from '../../../core/interfaces/trueAnswer';

interface propsFromComponent {
    item: Question;
    deleteQuestion: (id :number) => void,
    updateQuestion:(question :Question) =>void
    updateTrueAnswer:(trueAnswer :TrueAnswer) =>void
}
interface propsFromDispatch { 
}

type Props = propsFromComponent & propsFromDispatch;

export const QuestionComponent: React.FC<Props> = ({item,deleteQuestion,updateQuestion,updateTrueAnswer}) => {

    return (
        <Accordion sx={{ width: '75%' }} >     
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel1a-content"
            id="panel1a-header">
          <Typography>{item.text}</Typography>
          </AccordionSummary>
  
          <AccordionDetails>
            <QuestionForm item={item} deleteQuestion={deleteQuestion} updateQuestion={updateQuestion} updateTrueAnswer={updateTrueAnswer}></QuestionForm>
          </AccordionDetails>
  
        </Accordion>
    )
}


