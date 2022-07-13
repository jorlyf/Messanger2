import useAppSelector from "../../hooks/useAppSelector";
import styles from "./RightColumnHeader.module.scss";

const RightColumnHeader: React.FC = () => {

  const currentChatDialog = useAppSelector(state => state.chat.currentChatDialog);

  return (
    <header className={styles.Main}>
      {currentChatDialog && <>{currentChatDialog.id}</>}
    </header>
  );
}

export default RightColumnHeader;
