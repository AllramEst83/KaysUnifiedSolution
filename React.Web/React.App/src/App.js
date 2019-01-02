import React, { Component } from 'react';
import './App.css';
import axios from 'axios';


//Axios and Fetch examles
//const Unicorns = (props) => {


//    axios.get('https://localhost:44387/api/PublicUnicorn/GetUnicorns', {
//        headers:
//            {
//                'Access-Control-Allow-Origin': 'http://localhost:3000/',
//                'Content-Type': 'application/json',
//                'Accept': 'application/json'
//            }
//    }).then(resp => {
//        console.log("From axios data: ");
//        console.log(JSON.parse(resp.data));
//        this.setState({ unicorns: JSON.parse(resp.data) })
//    }).catch(function (error) {
//        console.log(error);
//    });

//    fetch('https://localhost:44387/api/PublicUnicorn/GetUnicorns', {
//        method: 'get',
//        headers:
//            {
//                'Access-Control-Allow-Origin': 'http://localhost:3000',
//                'Content-Type': 'application/json',
//                'Accept': 'application/json'
//            }
//    }).then(function (response) {
//        console.log("From fetch data: ");
//        console.log(response.json());
//    })
//        .catch(function (error) {
//            console.log(error);
//        });


//    return (
//        <div>
//            Test
//        </div>
//    );
//};
//AXios and Fetch examles



class Unicorns extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            items: []
        };
    }


    componentDidMount() {
        fetch('https://192.168.10.159:45460/api/PublicUnicorn/GetUnicorns')
            .then(res => res.json())
            .then(
                (result) => {
                    console.log(result)
                    this.setState({
                        isLoaded: true,
                        items: result.Unicorns
                    });
                },
                // Note: it's important to handle errors here
                // instead of a catch() block so that we don't swallow
                // exceptions from actual bugs in components.
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                }
            )
    }

    render() {
        const { error, isLoaded, items } = this.state;
        if (error) {
            return <div>Error: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Loading...</div>;
        } else {
            return (
                <ul>
                    {items.map(item => (
                        <li key={item.Id}>
                            {item.Name} - HornType: {item.HornType.Decoration}
                        </li>
                    ))}
                </ul>
            );
        }
    }
}


class App extends Component {
    render() {
        return (
            <div className="App">
                <header className="App-header">
                    <div>
                        <Unicorns />
                    </div>
                </header>
            </div>
        );
    }
}

export default App;
