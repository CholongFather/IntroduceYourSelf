import React, { Component } from 'react';

export class Introduce extends Component {
    static displayName = Introduce.name;

  constructor(props) {
    super(props);
      this.state = { introduce: [], loading: true };
  }

  componentDidMount() {
      this.fetchIntroduceData();
  }

    static renderIntroduceTable(introduces)
    {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Wtf</th>
          </tr>
        </thead>
        <tbody>
                <tr>
                    <td>{introduces.testName}</td>
                </tr>       
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : Introduce.renderIntroduceTable(this.state.introduce);

    return (
      <div>
        <h1 id="tabelLabel">Introduce</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async fetchIntroduceData() {
    const response = await fetch('http://localhost:8080/IntroduceMySelf/MyName');
      const data = await response.json();
    this.setState({ introduce: data, loading: false });
  }
}
