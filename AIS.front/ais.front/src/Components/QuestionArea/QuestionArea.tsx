import * as React from 'react';
import { useNavigate } from "react-router-dom";

export default function QuestionArea() {

    let navigate = useNavigate();
    const routeChange = () =>{
        let path = `session`;
        navigate(path);
    }

    return (
        <h1>Question Area</h1>
    );
}
