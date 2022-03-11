import * as React from 'react';
import './style.css';
import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { InputField } from './InputField';
import { IQuestion } from '../../DTO/IQuestion';
import { Button, Grid } from '@mui/material';

export default function Question(props:IQuestion) {
  return (
    <div>
      <Accordion sx={{width: 900}}>
      {/* <Accordion> */}
        
        <AccordionSummary
          expandIcon={<ExpandMoreIcon />}
          aria-controls="panel1a-content"
          id="panel1a-header">
        <Typography>{props.text}</Typography>
        </AccordionSummary>


        <AccordionDetails>

          <Typography> Update Question</Typography>
          <InputField externalValue={props.text} fieldName={'Text'} setExternalValue={function (value: string | number | boolean, fieldName: string): void {
            throw new Error('Function not implemented.');
          } }></InputField>

          <Typography pt={2}> True Answer</Typography>
          <InputField externalValue={'Props is data'} fieldName={'True Answe'} setExternalValue={function (value: string | number | boolean, fieldName: string): void {
            throw new Error('Function not implemented.');
          } }></InputField>
          
          <div className='container'>
            <Button variant="contained"> Confirm</Button>
            <Button variant="contained"> Delete</Button>
          </div>
        </AccordionDetails>

      </Accordion>
    </div>
  );
}

