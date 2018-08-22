import React, { Component } from 'react';
import './Classrooms.css';
import ClassroomsTable from "./table/ClassroomsTable";
import axios from 'axios';


const API = 'https://29c5b169-c6d7-4060-b24a-df6a2e30d917.mock.pstmn.io/api/classrooms';



export class Classrooms extends Component{
        state = {
            classrooms: [],
            isLoading: false,
            error: null
        };

    componentDidMount() {
        this.setState({isLoading: true});

        axios.get(API)

            .then(result => this.setState({
                classrooms: result.data,
                isLoading: false
            }))
            .catch(error => this.setState({
                error,
                isLoading: false
            }));
    }

    render (){
        const {classrooms, isLoading, error} = this.state;
        if(error){
            return <p>{error.message}</p>;
        }
        if(isLoading){
            return <p>Loading...</p>
        }
        return (
                <div className="container-classrooms">
                    <ClassroomsTable classrooms={classrooms}/>
                </div>
        )
    }
}