import React, { Component } from 'react';

const API = 'https://29c5b169-c6d7-4060-b24a-df6a2e30d917.mock.pstmn.io/api/classrooms';


export class Classrooms extends Component{
    constructor(props){
        super(props);
        this.state = {
            classrooms: [],
            isLoading: false,
            error: null
        };
    }

    componentDidMount() {
        this.setState({isLoading: true});

        fetch(API)
            .then(response => {
                if(response.ok){
                   return response.json()
                }else{
                    throw new Error('Something went wrong...');
                }
            })
            .then(data => this.setState({classrooms: data, isLoading: false}))
            .catch(error => this.setState({error, isLoading: false}));
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
            <div className="classrooms">
                <h1>Classrooms list</h1>
                <table>
                    <thead>
                    <tr>
                        <th>IdSala</th>
                        <th>Nazwa Sali</th>
                        <th>Funkcja Sali</th>
                        <th>Budynek</th>
                    </tr>
                    </thead>
                    <tbody>
                    {classrooms.map(classroom =>
                        <tr>
                            <td>{classroom.idSala}</td>
                            <td>{classroom.nazwa_sali}</td>
                            <td>{classroom.funkcja_sali}</td>
                            <td>{classroom.nazwaBudynku}</td>
                        </tr>
                    )}
                    </tbody>
                </table>
            </div>
        )
    }
}