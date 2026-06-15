import React from 'react';
import { Button, Input, Dropdown, Table } from "../../fields/fields";

const ComponentSelector = ({ config, data, events }) => {
  const components = {
    Button: () => <Button 
                      label={config.label} 
                      className={config.className}
                      id={config.id}
                      onClick={events.handleOnClick}>
                    </Button>,
    Input: () => <Input 
                    placeholder={config.placeholder}
                    onInputChange={events.handleInputChange}
                    id={config.id}>                      
                  </Input>,
    Dropdown: () => <Dropdown
                    options={data.options}
                    id={config.id}
                    defaultOption={data.defaultOption || "Select an option"}
                    onSelect={events.handleDropdownOptionSelect}
                />,
    Table: () => <Table 
                    columns={data.columns} 
                    data={data.rows}
                    id={config.id} 
                    defaultPagination={config.defaultPagination || 10}
                    onDropdownChange={events.handleTableDropdownChange}/>
  };

  const Component = components[config.type];

  return <Component />;
};

export default ComponentSelector;