import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import * as unicornActions from '../../actions/unicornActions';
import { bindActionCreators } from 'redux';
import UnicornList from '../unicorn/unicornList';
import { browserHistory } from 'react-router';



class AddUnicorn extends React.Component {
    constructor(props, context) {
        super(props, context);

        //Initiate state
        this.state = {
            unicorn: {
                name: "",
                breed: "",
                origin: ""
            }
        };

        this.redirectToAddUicornsPage = this.redirectToAddUicornsPage.bind(this);
    }

    redirectToAddUicornsPage(){
        browserHistory.push('/unicorn');
    }

    render() {
        const { unicorns } = this.props;
        return (
            <div className="row">           
                <div className="listSpacing">
                    <UnicornList unicorns={unicorns} />
                    <input
                    type="submit"
                    value="Add Unicorn"
                    className="btn btn-primary"
                    onClick={this.redirectToAddUicornsPage}
                />
                </div>
            </div>
        );
    }

}

AddUnicorn.propTypes = {
    unicorns: PropTypes.array.isRequired,
    actions: PropTypes.object.isRequired
};

function mapStateToProps(state, ownProps) {
    return {
        unicorns: state.unicorns
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(unicornActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(AddUnicorn);