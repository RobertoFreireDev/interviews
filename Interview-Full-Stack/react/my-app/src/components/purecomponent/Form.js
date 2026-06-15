import { memo, useState } from 'react';

// memo prevents re-renders of child component for the same props passed by parent component
const EmployeeForm = memo(function({ name, email })
{
    console.log("EmployeeForm running");
    return (<>
        <p>Name:{name}</p>
        <p>Email:{email}</p>
        </>); 
});

export default function Form()
{
    const [name,setName] = useState('');
    const [email,setEmail] = useState('');
    const [x,setX] = useState('');

    return (
        <>
            <label>
                Name: <input value={name} onChange={e => setName(e.target.value)} />
            </label>
            <label>
                Email: <input value={email} onChange={e => setEmail(e.target.value)} />
            </label>
            <label>
                X: <input value={x} onChange={e => setX(e.target.value)} />
            </label>
            <hr/>
            <EmployeeForm name={name}/>
        </>
    )
}