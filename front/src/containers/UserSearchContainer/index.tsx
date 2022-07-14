import React from "react";
import Search from "../../components/Search";
import SearchResult from "../../components/UserList";
import useDebounce from "../../hooks/useDebounce";
//////////////\
import IChatUser from "../../models/IChatUser";
import ChatService from "../../services/ChatService";

const UserSearchContainer: React.FC = () => {
  const [login, setLogin] = React.useState("");
  const [users, setUsers] = React.useState<IChatUser[]>([]);

  const onChangeValue = (newValue: string) => {
    setLogin(newValue);
    searchUsers(newValue);
  }

  const searchUsers = useDebounce(async () => {
    const users: IChatUser[] = await ChatService.searchUsersByLogin(login);
    setUsers(users);
  }, 500);

  return (
    <>
      <Search
        value={login}
        dispatchFunction={onChangeValue}
        placeholder={"Введите логин"}
      />
      {users.length > 0 && <SearchResult items={users} />}
    </>
  )
}

export default UserSearchContainer;
