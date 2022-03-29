import React, {useEffect, useState} from "react";
import {Grid} from "@mui/material";
import {useDispatch} from "react-redux";
import {useNavigate} from "react-router-dom";
import {MainRoutes} from "../../core/constants/mainRoutes";
import QuestionAreaTableHeader from "./components/questionAreaTableHeader/QuestionAreaTableHeader";
import QuestionAreaTableRow from "./components/questionAreaTableRow/QuestionAreaTableRow";
import {fetchAllQuestionAreas, fetchQuestionAreaById} from "../../core/store/questionArea/actionCreators";
import {QuestionArea as questionArea} from "../../core/interfaces/questionArea";

interface Props {
    questionAreas: questionArea[]
}

const QuestionArea: React.FC = () => {
    const dispatch = useDispatch();
    const [questionArea, setQuestionArea] = useState<questionArea[]>([]);

    useEffect(() => {
        dispatch(fetchAllQuestionAreas());
    }, []);

    const navigate = useNavigate();
    const edit = (id: number) => {
        fetchQuestionAreaById(id);
        navigate(`/${MainRoutes.questionAreaForm}/${id}`);
    }

    return (
        <Grid container justifyContent="space=between"
              alignItems="center">
            <QuestionAreaTableHeader/>
            {questionArea.map((item) =>
                <QuestionAreaTableRow key={item.id} qArea={item} onEdit={edit.bind(this)}/>
            )}
        </Grid>
    );
};

export default QuestionArea;
