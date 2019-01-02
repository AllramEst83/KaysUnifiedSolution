import * as actionTypes from '../actions/actionTypes';
import initialState from './initialState';

//Reducer
export default function unicornReducer(state = initialState.unicorns, action) {

    switch (action.type) {

        case actionTypes.LOAD_UNICORNS_SUCCESS:
            return action.unicorns;

            case actionTypes.CREATE_UNICORN_SUCCESS:
            return[
                ...state,
                Object.assign({}, action.unicorn)
            ];

            case actionTypes.UPDATED_UNICORN_SUCCESS:
            return[
                ...state.filter(unicorn => unicorn.Id !== action.unicorn.Id),
                Object.assign({},action.unicorn)
            ]
        default:
            return state;
    }
}