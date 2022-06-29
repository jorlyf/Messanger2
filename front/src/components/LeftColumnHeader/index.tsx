import styles from "./LeftColumnHeader.module.scss";

const Header: React.FC = () => {
  return (
    <header className={styles.Main}>
      <div className={styles.Auth}>
        Войти
      </div>
    </header>
  );
}

export default Header;
