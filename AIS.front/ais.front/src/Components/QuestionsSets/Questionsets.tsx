import React from 'react';
import {Button} from "@mui/material";
import DeleteIcon from "@material-ui/icons/Delete";
import Grid from '@mui/material/Grid';

export default function QuestionSets() {

    return (
        <Grid container spacing={2}>
            <Grid item>
                <Button variant="contained">Add Question Set</Button>
            </Grid>
            <Grid item>
                <Button variant="outlined" startIcon={<DeleteIcon/>}>Delete</Button>
            </Grid>
        </Grid>
    )
}
