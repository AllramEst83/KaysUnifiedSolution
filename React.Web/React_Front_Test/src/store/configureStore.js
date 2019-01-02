import { createStore, applyMiddleware } from 'redux';
import rootreducer from '../reducers';
import reduxImmutbleStateInvariant from 'redux-immutable-state-invariant';
import thunk from 'redux-thunk';
import { composeWithDevTools } from 'redux-devtools-extension';

export default function configureStore(initialState) {
    return createStore(
        rootreducer,
        initialState,
        composeWithDevTools(applyMiddleware(thunk,reduxImmutbleStateInvariant()))
      
    );
    
}
