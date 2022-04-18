import React from 'react';
import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { QuestionForm } from './QuestionForm';
import { Question } from '../../../core/interfaces/question/question';

interface Props {
  item: Question;
}

export const QuestionComponent: React.FC<Props> = ({ item }) => (
  <Accordion sx={{ width: '75%' }}>
    <AccordionSummary
      expandIcon={<ExpandMoreIcon />}
      aria-controls="panel1a-content"
      id="panel1a-header"
    >
      <Typography>{item.text}</Typography>
    </AccordionSummary>

    <AccordionDetails>
      <QuestionForm item={item} />
    </AccordionDetails>
  </Accordion>
);
