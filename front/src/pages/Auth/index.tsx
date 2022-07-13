import React from "react";
import { useDispatch } from "react-redux";

import InputField from "../../components/InputField";
import useAppSelector from "../../hooks/useAppSelector";
import AuthService from "../../services/AuthService";

import styles from "./Auth.module.scss";

const Auth: React.FC = () => {
  const dispatch = useDispatch();

  const [login, setLogin] = React.useState<string>("");
  const [password, setPassword] = React.useState<string>("");

  const isAuthorized = useAppSelector(state => state.auth.isAuthorized);
  const isLogging = useAppSelector(state => state.auth.isLogging);

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
            disabled={isLogging}
          />

          <InputField
            placeholder="Пароль"
            value={password}
            dispatchFunction={setPassword}
            isOneRow={true}
            disabled={isLogging}
          />
        </div>

        <div className={styles.Buttons}>
          <button onClick={onLogin} disabled={!inputValidated || isLogging}>Войти</button>
          <button onClick={onRegistration} disabled={!inputValidated || isLogging}>Зарегистрироваться</button>
        </div>

      </div>
    </div>
  );
}

export default Auth;
