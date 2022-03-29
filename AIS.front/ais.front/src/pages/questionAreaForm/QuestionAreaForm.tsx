import React, { useEffect, useState } from "react";
import {Typography, Button, Box} from "@mui/material";
import { QuestionArea } from "../../core/interfaces/questionArea";
import { ApplicationState } from "../../core/store/typing";
import { connect } from "react-redux";
import { questionAreasActionCreators } from "../../core/store/questionArea";
import {bindActionCreators, Dispatch } from "redux";
import { useParams } from "react-router-dom";
import { defaultQuestionArea } from "../../core/common/defaultDTO/defaultQuestionArea";

const QuestionAreasForm: React.FC<Props> = ({createQuestionArea, editQuestionArea, fetchQuestionAreaById, questionAreas}) =>{
    const { id } = useParams();
    const [item, setItem] = useState<QuestionArea>(questionAreas.questionArea || defaultQuestionArea);
    useEffect(() => {
        fetchQuestionAreaById(Number(id));
    }, []);

    const load = () => {
        setItem(questionAreas.questionArea || defaultQuestionArea);
    }
    const change = (e: React.ChangeEvent<HTMLInputElement>) => {
        const copy = Object.assign({}, item);
        copy.name = e.target.value;
        setItem(copy);
    };
    const submit = () =>{
        if(id) editQuestionArea(item);
        else createQuestionArea(item);
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
