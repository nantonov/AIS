import React from 'react';
import {bindActionCreators, Dispatch} from 'redux';
import {ApplicationState} from "../../store/typing";
import {connect} from "react-redux";
//import './style.css';
import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { IQuestion } from '../../DTO/IQuestion';
import { questionActionCreators } from '../../store/Questions';
import {  QuestionForm } from './QuestionForm';

interface propsFromComponent {
    item: IQuestion;
}
interface propsFromDispatch { 
}

///type Props = propsFromComponent & propsFromDispatch;

export const Question: React.FC<Props> = ({item,deleteQuestion,updateQuestion}) => {

  function OnClickDelete(id: number){
    const action = deleteQuestion;
    action(id);
  }

    return (
        <Accordion sx={{width: 900}}>
        {/* <Accordion> */}    
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel1a-content"
            id="panel1a-header">
          <Typography>{item.text}</Typography>
          </AccordionSummary>
  
          <AccordionDetails>
            <QuestionForm item={item} deleteQuestion={deleteQuestion} updateQuestion={updateQuestion} ></QuestionForm>
          </AccordionDetails>
  
        </Accordion>
    )
}


const mapStateToProps = (state: ApplicationState) => ({
    questions: state.questions.questions
});

type Props = ReturnType<typeof mapDispatchToProps> & propsFromComponent;

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators({
        deleteQuestion: questionActionCreators.deleteQuestion,
        updateQuestion:questionActionCreators.editQuestion
    }, dispatch);

connect(mapStateToProps, mapDispatchToProps)(Question);

