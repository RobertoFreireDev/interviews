import React from 'react';

const Hidden = ({ children, isHidden }) => {
  if (isHidden) {
    return null;
  }

  return <>{children}</>;
};

export default Hidden;