import { useEffect } from "react";
import { useNavigate } from "react-router";
import UsernameChange from "../../components/UsernameChange";
import useAppSelector from "../../hooks/useAppSelector";
import styles from "./Main.module.scss";

const Chat: React.FC = () => {
  const isAuthorized = useAppSelector(state => state.auth.isAuthorized);
  const username = useAppSelector(state => state.chat.owner?.username);

  const navigate = useNavigate();

  useEffect(() => {
    if (!isAuthorized) { navigate("/auth"); }
  }, [isAuthorized, navigate]);

  if (!username) { // form to set username (a first time using)
    return (
      <UsernameChange />
    )
  }

  return (
    <div className={styles.Main}>
      
    </div>
  );
}

export default Chat;
