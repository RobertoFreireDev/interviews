import { Component } from 'react';

export class SimpleClass extends Component {
    constructor()
    {
        super();
    }

    render() {
        return <div onClick={() => this.props.handleClick("div clicked from class Component")}>
            {this.props.text}
        </div>
    }
}