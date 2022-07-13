import React from "react";
import { useDispatch } from "react-redux";
import useAppSelector from "../../hooks/useAppSelector";
import UserProfileService from "../../services/UserProfileService";
import InputField from "../InputField";

import styles from "./UsernameChange.module.scss";

const UsernameChange: React.FC = () => {
  const dispatch = useDispatch();
  const username = useAppSelector(state => state.chat.owner?.username) || "";
  const [newUsername, setNewUsername] = React.useState(username);

  const onSubmit = () => {
    UserProfileService.changeUsername(dispatch, newUsername);
  }

  return (
    <div className={styles.Main}>
      <p>Введите новое имя:</p>
      <InputField
        value={newUsername}
        dispatchFunction={setNewUsername}
        placeholder={"Имя"}
        isOneRow={true}
      />
      <button onClick={onSubmit}>Сохранить</button>
    </div>
  )
}

export default UsernameChange;
