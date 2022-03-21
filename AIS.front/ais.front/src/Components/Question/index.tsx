import React from 'react';
import {bindActionCreators, Dispatch} from 'redux';
import {ApplicationState} from "../../store/typing";
import {connect} from "react-redux";
import './style.css';
import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { IQuestion } from '../../DTO/IQuestion';
import { questionActionCreators } from '../../store/Questions';
import {  QuestionReduxForm } from './QuestionForm';

interface propsFromComponent {
    item: IQuestion;
}
interface propsFromDispatch { 
}

///type Props = propsFromComponent & propsFromDispatch;

export const Question: React.FC<Props> = ({item,deleteQuestion}: Props) => {

//export const Question: React.FC<Props> = ({item}) => {

  function OnClickDelete(id: number){
    const action = deleteQuestion;
    action(id);
  }

  function test(props : any){
    console.log(props.id)
    console.log(props.text)
    console.log(props.trueAnswer)
    alert('Кнопка сработала');
  }
  const greetTheUser = (question: IQuestion) => alert(question.text);

    return (
      <div>
        <Accordion sx={{width: 900}}>
        {/* <Accordion> */}      
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel1a-content"
            id="panel1a-header">
          <Typography>{item.text}</Typography>
          </AccordionSummary>
  
          <AccordionDetails>
            {/* <Typography> Update Question</Typography>
            <InputField externalValue={item.text} fieldName={'Text'} setExternalValue={function (value: string | number | boolean, fieldName: string): void {
              throw new Error('Function not implemented.');
            } }></InputField>
  
            <Typography pt={2}> True Answer</Typography>
            <InputField externalValue={'Props is data'} fieldName={'True Answe'} setExternalValue={function (value: string | number | boolean, fieldName: string): void {
              throw new Error('Function not implemented.');
            } }></InputField>
            
            <div className='container'>
              <Button variant="contained"> Confirm</Button>
              <Button variant="contained" onClick={() => {OnClickDelete(item.id);}}>Delete</Button>
            </div> */}
            <QuestionReduxForm item={item} deleteQuestion={deleteQuestion} onSubmit={test}></QuestionReduxForm>
            {/* <QuestionReduxForm item={item} deleteQuestion={deleteQuestion} updateQuestion={test} onSubmit={test}></QuestionReduxForm> */}
          </AccordionDetails>
  
        </Accordion>
      </div>
    )
}




const mapStateToProps = (state: ApplicationState) => ({
    questions: state.questions.questions
});

type Props = ReturnType<typeof mapDispatchToProps> & propsFromComponent;

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators({
        deleteQuestion: questionActionCreators.deleteQuestion
    }, dispatch);

connect(mapStateToProps, mapDispatchToProps)(Question);


// export default function Question(item:IQuestion) {
//   return (
//     <div>
//       <Accordion sx={{width: 900}}>
//       {/* <Accordion> */}
        
//         <AccordionSummary
//           expandIcon={<ExpandMoreIcon />}
//           aria-controls="panel1a-content"
//           id="panel1a-header">
//         <Typography>{item.text}</Typography>
//         </AccordionSummary>


//         <AccordionDetails>
//           <Typography> Update Question</Typography>
//           <InputField externalValue={item.text} fieldName={'Text'} setExternalValue={function (value: string | number | boolean, fieldName: string): void {
//             throw new Error('Function not implemented.');
//           } }></InputField>

//           <Typography pt={2}> True Answer</Typography>
//           <InputField externalValue={'Props is data'} fieldName={'True Answe'} setExternalValue={function (value: string | number | boolean, fieldName: string): void {
//             throw new Error('Function not implemented.');
//           } }></InputField>
          
//           <div className='container'>
//             <Button variant="contained"> Confirm</Button>
//             <Button variant="contained"> Delete</Button>
//           </div>
//         </AccordionDetails>

//       </Accordion>
//     </div>
//   );
// }

