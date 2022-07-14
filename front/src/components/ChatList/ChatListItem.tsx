import IChatDialog from "../../models/IChatDialog";

import styles from "./ChatList.module.scss";

interface IChatListItem {
  chatDialog: IChatDialog;
}

const ChatListItem: React.FC<IChatListItem> = ({ chatDialog }) => {
  return (
    <div key={chatDialog.id} className={styles.Item}>
      {chatDialog.avatarUrl && <img src={chatDialog.avatarUrl} alt="" />}
      {chatDialog.name && <span>{chatDialog.name}</span>}
    </div>
  );
}

export default ChatListItem;
