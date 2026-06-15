import { useState } from "react"
import { createRoot } from "react-dom/client"

function App() {
  const [count, setCount] = useState(0)

  return (
    <div>
      <h1>Real React</h1>
      <p>Count: {count}</p>
      <button onClick={() => setCount(c => c + 1)}>
        Increment
      </button>
    </div>
  )
}

const root = createRoot(document.getElementById("root")!)
root.render(<App/>)