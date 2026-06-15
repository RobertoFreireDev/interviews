function MyDiv({children}) {
    return (
        <div>
            {children}
        </div>
    );
}

export default function Greeting() {
    return (
        <MyDiv>
            <>
                <span>Hello</span>
                <span> World</span>
            </>            
        </MyDiv>
    );
}
