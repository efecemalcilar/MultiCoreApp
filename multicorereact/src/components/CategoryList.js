import React, { Component } from "react";

export default class CategoryList extends Component {
  render() {
    return (
      <div>
        <table>
          <table className="table table-striped">
            <thead>
              <tr>
                <th scope="col">Id</th>
                <th scope="col">Category className</th>
                <th scope="col">Action</th>                
              </tr>
            </thead>
            <tbody>
              <tr>
                <th scope="row">1</th>
                <td>Mark</td>
                <td>Otto</td>
                <td>@mdo</td>
              </tr>
              
            </tbody>
          </table>
        </table>
      </div>
    );
  }
}
