import React from 'react';
import ReactTable from "react-table";
import "react-table/react-table.css";
import TableAbbr from "./TableAbbr";


const TableClassrooms  = (props) => {
    return (
        <div className="table-classrooms-container">
            <TableAbbr/>
            <ReactTable
                data={props.data}
                columns={[
                    {
                        Header: "Lista sal",
                        columns: [
                            {
                                Header: "Id",
                                accessor: "idSala",
                                maxWidth: 50,
                            },
                            {
                                Header: "Nazwa",
                                accessor: "nazwa_sali",
                            },
                            {
                                Header: "Budynek",
                                accessor: "nazwaBudynku"
                            },
                            {
                                Header: "Piętro",
                                accessor: "poziom"
                            },
                            {
                                Header: "m2",
                                accessor: "pow_m2"
                            },
                            {
                                Header: "Liczba miejsc",
                                accessor: "liczba_miejsc_dydaktycznych"
                            },
                            {
                                Header: "Komputery",
                                accessor: "liczbaKomputerow"
                            },
                            {
                                Header: "Gniazda sieciowe",
                                accessor: "liczba_gniazd_sieciowych"
                            },
                            {
                                Header: "P",
                                id: "projektor",
                                accessor: d =>
                                    <span style={{
                                        color: d.projektor  ? '#57d500' : '#ff2e00'
                                    }}>
                                        &#x25cf;
                                    </span>
                            },
                            {
                                Header: "TV",
                                id: "tv",
                                accessor: d =>
                                    <span style={{
                                        color: d.tv  ? '#57d500' : '#ff2e00'
                                    }}>
                                        &#x25cf;
                                    </span>
                            },
                            {
                                Header: "K",
                                id: "klimatyzacja",
                                accessor: d =>
                                    <span style={{
                                        color: d.klimatyzacja  ? '#57d500' : '#ff2e00'
                                    }}>
                                        &#x25cf;
                                    </span>
                            },
                            {
                                Header: "D",
                                id: "dostep_dla_niepelnosprawnych",
                                accessor: d =>
                                    <span style={{
                                        color: d.dostep_dla_niepelnosprawnych ? '#57d500' : '#ff2e00'
                                    }}>
                                        &#x25cf;
                                    </span>
                            },
                            {
                                Header: "Rozklad sali",
                                accessor: "nazwa_rozklad_sali"
                            },
                            {
                                Header: "Funkcja",
                                accessor: "funkcja_sali"
                            },
                            {
                                Header: "Uwagi",
                                accessor: "uwagi"
                            }

                        ]
                    }
                ]}
                defaultPageSize={25}
                style={{
                    height: 800
                }}
                className="-striped -highlight"
            />
            <br />
        </div>
    )
}

export default TableClassrooms;