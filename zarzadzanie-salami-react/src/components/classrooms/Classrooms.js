import React, { Component } from 'react';
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
            const result = await getClassrooms();
            if(result.error){
                this.setState({
                    error: result.error,
                    isLoading: false
                });
            }else {
                this.setState({
                    classrooms: result.data,
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
                <div className="container-classrooms" style={{ padding: 10 }}>
                    <ClassroomsTable classrooms={classrooms}/>
                </div>
        )
    }
}