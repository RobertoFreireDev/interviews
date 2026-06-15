import React from 'react';
import PropTypes from 'prop-types';

const FlexRow = ({ children, justifyContent, alignItems, gap, style }) => {
  const flexRowStyle = {
    display: 'flex',
    flexDirection: 'row',
    justifyContent,
    alignItems,
    gap,
    ...style
  };

  return ( 
    <div
      style={flexRowStyle}
    >
      {children}      
    </div>
  )
};

FlexRow.propTypes = {
  children: PropTypes.node.isRequired,
  justifyContent: PropTypes.oneOf([
    'flex-start',
    'flex-end',
    'center',
    'space-between',
    'space-around',
    'space-evenly',
  ]),
  alignItems: PropTypes.oneOf([
    'stretch',
    'flex-start',
    'flex-end',
    'center',
    'baseline',
  ]),
  gap: PropTypes.string
};

FlexRow.defaultProps = {
  justifyContent: 'flex-start',
  alignItems: 'stretch',
  gap: '0'
};

export default FlexRow;