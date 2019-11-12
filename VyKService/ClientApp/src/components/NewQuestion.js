import React, { Component } from 'react';
import axios from 'axios';

export class NewQuestion extends Component {
    state = {
        firstname: '',
        lastname: '',
        email: '',
        question: '',
        time: new Date().toLocaleString()
    }

    handleChange = (e) => {
        const { name, value } = e.target;

        this.setState({
            [name]: value
        })
    }

    handleSubmit = (e) => {
        e.preventDefault();
        console.log(this.state)

        axios.post('api/QAs', this.state)
            .then(response => {
                console.log(response)
                this.setState({
                    firstname: '',
                    lastname: '',
                    email: '',
                    question: ''
                })
             alert("Spørsmålet ditt er sendt inn, du vil få svar på mail så fort som mulig!")
            })
            .catch(error => {
                console.log(error)
            })
       
    }

    render() {
        return (
            <div>
                <h1 className="text-center mx-auto mb-5 mt-2 w-90 ">Kontakt</h1>
                <form className="form-group md-form shadow-textarea" onSubmit={this.handleSubmit}>
                    <input
                        type="text"
                        value={this.state.firstname}
                        name="firstname"
                        onChange={this.handleChange}
                        placeholder="Skriv inn fornavn"
                        className="form-control z-depth-1s mb-3"
                        required
                    />
                    <input
                        type="text"
                        value={this.state.lastname}
                        name="lastname"
                        onChange={this.handleChange}
                        placeholder="Skriv inn etternavn"
                        className="form-control z-depth-1s mb-3"
                        required
                    />
                    <input
                        type="email"
                        value={this.state.email}
                        name="email"
                        onChange={this.handleChange}
                        placeholder="Skriv inn email"
                        className="form-control z-depth-1s mb-3"
                        required
                    />
                        <textarea
                        type="text"
                        name="question"
                        value={this.state.question}
                        onChange={this.handleChange}
                        className="form-control z-depth-1s mb-3"
                        placeholder="Hva lurer du på?"
                        required
                    />
                    <div>
                        <button type="submit" className="btn btn-secondary btn-lg btn-block">SEND INN</button>
                    </div>
                </form>
            </div>
            )
    } 



}