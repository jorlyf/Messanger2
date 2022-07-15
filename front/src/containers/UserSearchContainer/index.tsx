import React from "react";
import Search from "../../components/Search";
import UserList, { IItem } from "../../components/UserList";
import useDebounce from "../../hooks/useDebounce";
import ChatService from "../../services/ChatService";
import IChatUser from "../../models/IChatUser";

import styles from "./UserSearchContainer.module.scss";

const UserSearchContainer: React.FC = () => {
  const [login, setLogin] = React.useState("");
  const [users, setUsers] = React.useState<IChatUser[]>([]);

  const getUserListItems = React.useCallback((): IItem[] => {
    const items: IItem[] = [];
    users.forEach(u => {
      items.push({ user: u, handleClick: () => "" });
    });
    return items;
  }, [users]);

  const handleChangeValue = (newValue: string) => {
    setLogin(newValue);
    searchUsers(newValue);
  }

  const searchUsers = useDebounce(async (login) => {
    const users: IChatUser[] = await ChatService.searchUsersByContainsLogin(login);
    setUsers(users);
  }, 250);

  return (
    <div className={styles.Main}>
      <div className={styles.Search}>
        <Search
          value={login}
          dispatchFunction={handleChangeValue}
          placeholder={"Введите логин"}
        />
      </div>
      {users.length > 0 &&
        <div className={styles.SearchResult}>
          <UserList items={getUserListItems()} />
        </div>
      }
    </div>
  )
}

export default UserSearchContainer;
