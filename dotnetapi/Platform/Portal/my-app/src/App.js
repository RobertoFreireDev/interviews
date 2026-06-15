import React from "react";
import './App.css';
import { FieldManager } from './containers/containers';

function App() {
  //#region Button
  const handleOnClick = (id) => {
    console.log('Button id: ' + id);
  }
  //#endregion

  //#region Input
  const handleInputChange = ({ newValue, id }) => {
    console.log({ newValue, id });
  };
  //#endregion

  //#region Dropdown
  const options = [
    {
      label: "Option 1",
      value: "option1",
      children: [
        {
          label: "Suboption 1",
          value: "suboption1",
          children: [
            {
              label: "Suboption 1 A",
              value: "suboption1A"
            },
            {
              label: "Suboption 1 B",
              value: "suboption1B"
            }
          ]
        },
        {
          label: "Suboption 2",
          value: "suboption2",
          children: [
            {
              label: "Suboption 2 A",
              value: "suboption2A"
            }
          ]
        }
      ]
    },
    {
      label: "Option 2",
      value: "option2",
      children: [
        {
          label: "Suboption 3",
          value: "suboption3"
        },
        {
          label: "Suboption 4",
          value: "suboption4"
        }
      ]
    },
    {
      label: "Option 3",
      value: "option3"
    }
  ];

  const handleDropdownOptionSelect = ({option, id}) => {
    console.log({option, id});
  };
  //#endregion

  //#region Table
  const columns = [
    { Header: "Name", accessor: "name", minWidth: 100 },
    { Header: "Age", accessor: "age", minWidth: 100 },
    { Header: "Country", accessor: "country", minWidth: 100 },
    { Header: "Status" , accessor: "status" , minWidth: 150, 
      defaultOption : { value: "", label: "" },
      options : [
      { value: "pending", label: "Pending" },
      { value: "approved", label: "Approved" },
      { value: "rejected", label: "Rejected" }
    ]},
    { Header: "Active" , accessor: "active", minWidth: 130,
      defaultOption : { value: "false", label: "False" },
      options : [
      { value: "false", label: "False" },
      { value: "true", label: "True" }
    ]}
  ];

  const data = [
    { id : '5F8F8F81-81EE-4E73-7380-806E6E9B9B1D', name: "John", age: 21, country: "USA", status : "Approved", active : "False" },
    { id : 'CE242404-04A2-4236-367B-7BB1B1EFEFFA', name: "Alice", age: 30, country: "Canada", status : "Rejected", active : "" },
    { id : '255555F7-F7D7-4798-987E-7E5E5E7979E5', name: "Bob", age: 15, country: "UK", status : "", active : "True" },
    { id : 'AD3D3D8E-8E20-405A-5AFC-FCABAB232326', name: "Liam", age: 25, country: "USA", status : "Approved", active : "False" },
    { id : 'D4585874-74D0-40FB-FB6F-6F8181E7E706', name: "Emma", age: 26, country: "USA", status : "Rejected", active : "True" },
    { id : '8DEDED24-24A5-45C7-C7B8-B8B2B2E1E1CE', name: "Harper", age: 18, country: "USA", status : "", active : "True" },
    { id : '58787896-96A2-4212-125A-5A5A5A555531', name: "Noah", age: 25, country: "USA", status : "Approved", active : "True" },
    { id : 'C45E5ED2-D20B-4B6C-6C66-66D1D1AEAE8F', name: "Elijah", age: 27, country: "Canada", status : "Rejected", active : "True" },
    { id : '6E0D0DF3-F316-465A-5ABB-BB2D2D8B8BBB', name: "Charlotte", age: 11, country: "UK", status : "Approved", active : "True" },
    { id : 'C4000067-6722-421E-1E78-784949F1F1FD', name: "Theodore", age: 67, country: "USA", status : "Approved", active : "True" },
    { id : '4E8F8F4A-4AA0-40C0-C090-90FDFD34348A', name: "Olivia", age: 20, country: "Canada", status : "Rejected", active : "True" },
    { id : '26414144-44AA-4ABA-BAFD-FD81818C8CC1', name: "Amelia", age: 10, country: "USA", status : "Approved", active : "True" },
  ];

  const handleTableDropdownChange = ({ columnId, newValue, original, id}) => {
    console.log({ columnId, newValue, original, id });
  }
  //#endregion
  
  //#region Fields
  const fields = [
    {
      rowFields : [
        {
          metadata : {
            isHidden : false
          }, 
          config : {
            type : 'Button',
            label : 'Click',
            className: 'blue',
            id : '3297F0F2-35D3-4231-919D-1CFCF4035975'            
          },     
          data : {},
          events : {
            handleOnClick : handleOnClick
          }
        },
        {
          metadata : {
            isHidden : false
          }, 
          config : {
            type : 'Button',
            label : 'Cancel',
            className: 'red',
            id : '69AA3BA5-D51E-465E-8447-ECAA1939739A'
          },     
          data : {},
          events : {
            handleOnClick : handleOnClick
          }
        },
        {
          metadata : {
            isHidden : false
          }, 
          config : {
            type : 'Button',
            label : 'Save',
            className: 'green',            
            id : 'CE91A0F2-C5DC-412B-A77F-1CFCF403525B'
          },     
          data : {},
          events : {
            handleOnClick : handleOnClick
          }
        }
      ]  
    },
    {
      metadata : {
        isHidden : false
      }, 
      config : {
        type : 'Input',
        placeholder : 'Type here',
        id : '0E777786-86B3-43F2-F299-990606DBDB3D'
      },     
      data : {},
      events : {
        handleInputChange : handleInputChange
      }
    },
    {
      metadata : {
        isHidden : false
      }, 
      config : {
        type : 'Dropdown',
        id : '29202060-6015-450B-0BDC-DC4545C2C2B0'
      },     
      data : {
        options : options,
        defaultOption : 'Select an option'
      },
      events : {
        handleDropdownOptionSelect: handleDropdownOptionSelect
      }
    },
    {
      metadata : {
        isHidden : false
      }, 
      config : {
        type : 'Table',
        defaultPagination : 10,
        id : 'C0A3A385-85BB-4B6C-6C6C-6C7171555520'
      },     
      data : {
        rows : data,
        columns : columns
      },
      events : {
        handleTableDropdownChange: handleTableDropdownChange
      }
    }    
  ];
  //#endregion

  return (
    <FieldManager 
      fields={fields}>
    </FieldManager>
  );
}

export default App;
