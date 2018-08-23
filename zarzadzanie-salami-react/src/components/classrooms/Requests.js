import React from 'react';
import axios from 'axios';



const URI = 'https://29c5b169-c6d7-4060-b24a-df6a2e30d917.mock.pstmn.io/api';
    export function getClassrooms() {
        return axios.get(`${URI}/classrooms`);
    }





