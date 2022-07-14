import InputField from "../InputField";

interface ISearchProps {
  value: string;
  dispatchFunction: (value: string) => void;
  placeholder?: string;
}

const Search: React.FC<ISearchProps> = ({ value, dispatchFunction, placeholder }) => {
  return (
    <InputField
      value={value}
      dispatchFunction={dispatchFunction}
      placeholder={placeholder}
      isOneRow={true}
    />
  )
}

export default Search;