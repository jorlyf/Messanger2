import Main from "./pages/Main";
import Header from "./components/Header";

import styles from "./App.module.scss";
import ChatList from "./components/ChatList";

const App: React.FC = () => {
  return (
    <div className={styles.Main}>
      <div className={styles.LeftColumn}>
        <Header />
        <ChatList />
      </div>

      <div className={styles.RightColumn}>
        <Main />
      </div>
    </div>
  );
}

export default App;
