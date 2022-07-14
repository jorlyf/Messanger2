import useAppSelector from "../../hooks/useAppSelector";
import ChatListItem from "./ChatListItem";

import styles from "./ChatList.module.scss";

const ChatList: React.FC = () => {
  const chatDialogs = useAppSelector(state => state.chat.chatDialogs);
  return (
    <div className={styles.Main}>
      {chatDialogs?.map(d => (
        <ChatListItem chatDialog={d} />
      ))}
    </div>
  );
}

export default ChatList;
