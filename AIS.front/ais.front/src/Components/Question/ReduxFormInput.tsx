import React, { useMemo, useState } from 'react';
import { FormControl, Input, TextField } from '@mui/material';

const ReduxFormInput: React.FC = (field: any) => (
    <FormControl fullWidth>
        <TextField
            {...field.input}
            type={field.type}
            placeholder={field.placeHolder}
            defaultValue={field.defaultValue}
            value={field.externalValue}
            disabled={field.disabled}
        />
    </FormControl>
);

export default ReduxFormInput;