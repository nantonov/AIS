import React, {useEffect, useState} from "react";
import {Typography, Button, Box} from "@mui/material";
import {QuestionArea} from "../../core/interfaces/questionArea";
import {useDispatch} from "react-redux";
import {useParams} from "react-router-dom";
import {defaultQuestionArea} from "../../core/common/defaultDTO/defaultQuestionArea";
import {
    createQuestionArea,
    editQuestionArea,
    fetchQuestionAreaById
} from "../../core/store/questionArea/actionCreators";

const QuestionAreasForm: React.FC = () => {
    const {id} = useParams();
    const dispatch = useDispatch();
    const [item, setItem] = useState<QuestionArea>(defaultQuestionArea);

    useEffect(() => {
        dispatch(fetchQuestionAreaById(Number(id)));
    }, []);

    const change = (e: React.ChangeEvent<HTMLInputElement>) => {
        const copy = Object.assign({}, item);
        copy.name = e.target.value;
        setItem(copy);
    };
    const submit = () => {
        if (id) dispatch(editQuestionArea(item));
        else dispatch(createQuestionArea(item));
    }
    return (
        <Box>
            <Typography>{item.name}</Typography>
            <input value={item.name} onChange={change}/>
            <Button onClick={submit}> Send</Button>
        </Box>
    );
};

export default QuestionAreasForm;
