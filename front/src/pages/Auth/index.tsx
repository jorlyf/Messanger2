import React from "react";
import { useDispatch } from "react-redux";

import InputField from "../../components/InputField";
import { useTypedSelector } from "../../hooks";
import AuthService from "../../services/AuthService";

import styles from "./Auth.module.scss";

const Auth: React.FC = () => {
  const dispatch = useDispatch();

  const [login, setLogin] = React.useState<string>("");
  const [password, setPassword] = React.useState<string>("");

  const isAuthorized = useTypedSelector(state => state.auth.isAuthorized);

  const inputValidated = AuthService.validateInput(login, password);

  const onLogin = () => {
    AuthService.login(dispatch, login, password);
  }

  const onRegistration = () => {
    AuthService.registration(dispatch, login, password);
  }

  if (isAuthorized) {
    return (<>Вы уже в аккаунте</>);
  }

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
            placeholder="Пароль"
            value={password}
            dispatchFunction={setPassword}
            isOneRow={true}
          />
        </div>

        <div className={styles.Buttons}>
          <button onClick={onLogin}disabled={!inputValidated}>Войти</button>
          <button onClick={onRegistration} disabled={!inputValidated}>Зарегистрироваться</button>
        </div>

      </div>
    </div>
  );
}

export default Auth;
