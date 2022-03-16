import React, { useEffect, useState } from "react";
import {FormControl, Grid, IconButton, styled, Typography, Input, Button, Box} from "@mui/material";
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { IQuestionArea } from "../../DTO/IQuestionArea";
import { ApplicationState } from "../../store/typings";
import { connect } from "react-redux";
import { questionAreasActionCreators } from "../../store/QuestionArea";
import {bindActionCreators, Dispatch } from "redux";
import { useParams } from "react-router-dom";
import { defaultQuestionArea } from "../../common/defaultDTO/defaultQuestionArea";

const QuestionAreasForm: React.FC<Props> = (props) =>{
    let { id } = useParams();
    const [item, setItem] = useState<IQuestionArea>(props.questionAreas.questionArea || defaultQuestionArea);
    useEffect(() => {
        props.fetchQuestionAreaById(Number(id));
    }, []);

    const load = () => {
        setItem(props.questionAreas.questionArea || defaultQuestionArea);
    }
    const change = (e: React.ChangeEvent<HTMLInputElement>) => {
        let copy = Object.assign({}, item);
        copy.name = e.target.value;
        setItem(copy);
    };
    const submit = () =>{
        if(id) props.editQuestionArea(item);
        else props.createQuestionArea(item);
    }
    return (
            <Box>
                <Typography>{item.name}</Typography>
                <input value={item.name} onChange={change}/>
                <Button onClick={submit}> Send</Button>
            </Box>
    );
};

const mapStateToProps = (state: ApplicationState) => ({
    questionAreas: state.questionAreas
});

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators({
        createQuestionArea: questionAreasActionCreators.createQuestionArea,
        editQuestionArea: questionAreasActionCreators.editQuestionArea,
        fetchQuestionAreaById: questionAreasActionCreators.fetchQuestionAreaById,
    }, dispatch);

type Props = ReturnType<typeof mapStateToProps> &
    ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps)(QuestionAreasForm);