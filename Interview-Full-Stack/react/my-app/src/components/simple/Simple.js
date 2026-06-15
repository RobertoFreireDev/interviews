import { React } from 'react';

export function Simple({ text, handleClick})
{
    return (
        <div onClick={() => handleClick("div clicked")}>
            {text}
        </div>
    );
}