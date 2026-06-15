import React, { useState, useEffect, useRef } from "react";
import "./dropdown.css";

function Dropdown({ options, defaultOption, onSelect, id  }) {
  const [isOpen, setIsOpen] = useState(false);
  const [selectedOption, setSelectedOption] = useState(defaultOption);
  const dropdownRef = useRef(null);

  const handleOptionClick = (option) => {
    onSelect({ option, id });
    setSelectedOption(option.label);
    setIsOpen(false);
  };

  const handleClickOutside = (event) => {
    if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
      setIsOpen(false);
    }
  };

  useEffect(() => {
    document.addEventListener('click', handleClickOutside, true);
    return () => {
      document.removeEventListener('click', handleClickOutside, true);
    };
  }, []);

  const renderOptions = (options, level = 0) => {
    return options.map((option, index) => {      
        return (
            <div key={index}>            
            <div className="dropdown__option-group">
                <div 
                    className="dropdown__option"
                    onClick={() => handleOptionClick(option)}
                    style={{ paddingLeft : level * 3 + 'rem' }}>
                    {option.label}
                </div>
            </div>
            {option.children && renderOptions(option.children, level + 1)}
            </div>
        );
    });
  };  

  return (
    <div className="dropdown">
      <div className="dropdown__toggle" onClick={() => setIsOpen(!isOpen)}>
        <div className="dropdown__selected">{selectedOption}</div>
      </div>
      {isOpen && <div ref={dropdownRef} className="dropdown__options">{renderOptions(options)}</div>}
    </div>
  );
}

export default Dropdown;
