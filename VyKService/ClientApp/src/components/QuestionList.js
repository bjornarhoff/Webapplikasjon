import React, { Component } from 'react';

export class QuestionList extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: [],

        };

    }
    componentDidMount() {
        fetch("api/newQs")
            .then(response => response.json())
            .then(responseJson => {
                this.setState({ data: responseJson });
            })
            .catch(error => {
                console.error(error)
            });
    }


    render() {
        return (
            <div className="container-fluid">
                <div className = "row">
                    <h1 className="text-center mx-auto mb-5 mt-2 w-90 ">Innsendte Spørsmål</h1>
                </div>
                <div className="row">
                    {this.state.data.map((obj,i) => {
                        return (
                            <div key={i} className="col-md-6">
                                <div id={obj.id} className="card text-white bg-dark border-info text-center mx-auto view overlay">
                                    
                                    <div className="card-body">
                                        <p className="card-title lead text-info border-info"><strong>{obj.question}</strong></p>
                                    </div>
                                    <div className="card-footer form-group border-info">
                                        <p className="text-center font-weight-bold text-white mb-0">Innsendt: </p> 
                                        <ul className="list-group font-weight-light">
                                            <li>{obj.time}</li>
                                            <li> {obj.firstname} {obj.lastname}</li>
                                            <li>{obj.email}</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        )
                    })}
                </div>
                </div>
            )
  
    }


}