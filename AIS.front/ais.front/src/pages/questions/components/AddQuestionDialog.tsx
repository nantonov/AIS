import React, { useState } from 'react';
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  TextField,
  Typography,
} from '@mui/material';
import defaultQuestion from '../../../core/common/defaultDTO/defaultQuestion';
import defaultTrueAnswer from '../../../core/common/defaultDTO/defaultTrueAnswer';
import { Question } from '../../../core/interfaces/question/question';
import { TrueAnswer } from '../../../core/interfaces/trueAnswer/trueAnswer';

interface Props {
  open: boolean;
  setOpen: (open: boolean) => void;
  // updateQuestion:(question :Question) =>void
  // updateTrueAnswer:(trueAnswer :TrueAnswer) =>void
}

export const AddQuestionDialog: React.FC<Props> = ({ setOpen, open }) => {
  const [question, setQuestion] = useState<Question>(defaultQuestion);
  const [trueAnswer, setTrueAnswer] = useState<TrueAnswer>(defaultTrueAnswer);

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <Dialog open={open} onClose={handleClose} PaperProps={{ sx: { width: '75%', height: '50%' } }}>
      <DialogTitle color="primary">New question</DialogTitle>

      <DialogContent>
        <Typography>Question</Typography>
        <TextField
          fullWidth
          autoFocus
          type="text"
          value={question.text}
          onChange={(event) => {
            setQuestion((prev: Question) => ({ ...prev, text: event.target.value }));
          }}
        />

        <Typography pt={2}>True Answer</Typography>
        <TextField
          id="standard-multiline-flexible"
          fullWidth
          multiline
          maxRows={8}
          value={trueAnswer.text}
          onChange={(event) => {
            setTrueAnswer((prev: TrueAnswer) => ({ ...prev, text: event.target.value }));
          }}
        />
      </DialogContent>

      <DialogActions>
        <Button onClick={handleClose} variant="contained">
          Cancel
        </Button>
        <Button onClick={handleClose} variant="contained">
          Add
        </Button>
      </DialogActions>
    </Dialog>
  );
};
