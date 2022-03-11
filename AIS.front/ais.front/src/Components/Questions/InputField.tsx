import React, { useMemo, useState } from 'react';
import { FormControl, TextField } from '@mui/material';
//import { debounce } from 'lodash';

interface InputFieldProps {
  type?: string,
  externalValue: string | number | boolean,
  fieldName: string,
  setExternalValue: (value: string | number | boolean, fieldName: string) => void,
  min?: number,
  max?: number,
  errorText?: string,
  onFocus?: () => void,
}
export const InputField: React.FC<InputFieldProps> = ({
  type = 'text', externalValue, fieldName, setExternalValue, min, max, errorText = "", onFocus = () => {},
}: InputFieldProps) => {

  const [inputValue, setInputValue] = useState(externalValue);


  //const delayedHandleChange = useMemo(() => debounce((value: string | number | boolean) => setExternalValue(value, fieldName), 500), [fieldName, setExternalValue]);

  const onChangeHandler = (value: string | number | boolean) => {
    let parsedValue;
    switch (type) {
      case 'number':
        parsedValue = +value;
        if (min !== undefined && +value < min) {
          parsedValue = min
        };
        if (max !== undefined && +value > max) parsedValue = max;
        break;
      default: parsedValue = value; break;
    }

    setInputValue(parsedValue);
    //delayedHandleChange(parsedValue);
  }
  return (
    <FormControl fullWidth >
      <TextField
        value={inputValue}
        onChange={(event) => onChangeHandler(event.target.value)}
        type={type}
        error={!!errorText}
        helperText={errorText}
        onFocus={onFocus}
      />
    </FormControl>
  );
}