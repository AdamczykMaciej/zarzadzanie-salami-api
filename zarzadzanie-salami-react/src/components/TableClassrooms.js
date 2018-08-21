import React from 'react';
import ReactTable from "react-table";
import "react-table/react-table.css";
import matchSorter from 'match-sorter';
import TableAbbr from "./TableAbbr";


const TableClassrooms  = (props) => {

    const data = props.classrooms;
    return (
        <div className="table-classrooms-container">
            <TableAbbr/>
            <ReactTable
                data={data}
                filterable
                defaultFilterMethod={(filter, row) =>
                    String(row[filter.id]) === filter.value}
                columns={[
                    {
                        Header: "Lista sal",
                        columns: [
                            {
                                Header: "Nazwa",
                                accessor: "nazwa_sali",
                                filterMethod: (filter, row) =>
                                    row[filter.id].startsWith(filter.value) &&
                                    row[filter.id].endsWith(filter.value)
                            },
                            {
                                Header: "Budynek",
                                id: "building_name",
                                accessor: "nazwaBudynku",
                                filterMethod: (filter, row) => {
                                    if (filter.value === "all") {
                                        return true;
                                    }
                                    return row[filter.id] === filter.value;
                                },
                                Filter: ({ filter, onChange }) =>
                                    <select
                                        onChange={event => onChange(event.target.value)}
                                        style={{ width: "100%" }}
                                        value={filter ? filter.value : "all"}
                                    >
                                        <option value="all">Wszystkie</option>
                                        <option value="A">A</option>
                                        <option value="C">C</option>
                                        <option value="G">G</option>

                                    </select>

                            },
                            {
                                Header: "Piętro",
                                id: "level",
                                accessor: d => d.poziom,
                                filterMethod: (filter, rows) =>
                                    matchSorter(rows, filter.value, { keys: ["level"] }),
                                filterAll: true
                            },
                            {
                                Header: "m2",
                                accessor: "pow_m2"
                            },
                            {
                                Header: "Liczba miejsc",
                                id: "places_less_over",
                                accessor: "liczba_miejsc_dydaktycznych",
                                filterMethod: (filter, row) => {
                                    if (filter.value === "all") {
                                        return true;
                                    }
                                    switch(filter.value) {
                                        case "lessThan_10":
                                            return row[filter.id] < 10;
                                            break;
                                        case "from_10_to_15":
                                            return row[filter.id] >= 10 && row[filter.id] <= 15;
                                            break;
                                        case "from_16_to_20":
                                            return row[filter.id] >= 16 && row[filter.id] <= 20;
                                            break;
                                        case "greaterThan_20":
                                            return row[filter.id] > 20;
                                            break;
                                        default:
                                            break;
                                    }
                                },
                                Filter: ({ filter, onChange }) =>
                                    <select
                                        onChange={event => onChange(event.target.value)}
                                        style={{ width: "100%" }}
                                        value={filter ? filter.value : "all"}
                                    >
                                        <option value="all">Wszystkie</option>
                                        <option value="lessThan_10">{'<'}10</option>
                                        <option value="from_10_to_15">10-15</option>
                                        <option value="from_16_to_20">16-20</option>
                                        <option value="greaterThan_20">{'>'}20</option>
                                    </select>
                            },
                            {
                                Header: "Komputery",
                                id: "more_less_computers",
                                accessor: "liczbaKomputerow",
                                filterMethod: (filter, row) => {
                                    if (filter.value === "all") {
                                        return true;
                                    }
                                    switch(filter.value) {
                                        case "lessThan_10":
                                            return row[filter.id] < 10;
                                            break;
                                        case "from_10_to_15":
                                            return row[filter.id] >= 10 && row[filter.id] <= 15;
                                            break;
                                        case "from_16_to_20":
                                            return row[filter.id] >= 16 && row[filter.id] <= 20;
                                            break;
                                        case "greaterThan_20":
                                            return row[filter.id] > 20;
                                            break;
                                        default:
                                            break;
                                    }
                                },
                                Filter: ({ filter, onChange }) =>
                                    <select
                                        onChange={event => onChange(event.target.value)}
                                        style={{ width: "100%" }}
                                        value={filter ? filter.value : "all"}
                                    >
                                        <option value="all">Wszystkie</option>
                                        <option value="lessThan_10">{'<'}10</option>
                                        <option value="from_10_to_15">10-15</option>
                                        <option value="from_16_to_20">16-20</option>
                                        <option value="greaterThan_20">{'>'}20</option>
                                    </select>
                            },
                            {
                                Header: "Gniazda sieciowe",
                                id: "more_less_network_connectors",
                                accessor: "liczba_gniazd_sieciowych",
                                filterMethod: (filter, row) => {
                                    if (filter.value === "all") {
                                        return true;
                                    }
                                    switch(filter.value) {
                                        case "lessThan_10":
                                            return row[filter.id] < 10;
                                            break;
                                        case "from_10_to_15":
                                            return row[filter.id] >= 10 && row[filter.id] <= 15;
                                            break;
                                        case "from_16_to_20":
                                            return row[filter.id] >= 16 && row[filter.id] <= 20;
                                            break;
                                        case "greaterThan_20":
                                            return row[filter.id] > 20;
                                            break;
                                        default:
                                            break;
                                    }

                                },
                                Filter: ({ filter, onChange }) =>
                                    <select
                                        onChange={event => onChange(event.target.value)}
                                        style={{ width: "100%" }}
                                        value={filter ? filter.value : "all"}
                                    >
                                        <option value="all">Wszystkie</option>
                                        <option value="lessThan_10">{'<'}10</option>
                                        <option value="from_10_to_15">10-15</option>
                                        <option value="from_16_to_20">16-20</option>
                                        <option value="greaterThan_20">{'>'}20</option>
                                    </select>
                            },
                            {
                                Header: "P",
                                id: "projector",
                                accessor: "projektor",
                                Cell: ({ value }) => (value ? <span style={{
                                    color: '#57d500'
                                }}>
                                        &#x25cf;
                                    </span> : <span style={{
                                        color: '#ff2e00'
                                }}>
                                        &#x25cf;
                                    </span>),
                                filterMethod: (filter, row) => {
                                    if (filter.value === "all") {
                                        return true;
                                    }
                                        return row[filter.id];


                                },
                                Filter: ({ filter, onChange }) =>
                                    <select
                                        onChange={event => onChange(event.target.value)}
                                        style={{ width: "100%" }}
                                        value={filter ? filter.value : "all"}
                                    >
                                        <option value="all">Wszystkie</option>
                                        <option value="true">+</option>
                                    </select>
                            },
                            {
                                Header: "TV",
                                id: "tv",
                                accessor: "tv",
                                Cell: ({ value }) => (value ? <span style={{
                                    color: '#57d500'
                                }}>
                                        &#x25cf;
                                    </span> : <span style={{
                                    color: '#ff2e00'
                                }}>
                                        &#x25cf;
                                    </span>),
                                filterMethod: (filter, row) => {
                                    if (filter.value === "all") {
                                        return true;
                                    }
                                    return row[filter.id];


                                },
                                Filter: ({ filter, onChange }) =>
                                    <select
                                        onChange={event => onChange(event.target.value)}
                                        style={{ width: "100%" }}
                                        value={filter ? filter.value : "all"}
                                    >
                                        <option value="all">Wszystkie</option>
                                        <option value="true">+</option>
                                    </select>
                            },
                            {
                                Header: "K",
                                id: "air_conditioner",
                                accessor: "klimatyzacja",
                                Cell: ({ value }) => (value ? <span style={{
                                    color: '#57d500'
                                }}>
                                        &#x25cf;
                                    </span> : <span style={{
                                    color: '#ff2e00'
                                }}>
                                        &#x25cf;
                                    </span>),
                                filterMethod: (filter, row) => {
                                    if (filter.value === "all") {
                                        return true;
                                    }
                                    return row[filter.id];


                                },
                                Filter: ({ filter, onChange }) =>
                                    <select
                                        onChange={event => onChange(event.target.value)}
                                        style={{ width: "100%" }}
                                        value={filter ? filter.value : "all"}
                                    >
                                        <option value="all">Wszystkie</option>
                                        <option value="true">+</option>
                                    </select>
                            },
                            {
                                Header: "D",
                                id: "disabled_access",
                                accessor: "dostep_dla_niepelnosprawnych",
                                Cell: ({ value }) => (value ? <span style={{
                                    color: '#57d500'
                                }}>
                                        &#x25cf;
                                    </span> : <span style={{
                                    color: '#ff2e00'
                                }}>
                                        &#x25cf;
                                    </span>),
                                filterMethod: (filter, row) => {
                                    if (filter.value === "all") {
                                        return true;
                                    }
                                    return row[filter.id];


                                },
                                Filter: ({ filter, onChange }) =>
                                    <select
                                        onChange={event => onChange(event.target.value)}
                                        style={{ width: "100%" }}
                                        value={filter ? filter.value : "all"}
                                    >
                                        <option value="all">Wszystkie</option>
                                        <option value="true">+</option>
                                    </select>

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