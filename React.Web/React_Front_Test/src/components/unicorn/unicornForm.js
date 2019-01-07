import React from 'react';
import TextInput from '../common/TextInput';
import SelectInput from '../common/SelectInput';

const UnicornForm = ({ unicorn, allHornTypes, onSave, onChange, saving, errors, onClick,onDelete,deleteclassName, className }) => {
  return (
    <form>
      <TextInput
        name="name"
        label="name"
        value={unicorn.name}
        onChange={onChange}
        error={errors.name} />

      <SelectInput
        name="horntype"
        label="horntype"
        value={unicorn.horntype.Id}//<--Funkar inte--
        defaultOption="Select Horntype"
        options={allHornTypes}
        onChange={onChange} error={errors.Id} />

      <TextInput
        name="breed"
        label="breed"
        value={unicorn.breed}
        onChange={onChange}
        error={errors.breed} />

      <TextInput
        name="description"
        label="description"
        value={unicorn.description}
        onChange={onChange}
        error={errors.description} />

      <TextInput
        name="origin"
        label="origin"
        value={unicorn.origin}
        onChange={onChange}
        error={errors.origin} />

      <input
        type="submit"
        disabled={saving}
        value={saving ? 'Saving...' : 'Save'}
        className="btn btn-primary"
        onClick={onSave} />

      <input
        type="button"
        value="Back"
        className={className}
        onClick={onClick} />


      <input
        type="button"
        value="Delete"
        className={deleteclassName}
        onClick={onDelete} />

    </form>
  );
};

UnicornForm.propTypes = {
  unicorn: React.PropTypes.object.isRequired,
  allHornTypes: React.PropTypes.array,
  onSave: React.PropTypes.func.isRequired,
  onChange: React.PropTypes.func.isRequired,
  saving: React.PropTypes.bool,
  errors: React.PropTypes.object
};

export default UnicornForm;
