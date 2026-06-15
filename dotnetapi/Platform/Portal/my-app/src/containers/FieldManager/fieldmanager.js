import React from 'react';
import { FlexRow, FlexColumn, Hidden } from '../containers';
import ComponentSelector from './componentselector';

const FieldManager = ({ 
    fields
}) => { 
    if (!fields || fields.length === 0) return;    

    return (
        <FlexColumn gap='1rem' style={{ margin: '20px' }}>
        {fields
            .map((field,i) => {
                if (field.rowFields){
                    return (
                        <FlexRow  key={i} justifyContent="flex-end" alignItems="stretch" gap='1rem' style={{ margin: '5px' }}>
                            {field.rowFields.map((rowField,j) => ( 
                                <Hidden isHidden={rowField.metadata.isHidden} key={j}> 
                                    <ComponentSelector 
                                        config={rowField.config} 
                                        data={rowField.data} 
                                        events={rowField.events}>
                                    </ComponentSelector>
                                </Hidden>))}                 
                        </FlexRow>     
                    )
                }
                return (
                    <Hidden isHidden={field.metadata.isHidden} key={i}>
                        <ComponentSelector 
                            config={field.config} 
                            data={field.data} 
                            events={field.events}>
                        </ComponentSelector>
                    </Hidden>
                )
            })
        }
        </FlexColumn>
    )
};

export default FieldManager;