import useAppSelector from "../../hooks/useAppSelector";
import Search from "../Search";
import styles from "./RightColumnHeader.module.scss";

const RightColumnHeader: React.FC = () => {

  const isAuthorized = useAppSelector(state => state.auth.isAuthorized);
  const currentChatDialog = useAppSelector(state => state.chat.currentChatDialog);

  return (
    <header className={styles.Main}>
      {currentChatDialog && <>{currentChatDialog.id}</>}
      {isAuthorized && <Search />}
    </header>
  );
}

export default RightColumnHeader;
