import React, { Component } from 'react';
import './Classrooms.css';
import ClassroomsTable from "./table/ClassroomsTable";
import {getClassrooms} from './Requests';






export class Classrooms extends Component{
        state = {
            classrooms: [],
            isLoading: false,
            error: null
        };

    async componentDidMount() {
        this.setState({isLoading: true});
        try {
            const result = await getClassrooms();
            this.setState({
                classrooms: result.data,
                isLoading: false
            });

        }catch(error) {
            this.setState({
                error,
                isLoading: false
            });
        }
    }

    render (){
        const {classrooms, isLoading, error} = this.state;
        if(error){
            return <p>{error.message}</p>;
        }
        if(isLoading){
            return <p>Loading... Please, wait!</p>
        }
        return (
                <div className="container-classrooms">
                    <ClassroomsTable classrooms={classrooms}/>
                </div>
        )
    }
}