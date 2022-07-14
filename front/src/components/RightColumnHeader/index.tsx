import UserSearchContainer from "../../containers/UserSearchContainer";
import useAppSelector from "../../hooks/useAppSelector";

import styles from "./RightColumnHeader.module.scss";

const RightColumnHeader: React.FC = () => {

  const isAuthorized = useAppSelector(state => state.auth.isAuthorized);
  const currentChatDialog = useAppSelector(state => state.chat.currentChatDialog);

  return (
    <header className={styles.Main}>
      {currentChatDialog && <>{currentChatDialog.id}</>}
      {isAuthorized &&
        <div className={styles.UserSearch}>
          <UserSearchContainer />
        </div>
      }
    </header>
  );
}

export default RightColumnHeader;
