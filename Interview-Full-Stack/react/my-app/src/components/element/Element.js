import { createElement } from 'react';

// An Element is a plain object describing what you want to appear on the screen
export default function Element()
{
    // the log for Element() will be something like this object element
    var element = {
        key : "1",
        props : {
            value : "text",
            className : "greeting",
            children : {
                key : null,
                type : "div",
                props : {
                    children : "Text red inside div",
                    style : {color: 'red'}
                }                
            }
        },
        type : "h1"
    }
    return createElement("h1",{ key:"1", value:"text", className: 'greeting' },<div style={{color:'red'}}>Text red inside div</div>)
}

console.log(Element());