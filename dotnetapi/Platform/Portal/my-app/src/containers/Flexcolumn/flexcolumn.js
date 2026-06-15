import React from 'react';
import PropTypes from 'prop-types';

const FlexColumn = ({ children, justifyContent, alignItems, gap, style }) => {
  const flexColumnStyle = {
    display: 'flex',
    flexDirection: 'column',
    justifyContent,
    alignItems,
    height: '100%',
    gap,
    ...style
  };

  return ( 
    <div style={flexColumnStyle}>
      {children}      
    </div>
  )
};

FlexColumn.propTypes = {
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
};

FlexColumn.defaultProps = {
  justifyContent: 'flex-start',
  alignItems: 'stretch',
};

export default FlexColumn;