import React from 'react';
import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { QuestionForm } from './QuestionForm';
import { Question } from '../../../core/interfaces/question/question';
import { TrueAnswer } from '../../../core/interfaces/trueAnswer/trueAnswer';

interface Props {
  item: Question;
  deleteQuestion: (id: number) => void;
  updateQuestion: (question: Question) => void;
  updateTrueAnswer: (trueAnswer: TrueAnswer) => void;
}

export const QuestionComponent: React.FC<Props> = ({
  item,
  deleteQuestion,
  updateQuestion,
  updateTrueAnswer,
}) => (
  <Accordion sx={{ width: '75%' }}>
    <AccordionSummary
      expandIcon={<ExpandMoreIcon />}
      aria-controls="panel1a-content"
      id="panel1a-header"
    >
      <Typography>{item.text}</Typography>
    </AccordionSummary>

    <AccordionDetails>
      <QuestionForm
        item={item}
        deleteQuestion={deleteQuestion}
        updateQuestion={updateQuestion}
        updateTrueAnswer={updateTrueAnswer}
      />
    </AccordionDetails>
  </Accordion>
);
