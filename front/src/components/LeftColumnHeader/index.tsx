import { Link } from "react-router-dom";
import styles from "./LeftColumnHeader.module.scss";

const Header: React.FC = () => {
  return (
    <header className={styles.Main}>
      <div className={styles.Auth}>
        <Link to="/auth" children="Войти" />
      </div>
    </header>
  );
}

export default Header;
