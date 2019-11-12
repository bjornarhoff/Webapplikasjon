import React, { Component } from 'react';
import { Votes } from './Votes';


export class Home extends Component {
    static displayName = Home.name;
    constructor(props) {
        super(props);
        this.state = {
            data: [],
        };
   
    }

    componentDidMount() {
        fetch("api/QAs")
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
                <div className="row">
                    <h1 className="text-center mx-auto mb-5 mt-2 w-90 ">Frequently Asked Questions</h1>
                    <div className="row">
                        {this.state.data.map((obj, i) => {
                            return (
                                <div key={i} className="col-md-6 mb-3">
                                    <div id={obj.id} className="h-100 card text-white bg-dark border-info text-center mx-auto view overlay">
                                        <div className="card-body">
                                            <p className="card-title lead text-info border-info"><strong>{obj.question}</strong></p>
                                            <p className="align-middle font-weight-light text-white">{obj.answer}</p>
                                        </div>
                                        <div className="card-footer mb-1 form-group font-italic border-info">
                                            <Votes votes={obj.votes} voteId={obj.id} />
                                        </div>
                                    </div>
                                </div>
                            )
                        })}
                    </div>
                </div>
            </div>
        );
    }

}
