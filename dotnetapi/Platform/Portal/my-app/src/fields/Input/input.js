import React, { useState } from "react";
import "./input.css";

function Input({ type, placeholder, value, onInputChange, className, id }) {
  const [inputValue, setInputValue] = useState(value);
  const [timeoutId, setTimeoutId] = useState(null);

  const debounceTime = 500;

  const handleInputChange = (event) => {
    const newValue = event.target.value;
    setInputValue(newValue);

    clearTimeout(timeoutId);
    const newTimeoutId = setTimeout(() => {
      onInputChange({ newValue, id });
    }, debounceTime);
    setTimeoutId(newTimeoutId);
  };

  return (
    <input
      className={className}
      type={type}
      placeholder={placeholder}
      value={value}
      onChange={handleInputChange}
    />
  );
}

export default Input;