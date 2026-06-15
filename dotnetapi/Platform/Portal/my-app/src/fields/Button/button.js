import React from "react";
import './button.css';

function Button({ onClick, label, className, id }) {
  return (
    <button className={className || 'blue'} onClick={() => onClick(id)}>
      {label}
    </button>
  );
}

export default Button;