import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as unicornActions from '../../actions/unicornActions';
import UnicornForm from '../unicorn/unicornForm';

class ManageUnicornPage extends React.Component {
    constructor(props, context) {
        super(props, context);
        this.state = {
            unicorn: Object.assign({}, props.unicorn),
            errors: {}
        };
        this.updateUnicornState = this.updateUnicornState.bind(this);
        this.updateUnicorn = this.updateUnicorn.bind(this);
    }

    updateUnicornState(event) {
        const { options, selectedIndex } = event.target;
        const field = event.target.name;
        const horntype = "horntype";

        let unicorn = Object.assign({}, this.state.unicorn);
        if (horntype == field) {
            unicorn[field].Id = event.target.value;
            unicorn[field].type = options[selectedIndex].innerHTML;
        } else {
            unicorn[field] = event.target.value;
        }
        return this.setState({ unicorn: unicorn });
    }
    updateUnicorn(event) {
        event.preventDefault();
        this.props.actions.UpdateUnicorn(this.state.unicorn).then(
            function (details) {
                //Redirect to '/unicorns' page
            },
            function (error) { /* handle failure */ }
        );

    }

    render() {
        return (
            <div>
                <h1>Manage Unicorn</h1>
                <UnicornForm
                    onSave={this.updateUnicorn}
                    onChange={this.updateUnicornState}
                    unicorn={this.state.unicorn}
                    errors={this.state.errors}
                    allHornTypes={this.props.hornTypes} />
            </div>
        );
    }
}

ManageUnicornPage.propTypes = {
    unicorn: PropTypes.object.isRequired,
    hornTypes: PropTypes.array.isRequired,
    actions: PropTypes.object.isRequired
};

function getUnicornById(unicorns, id) {
    const unicorn = unicorns.filter(unicorn => unicorn.Id == id);
    if (unicorn) return unicorn[0]; //since filter returns an array, have to grab the first.
    return null;
}

function mapStateToProps(state, ownProps) {
    const unicornId = ownProps.params.id;


    let unicorn = {
        Id: '',
        name: '',
        breed: '',
        description: '',
        origin: '',
        horntype: {
            Id: '',
            type: ''
        }
    };

    if (unicornId && state.unicorns.length > 0) {
        let unicornConatiner = getUnicornById(state.unicorns, unicornId);

        unicorn.Id = unicornConatiner.Id;
        unicorn.name = unicornConatiner.name;
        unicorn.breed = unicornConatiner.breed;
        unicorn.description = unicornConatiner.description;
        unicorn.origin = unicornConatiner.origin;
        unicorn.horntype.Id = unicornConatiner.horntype.Id;
        unicorn.horntype.type = unicornConatiner.horntype.type;

    }

    const hornTypesFormattedForDropDown = state.hornTypes.map(hornType => {
        return {
            value: hornType.Id,
            text: hornType.type
        };
    });

    return {
        unicorn: unicorn,
        hornTypes: hornTypesFormattedForDropDown
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(unicornActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(ManageUnicornPage);