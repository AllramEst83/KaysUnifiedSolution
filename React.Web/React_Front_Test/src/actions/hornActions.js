
import * as actionTypes from './actionTypes';
import unicornApi from '../api/unicornApi';


export function loadHornTypesSuccess(hornTypes) {
    return { type: actionTypes.LOAD_HORNTYPES_SUCCES, hornTypes: hornTypes };
}


export function loadHornTypes() {
    return function (dispatch) {
        return unicornApi.getAllHornTypes().then(hornTypes => {

            dispatch(loadHornTypesSuccess(hornTypes));

        }).catch(error => {

            throw (error);
            
        });
    }
}