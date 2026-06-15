# Worker

JavaScript runs is single-threaded, meaning the main JS execution runs on one thread (the main thread). This thread is also responsible for rendering the UI. If you run heavy code on the main thread, the UI freezes. However, using Worker, you can run JavaScript in another thread in the browser.

```js
const worker = new Worker("worker.js")

worker.postMessage(1000000000)

worker.onmessage = (e) => {
  console.log("Result:", e.data)
}
```

# Event Loop (Pseudo Concurrency)

Even though JS is single-threaded, async APIs make it look concurrent. Because async tasks run in the browser APIs, then come back to the event loop queue.

Event loop order:

```
Call Stack
   ↓
Microtasks (Promises)
   ↓
Macrotasks (setTimeout, setInterval)
```