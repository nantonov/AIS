import { TypedUseSelectorHook, useSelector } from 'react-redux';
import { ApplicationState } from '../store/typing';

export const useTypedSelector: TypedUseSelectorHook<ApplicationState> = useSelector;
