export const React = {
    createElement: (tag, props, ...children) => {
        return { tag, props : { ...props, children}};
    },
}

export const render = (reactElement, container) => {
    if (['string','number'].includes(typeof reactElement))
    {
        container.appendChild(document.createTextNode(reactElement));
        return;
    }

    if (typeof reactElement.tag === "function") {
        const childElement = reactElement.tag(reactElement.props);
        render(childElement, container);
        return;
    }

    const domElement = document.createElement(reactElement.tag);
    Object.keys(reactElement.props || [])
        .filter(p => p != 'children')
        .forEach(p => domElement[p] = reactElement.props[p]);
    (reactElement.props?.children || []).forEach(child => {
        render(child, domElement);
    });
    container.appendChild(domElement);
}

let rootContainer;
let rootElement;

export const createRoot = (container) => {
  rootContainer = container;
  return {
    render: function (reactElement) {
      rootElement = reactElement;
      reRenderFromRoot();
    },
  };
};

let states = [];
let stateCursor = 0;

const reRenderFromRoot = () =>
{   
    stateCursor = 0;
    if (rootContainer.firstChild)
    {
        rootContainer.firstChild.remove();
    }
    render(rootElement, rootContainer);
}

export const useState = (initialState) => {
    const FROZENCURSOR = stateCursor;
    states[FROZENCURSOR] = states[FROZENCURSOR] || initialState;

    let setState = (newState) => {
        if (typeof newState === "function") {
            states[FROZENCURSOR] = newState(states[FROZENCURSOR]);
        } else {
            states[FROZENCURSOR] = newState;
        }
        stateCursor++;
        reRenderFromRoot();
    };
    return [states[FROZENCURSOR],setState];
}