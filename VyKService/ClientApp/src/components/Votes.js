import React, { Component } from 'react';
import axios from 'axios';


export class Votes extends Component {
  
    voteHandler(id, vote) {
        axios.put('api/QAs/' + id + '?vote=' + vote)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })
        window.location.reload(false)
    }

  render() {

      return (
          <div className="row">
              <div className="col-md-4">
                  <button className="btn btn-outline-danger" onClick={() => this.voteHandler(this.props.voteId, -1)}>Dislike</button>
              </div >
              <div className="col-md-4">
                  <p>Likes: {this.props.votes}</p>
              </div>

              <div className="col-md-4">
                  <button className="btn btn-outline-info" onClick={() => this.voteHandler(this.props.voteId, 1)}>Like</button>
              </div>
          </div>
    );
  }
}
