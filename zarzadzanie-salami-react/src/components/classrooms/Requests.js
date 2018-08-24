import axios from 'axios';


const URI = 'https://29c5b169-c6d7-4060-b24a-df6a2e30d917.mock.pstmn.io/api';

export function getClassrooms() {
    try {
        return axios.get(`${URI}/classrooms`);
    } catch (error) {
        return error;
    }
}

export function getClassroomById(id) {
    try {
        return axios.get(`${URI}/classroom/${id}`);
    }catch(error) {
        return error;
    }
}





