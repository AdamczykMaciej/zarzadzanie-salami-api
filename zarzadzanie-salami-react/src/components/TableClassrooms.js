import React from 'react';
import TableClassroomsHeader from "./TableClassroomsHeader";


const TableClassrooms  = (props) => {
    return (
        <div className="table-classrooms-container">
            <div className="table">
                <TableClassroomsHeader/>
                {props.data.map(classroom =>
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
    )
}

export default TableClassrooms;