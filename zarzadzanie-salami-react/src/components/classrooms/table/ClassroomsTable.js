import React from 'react';
import ReactTable from "react-table";
import "react-table/react-table.css";
import matchSorter from 'match-sorter';
import Abbreviation from "./Abbreviation";
import Select from "./Select";
import TwoOptionsSelect from "./TwoOptionsSelect";


const ClassroomsTable  = (props) => {

     const filterSwitcher = (filter, row) => {
        if (filter.value === "all") {
            return true;
        }
        switch (filter.value) {
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
    }

    return (
        <div className="table-classrooms-container">
            <Abbreviation/>
            <ReactTable
                data={props.classrooms}
                columns={[
                    {
                        Header: "Lista sal",
                        columns: [
                            {
                                Header: "Nazwa",
                                accessor: "nazwa_sali",
                                filterMethod: (filter, row) =>
                                    row[filter.id].startsWith(filter.value)
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
                                accessor: "pow_m2",

                            },
                            {
                                Header: "Liczba miejsc",
                                id: "places_less_over",
                                accessor: "liczba_miejsc_dydaktycznych",
                                filterMethod: (filter, row) => {
                                    return filterSwitcher(filter, row);
                                },
                                Filter: ({ filter, onChange }) =>
                                    <Select
                                        onChange={event => onChange(event.target.value)}
                                        style={{ width: "100%" }}
                                        value={filter ? filter.value : "all"}
                                    >
                                    </Select>
                            },
                            {
                                Header: "Komputery",
                                id: "more_less_computers",
                                accessor: "liczbaKomputerow",
                                filterMethod: (filter, row) => {
                                    return filterSwitcher(filter, row);
                                },
                                Filter: ({ filter, onChange }) =>
                                    <Select
                                        onChange={event => onChange(event.target.value)}
                                        style={{ width: "100%" }}
                                        value={filter ? filter.value : "all"}
                                    >
                                    </Select>
                            },
                            {
                                Header: "Gniazda sieciowe",
                                id: "more_less_network_connectors",
                                accessor: "liczba_gniazd_sieciowych",
                                filterMethod: (filter, row) => {
                                    return filterSwitcher(filter, row);

                                },
                                Filter: ({ filter, onChange }) =>
                                    <Select
                                        onChange={event => onChange(event.target.value)}
                                        style={{ width: "100%" }}
                                        value={filter ? filter.value : "all"}
                                    >
                                    </Select>
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
                                    <TwoOptionsSelect
                                        onChange={event => onChange(event.target.value)}
                                        style={{ width: "100%" }}
                                        value={filter ? filter.value : "all"}
                                    >

                                    </TwoOptionsSelect>
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
                                    <TwoOptionsSelect
                                        onChange={event => onChange(event.target.value)}
                                        style={{ width: "100%" }}
                                        value={filter ? filter.value : "all"}
                                    >

                                    </TwoOptionsSelect>
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
                                    <TwoOptionsSelect
                                        onChange={event => onChange(event.target.value)}
                                        style={{ width: "100%" }}
                                        value={filter ? filter.value : "all"}
                                    >

                                    </TwoOptionsSelect>
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
                                    <TwoOptionsSelect
                                        onChange={event => onChange(event.target.value)}
                                        style={{ width: "100%" }}
                                        value={filter ? filter.value : "all"}
                                    >

                                    </TwoOptionsSelect>

                            },
                            {
                                Header: "Rozklad sali",
                                accessor: "nazwa_rozklad_sali"
                            },
                            {
                                Header: "Funkcja",
                                id: "class_func",
                                accessor: d => d.funkcja_sali,
                                filterMethod: (filter, rows) =>
                                    matchSorter(rows, filter.value, { keys: ["class_func"] }),
                                filterAll: true
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
                filterable
                defaultFilterMethod={(filter, row) =>
                    String(row[filter.id]) === filter.value}
                getTdProps={(state, rowInfo, column, instance) => {
                    return {
                        onClick: (e, handleOriginal) => {
                            //TODO
                            console.log("It was in this row:", rowInfo.original.idSala);

                        }
                    };
                }}

            />
            <br />
        </div>
    )
}

export default ClassroomsTable;