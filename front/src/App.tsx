import Main from "./pages/Main";
import ChatList from "./components/ChatList";
import LeftColumnHeader from "./components/LeftColumnHeader";
import RightColumnHeader from "./components/RightColumnHeader";

import styles from "./App.module.scss";

const App: React.FC = () => {
  return (
    <div className={styles.Main}>
      <div className={styles.LeftColumn}>
        <LeftColumnHeader />
        <ChatList />
      </div>

      <div className={styles.RightColumn}>
        <RightColumnHeader />
        <Main />
      </div>
    </div>
  );
}

export default App;
