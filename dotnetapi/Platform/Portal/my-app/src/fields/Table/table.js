import React from 'react';
import { useTable, useSortBy, usePagination } from 'react-table';
import "./table.css";
import Select from "react-select";

function Table({ columns, data, onDropdownChange, defaultPagination, id }) {
  const pageSize = defaultPagination || 10;

  const defaultColumn = {
    height: 40
  };

  const { 
    getTableProps, 
    getTableBodyProps, 
    headerGroups, 
    page,
    nextPage,
    previousPage,
    canPreviousPage,
    canNextPage,
    pageOptions,
    state: { pageIndex },
    rows, 
    prepareRow 
  } = useTable({ 
    columns, 
    data,
    initialState: { pageIndex: 0, pageSize: pageSize }
  }, useSortBy, usePagination);

  const columnWithOptions = columns.filter(column => column.options);
  const options = {};

  for (let i in columnWithOptions) {
    options[columnWithOptions[i].accessor] = { 
      options : columnWithOptions[i].options,
      defaultOption : { 
        value: columnWithOptions[i].defaultOption.value, 
        label: columnWithOptions[i].defaultOption.label
      }
    };
  }

  return (
    <div className='table-container'>
      <table {...getTableProps()}>
        <thead>
          {headerGroups.map(headerGroup => (
            <tr {...headerGroup.getHeaderGroupProps()}>
              {headerGroup.headers.map(column => (
                <th {...column.getHeaderProps(column.getSortByToggleProps())}>
                  {column.render('Header')}
                  <span>
                    {column.isSorted ? (column.isSortedDesc ? ' ▼' : '  ▲') : ' '}
                  </span>
                </th>
              ))}
            </tr>
          ))}
        </thead>
        <tbody {...getTableBodyProps()}>
          {page.map(row => {
            prepareRow(row);
            return (
              <tr {...row.getRowProps()}>
                {row.cells.map(cell => (
                    <td {...cell.getCellProps()} style={{ height: defaultColumn.height || 'auto' }}>
                      {cell.value !== undefined && Object.keys(options).includes(cell.column.id) ? (
                        <Select styles={{ zIndex : '99'}}
                          defaultValue={
                            cell.value 
                            ?  {value: cell.value, label: cell.value}
                            : options[cell.column.id].defaultOption.value
                            ? { 
                              value: options[cell.column.id].defaultOption.value, 
                              label: options[cell.column.id].defaultOption.label
                            }
                            : "Select a value"
                          }                          
                          options={options[cell.column.id].options}
                          onChange={selectedOption =>
                            onDropdownChange(
                              {
                                columnId : cell.column.id,
                                original : cell.row.original,
                                newValue : { 
                                  value : selectedOption.value, 
                                  label : selectedOption.label 
                                },
                                id
                              }
                            )                         
                          }
                        />
                      ) : (
                        cell.render("Cell")
                      )}
                    </td>
                ))}
              </tr>
            );
          })}
        </tbody>
      </table>
      <div className="pagination">
        <button onClick={() => previousPage()} disabled={!canPreviousPage} className={canPreviousPage ? '' : 'disabled'}>
          {'<'}
        </button>
        <div className="content">
          <strong>
            &nbsp;{rows.length}
          </strong>
          &nbsp;rows.&nbsp;Page&nbsp;  
          <strong>
            {pageIndex + 1} of {pageOptions.length}&nbsp;
          </strong>
        </div>
        <button onClick={() => nextPage()} disabled={!canNextPage} className={canNextPage ? '' : 'disabled'}>
          {'>'}
        </button>
      </div>
    </div>
  );
}

export default Table;
