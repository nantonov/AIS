import React from "react";
import {Grid, IconButton, Typography} from '@mui/material';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import {QuestionArea} from "../../../../core/interfaces/questionArea";

interface Props {
    qArea: QuestionArea,
    onEdit: (id: number) => void,
}

const QuestionAreaTableRow: React.FC<Props> = ({qArea, onEdit}) => {
    return (
        <Grid item container justifyContent='space-between'>
            <Grid item xs={1}><Typography>{qArea?.id}</Typography></Grid>
            <Grid item xs><Typography>{qArea?.name}</Typography></Grid>
            <Grid item xs={1}><IconButton><ExpandMoreIcon></ExpandMoreIcon></IconButton></Grid>
            <Grid item xs={1}><IconButton onClick={() => onEdit(qArea?.id)}><EditIcon></EditIcon></IconButton></Grid>
            <Grid item xs={1}><IconButton><DeleteIcon></DeleteIcon></IconButton></Grid>
        </Grid>
    );
};
export default QuestionAreaTableRow
