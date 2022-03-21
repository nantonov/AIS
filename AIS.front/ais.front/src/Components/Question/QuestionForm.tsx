import React from 'react';
import './style.css';
import Typography from '@mui/material/Typography';
import { IQuestion } from '../../DTO/IQuestion';
import {Button} from "@mui/material";
import { Field, InjectedFormProps, reduxForm } from 'redux-form';
import ReduxFormInput from './ReduxFormInput';

interface propsFromComponent {
    item: IQuestion;
    deleteQuestion: (id :number) => void;
}
interface propsFromDispatch { 
}

type Props = propsFromComponent & propsFromDispatch;

const QuestionForm: React.FC<Props & InjectedFormProps<IQuestion,Props>> 
= ({item,deleteQuestion,handleSubmit}) => {
    return (
      <form onSubmit={handleSubmit}>
            <Typography> Update Question</Typography>

            <Field name="text" component={ReduxFormInput} type="text" defaultValue={item.text} />
            {/* <Field
                  name="text"
                  type="text"
                  component="textarea"
                  defaultValue={item.text}
                /> */}
  
            <Typography pt={2}> True Answer</Typography>

            <Field
                  type="text"
                  name="trueAnswer"
                  component={ReduxFormInput}
                  externalValue={item.trueAnswer?.text}
                />
                
            {/* <Field
                  name="trueAnswer"
                  type="text"
                  component={InputField}
                  value={props.item.trueAnswer?.text}
                /> */}
            
            <div className='container'>
              <Button variant="contained" type="submit"> Confirm</Button>
              <Button variant="contained" onClick={() => {deleteQuestion(item.id);}}>Delete</Button>
            </div>
      </form>
    )
}

export const QuestionReduxForm = reduxForm<IQuestion, Props>({
    form:"questionUpdate"
  })(QuestionForm);