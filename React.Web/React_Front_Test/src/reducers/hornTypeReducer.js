import * as actionTypes from '../actions/actionTypes';
import initialState from './initialState';

//Reducer
export default function unicornReducer(state = initialState.hornTypes, action) {

    switch (action.type) {

            case actionTypes.LOAD_HORNTYPES_SUCCES:
            return action.hornTypes;
        default:
            return state;
    }
}