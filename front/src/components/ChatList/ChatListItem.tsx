interface IChatListItem {
  avatarUrl?: string;
  chatDialogName?: string;
  notificationsCount?: number;
}

const ChatListItem: React.FC<IChatListItem> = ({ avatarUrl, chatDialogName, notificationsCount }) => {
  return (
    <div>
      {avatarUrl && <img src={avatarUrl} alt="" />}
      {chatDialogName && <span>{chatDialogName}</span>}
    </div>
  );
}

export default ChatListItem;
