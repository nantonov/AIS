import * as React from 'react';
import {useNavigate} from "react-router-dom";

export default function Sessions() {

    let navigate = useNavigate();
    const routeChange = () => {
        let path = `question`;
        navigate(path);
    }

    return (
        <h1>Sessions</h1>
    );
}

