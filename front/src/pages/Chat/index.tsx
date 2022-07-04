import styles from "./Main.module.scss";

interface IProps {
  chatId?: number;
}

const Chat: React.FC<IProps> = ({ chatId }) => {
  

  return (
    <div className={styles.Main}>
      chat
    </div>
  );
}

export default Chat;
