import React, {useEffect} from 'react';
import {bindActionCreators, Dispatch} from 'redux';
import {Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow} from "@mui/material";
import {ApplicationState} from "../../store/typing";
import {connect} from "react-redux";
import {questionSetActionCreators} from "../../store/QuestionSets";
import {useParams} from "react-router-dom";
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import {QuestionService} from "../../services/QuestionService";
import Typography from "@mui/material/Typography";
import styled from "@emotion/styled";
import {QuestionAreaService} from "../../services/QuestionAreaService";

const QuestionSetDescription: React.FC<Props> = ({questionSet, getById}: Props) => {

    const GridContainer = styled(Grid)
    `
      width: 100%;
      max-width: 1170px;
      margin: auto;
    `

    let {id} = useParams();

    useEffect(() => {
        getById(Number(id));
    }, []);

    function Delete(id: number) {
        QuestionService.deleteById(id).then(() => {
            getById(Number(id));
        }).catch((e) => console.log(e))
    }

    function DeleteQuestionArea(id: number){
        QuestionAreaService.deleteById(id).then(()=>{
            getById(Number(id));
        })
    }

    console.log(questionSet)

    return (
        <GridContainer>
            <Grid item>
                <Typography variant="h4" component="h5"> Question set: {questionSet.name}</Typography>
            </Grid>
            <Grid item>
                <Typography variant="h5" component="h6" marginTop="10px" marginBottom="10px">Question areas: </Typography>
                <TableContainer component={Paper}>
                    <Table sx={{minWidth: 650}} aria-label="simple table">
                        <TableHead>
                            <TableRow>
                                <TableCell>Question area</TableCell>
                                <TableCell/>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                         {questionSet.questionAreas?.map((questionArea)=> (
                             <TableRow key={questionArea.id} sx={{'&:last-child td, &:last-child th': {border: 0}}}>
                             <TableCell component="th" scope="row">{questionArea.name}</TableCell>
                             <TableCell align="right"><Button endIcon={<EditIcon/>}/><Button
                             endIcon={<DeleteIcon/>} onClick={() => DeleteQuestionArea(questionArea.id)}/></TableCell>
                             </TableRow>
                         ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            </Grid>

            <Grid item>
                <Typography variant="h5" component="h6" marginTop="10px" marginBottom="10px">Questions</Typography>
                <TableContainer component={Paper}>
                    <Table sx={{minWidth: 650}} aria-label="simple table">
                        <TableHead>
                            <TableRow>
                                <TableCell>Number</TableCell>
                                <TableCell>Name</TableCell>
                                <TableCell>True answer</TableCell>
                                <TableCell/>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {questionSet.questions.map((row) => (
                                <TableRow key={row.id}
                                          sx={{'&:last-child td, &:last-child th': {border: 0}}}>
                                    <TableCell>{row.id}</TableCell>
                                    <TableCell component="th" scope="row">{row.text}</TableCell>
                                    <TableCell component="th" scope="row">{row.trueAnswer?.text}</TableCell>
                                    <TableCell align="right"><Button endIcon={<EditIcon/>}/><Button
                                        endIcon={<DeleteIcon/>} onClick={() => Delete(row.id)}/></TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            </Grid>
        </GridContainer>
    )
}


const mapStateToProps = (state: ApplicationState) => ({
    router: state.router,
    questionSet: state.questionSets.questionSet,
});

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators({
        getById: questionSetActionCreators.getById
    }, dispatch);

type Props = ReturnType<typeof mapStateToProps> &
    ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps)(QuestionSetDescription);
