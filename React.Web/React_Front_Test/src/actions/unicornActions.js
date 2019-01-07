
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
export function deleteUnicornSuccess(unicorn) {
    return { type: actionTypes.DELETE_UNICORN_SUCCESS, unicorn: unicorn }
}


export function loadUnicorns() {
    return dispatch => {
        return unicornApi.getAllAuthors().then(unicorns => {

            dispatch(loadUnicornsSuccess(unicorns));

        }).catch(error => {

            throw (error);

        });
    }
}

export function UpdateUnicorn(unicorn) {



    return dispatch => {
        if (unicorn.Id) {



            return unicornApi.putUnicorn(unicorn).then(updatedUnicorn => {
                //These are needed for React to be able to detect chages to the unicorn object
                unicorn.IsSold = false;
                unicorn.IsDeleted = false;

                dispatch(updateUnicornSuccess(unicorn));
            }).catch(error => {
                throw error;
            });
        } else {
            return unicornApi.postUnicorn(unicorn).then(savedUnicorn => {
                //Not optimal way. Try modifing API!!
                let idKey = "id";
                let isDeletedKey = "isDeleted";
                let isSoldKey = "isSold";

                let IsSold = savedUnicorn[isSoldKey];
                let IsDeleted = savedUnicorn[isDeletedKey];
                let Id = savedUnicorn[idKey];

                savedUnicorn["IsDeleted"] = IsDeleted;
                savedUnicorn["IsSold"] = IsSold;
                savedUnicorn["Id"] = Id

                delete savedUnicorn[idKey];
                delete savedUnicorn[isDeletedKey];
                delete savedUnicorn[isSoldKey];
                //Not optimal way. Modifing API!!

                dispatch(createUnicornSuccess(savedUnicorn));

            }).catch(error => {
                throw error;
            });
        }

    }
}

export function DeleteUnicorn(unicorn) {
    return dispatch => {
        if (unicorn.Id) {
            return unicornApi.DeleteUnicorn(unicorn).then(deletedUnicorn => {
                dispatch(deleteUnicornSuccess(unicorn));
            });
        }
    }
}

