import { Grid, Typography } from "@mui/material";
import React from "react"



const QuestionAreaTableHeader: React.FC = () =>{
    return (
        <>
            <Grid item  container justifyContent = 'space-between'>
                <Grid item xs={1}><Typography>Id</Typography></Grid>
                <Grid item xs><Typography>Name</Typography></Grid>
                <Grid item xs={1}><Typography>More info</Typography></Grid>
                <Grid item xs={1}><Typography>Edit</Typography></Grid>
                <Grid item xs={1}><Typography>Delete</Typography></Grid>
            </Grid>
        </>
    );
};
export default QuestionAreaTableHeader
