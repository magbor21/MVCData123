const ReactList = (props) => {
    const [people, setPeople] = React.useState(props.people)
    const [sortOrder, setOrder] = React.useState("asc")

    React.useEffect(() => {
        setPeople(props.people)
    }, [props])


    const SortList = () => {
        if (sortOrder === "asc") {
            const sortAsc = [...people].sort((a, b) =>
                a.name.toLowerCase() > b.name.toLowerCase() ? 1 : -1
            );
            setOrder("dsc")
            setPeople(sortAsc);
        } else {
            const sortDsc = [...people].sort((a, b) =>
                a.name.toLowerCase() < b.name.toLowerCase() ? 1 : -1
            );
            setOrder("asc")
            setPeople(sortDsc);
        }
    }


    return (
        <table className="table table-striped table-bordered">
            <thead>
                <tr>
                    <th className="btn" onClick={() => { SortList() }}>Name</th>
                    <th>See details</th>
                </tr>
            </thead>
            <tbody>
                {(people.map((person) => (
                    <tr key={person.id}>
                        <td >{person.name}</td>
                        <td>
                            <button onClick={() => { props.showPersonDetails(person) }} className="btn">Details</button>
                        </td>
                    </tr>
                ))
                )}
            </tbody>
        </table>

    )
}

export default ReactList