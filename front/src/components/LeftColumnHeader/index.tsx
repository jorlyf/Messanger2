import { Link } from "react-router-dom";
import useAppSelector from "../../hooks/useAppSelector";
import AuthService from "../../services/AuthService";
import BurgerMenu from "../BurgerMenu";

import styles from "./LeftColumnHeader.module.scss";

const Header: React.FC = () => {
  const isAuthorized = useAppSelector(state => state.auth.isAuthorized);
  const login = useAppSelector(state => state.auth.login);

  if (isAuthorized) {
    return (
      <header className={styles.Main}>
        <BurgerMenu items={[{ text: "Профиль", onClick: () => { } }, { text: "Выйти", onClick: AuthService.logout }]}
        />
        <img className={styles.UserAvatar} alt="" />
        <span className={styles.UserLogin}>{login}</span>
      </header>
    )
  }

  return (
    <header className={styles.Main}>
      <div className={styles.LoginLink}>
        <Link to="/auth" children="Войти" />
      </div>
    </header>
  );
}

export default Header;
