import React from "react";
import InputField from "../../components/InputField";

import styles from "./Auth.module.scss";

const Auth: React.FC = () => {

  const [login, setLogin] = React.useState<string>("");
  const [username, setUsername] = React.useState<string>("");
  const [password, setPassword] = React.useState<string>("");

  return (
    <div className={styles.Main}>
      <div className={styles.Container}>

        <div className={styles.Inputs}>
          <InputField
            placeholder="Логин для авторизации"
            value={login}
            dispatchFunction={setLogin}
            isOneRow={true}
          />

          <InputField
            placeholder="Имя"
            value={username}
            dispatchFunction={setUsername}
            isOneRow={true}
          />

          <InputField
            placeholder="Пароль"
            value={password}
            dispatchFunction={setPassword}
            isOneRow={true}
          />
        </div>

        <div className={styles.Buttons}>
          <button>Войти</button>
          <button>Зарегистрироваться</button>
        </div>

      </div>
    </div>
  );
}

export default Auth;
