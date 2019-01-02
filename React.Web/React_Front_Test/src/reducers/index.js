import { combineReducers } from 'redux';
import unicorns from './unicornReducer';
import hornTypes from './hornTypeReducer';
const rootReducers = combineReducers({
    unicorns,
    hornTypes
});

export default rootReducers;