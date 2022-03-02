import ReactDetails from "./ReactDetails.jsx";
import ReactList from './ReactList.jsx';
import ReactAdd from './ReactAdd.jsx';

function App() {

    const [people, setPeople] = React.useState([]);
    const [details, setDetails] = React.useState([]);
    const [cities, setCities] = React.useState([]);

    const showPersonDetails = (person) => {
        setDetails({
            id: person.id,
            name: person.name,
            phone: person.phone,
            cityName: person.cityName
        });
    }

    React.useEffect(() => {
        listPeople()
    }, [])


    const listPeople = () => {
        fetch('React/ListPeople'
            , {
                headers: {
                    'Content-Type': 'application/json',
                }
            }
        )
            .then(function (response) {
                return response.json();
            })
            .then(function (myJson) {
                setPeople(myJson.reactPeople)
                setCities(myJson.reactCities)
            });
    }

    return (
        <div className="container">
            <h3 className="p-3 text-center">React</h3>
            <h4 className="p-3 text-center">Add Person</h4>
            <ReactAdd cities={cities} />
            <h4 className="p-3 text-center">Person List</h4>
            <ReactList people={people} showPersonDetails={showPersonDetails} />
            <div>
                <p>Person details</p>
                <ReactDetails details={details} people={people} />
            </div>
        </div>

    )
}

ReactDOM.render(
    <App />,
    document.getElementById('content')
);
