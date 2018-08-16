import React, { Component } from 'react';
import './Classrooms.css';

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
                <div className="container-classrooms">
                    <div className="info">
                        <p><b>T - tv; P - projektor; K - klimatyzacja; D - dostęp dla niepełnosprawnych</b></p>
                    </div>
                    <div className="wrap-classrooms">
                        <div className="table">
                        <div className="row header">
                            <div className="cell">
                                Id
                            </div>
                            <div className="cell">
                                Nazwa
                            </div>
                            <div className="cell">
                                Budynek
                            </div>
                            <div className="cell">
                                Piętro
                            </div>
                            <div className="cell">
                                m2
                            </div>
                            <div className="cell">
                                Liczba miejsc
                            </div>
                            <div className="cell">
                                Komputery
                            </div>
                            <div className="cell">
                                Gniazda sieciowe
                            </div>
                            <div className="cell">
                                P
                            </div>
                            <div className="cell">
                                T
                            </div>
                            <div className="cell">
                                K
                            </div>
                            <div className="cell">
                                D
                            </div>
                            <div className="cell">
                                Rozkład sali
                            </div>
                            <div className="cell">
                                Funkcja
                            </div>
                            <div className="cell">
                                Uwagi
                            </div>
                        </div>
                        {classrooms.map(classroom =>
                            <div className="row">
                                <div className="cell" data-title="Id">
                                    {classroom.idSala}
                                </div>
                                <div className="cell" data-title="Nazwa">
                                    {classroom.nazwa_sali}
                                </div>
                                <div className="cell" data-title="Budynek">
                                    {classroom.nazwaBudynku}
                                </div>
                                <div className="cell" data-title="Piętro">
                                    {classroom.poziom}
                                </div>
                                <div className="cell" data-title="m2">
                                    {classroom.pow_m2}
                                </div>
                                <div className="cell" data-title="Liczba miejsc">
                                    {classroom.liczba_miejsc}
                                </div>
                                <div className="cell" data-title="Komputery">
                                    {classroom.liczbaKomputerow}
                                </div>
                                <div className="cell" data-title="Gniazda sieciowe">
                                    {classroom.liczba_gniazd_sieciowych}
                                </div>
                                <div className="cell" data-title="P">
                                    {classroom.projektor ? '+' : '-'}
                                </div>
                                <div className="cell" data-title="T">
                                    {classroom.tv ? '+' : '-'}
                                </div>
                                <div className="cell" data-title="K">
                                    {classroom.klimatyzacja ? '+' : '-'}
                                </div>
                                <div className="cell" data-title="D">
                                    {classroom.dostep_dla_niepelnosprawnych ? '+' : '-'}
                                </div>
                                <div className="cell" data-title="Rozkład sali">
                                    {classroom.nazwaRozkladSali}
                                </div>
                                <div className="cell" data-title="Funkcja">
                                    {classroom.funkcja_sali}
                                </div>
                                <div className="cell" data-title="Uwagi">
                                    {classroom.uwagi}
                                </div>
                            </div>
                        )}
                        </div>
                    </div>
                </div>
            </div>

        )
    }
}