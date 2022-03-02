const ReactDetails = (props) => {

    const [person, setPerson] = React.useState(props.details);

    React.useEffect(
        () => {
            setPerson(props.details)
        },
        [props]
    )

    function handleSubmit(e) {
        
        var personid = person.id;
        console.log(person);

        fetch('React/DeletePerson',
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ id: personid })
            })
            .then(response => {
                console.log('Response:', response);
                console.log('Response:', "Deleting ", personid);
                window.location.reload(false);
            });
        alert("Deleted: " + person.name);
    }

    return (
        <div>

            < table className="table table-striped table-bordered" >
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Id</th>
                        <th>Phone</th>
                        <th>City</th>
                    </tr>
                </thead>
                <tbody>
                    <tr key={person.id}>
                        <td >{person.name}</td>
                        <td >{person.id}</td>
                        <td >{person.phone}</td>
                        <td >{person.cityName}</td>

                    </tr>
                </tbody>
            </table >
            <form onSubmit={handleSubmit}>
                <button type="submit">Delete Person</button>
            </form>
        </div>

    )
}

export default ReactDetails