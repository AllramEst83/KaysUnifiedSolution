
import * as actionTypes from './actionTypes';
import unicornApi from '../api/unicornApi';

//Action creator
export function loadUnicornsSuccess(unicorns) {
    return { type: actionTypes.LOAD_UNICORNS_SUCCESS, unicorns: unicorns };
}

export function createUnicornSuccess(unicorn) {
    return { type: actionTypes.CREATE_UNICORN_SUCCESS, unicorn: unicorn }
}
export function updateUnicornSuccess(unicorn) {
    return { type: actionTypes.UPDATED_UNICORN_SUCCESS, unicorn: unicorn }
}
//unicornApi
export function loadUnicorns() {
    return function (dispatch) {
        return unicornApi.getAllAuthors().then(unicorns => {

            dispatch(loadUnicornsSuccess(unicorns));

        }).catch(error => {

            throw (error);

        });
    }
}

export function UpdateUnicorn(unicorn) {
    return function (dispatch, getState) {
        if (unicorn.Id) {
            return unicornApi.putUnicorn(unicorn).then(savedUnicorn => {
                dispatch(updateUnicornSuccess(unicorn));
            }).catch(error =>{
                throw error;
            });
        } else {
            return unicornApi.postUnicorn(unicorn).then(updatedUnicorn => {
                dispatch(createUnicornSuccess(unicorn));
            }).catch(error =>{
                throw error;
            });
        }

    }
}

// export function UpdateUnicorn(unicorn) {
//     return function (dispatch, getState) {
//         return unicornApi.putUnicorn(unicorn).then(savedUnicorn => {

//             unicorn.Id ? dispatch(updateUnicornSuccess(unicorn)) :

//                 dispatch(createUnicornSuccess(unicorn))

//         }).catch(error => {
//             throw error;
//         });
//     }
// }
