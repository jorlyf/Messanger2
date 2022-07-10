import { Routes, Route } from "react-router-dom";

import ChatList from "./components/ChatList";
import LeftColumnHeader from "./components/LeftColumnHeader";
import RightColumnHeader from "./components/RightColumnHeader";

import MainContainer from "./containers/MainContainer";
import Chat from "./pages/Chat";
import Auth from "./pages/Auth";

import styles from "./App.module.scss";
import { useAppSelector, useAuth } from "./hooks";

const App: React.FC = () => {

  useAuth();

  const wasInitAuthAttempt = useAppSelector(state => state.auth.wasInitAuthAttempt);

  return (
    <div className={styles.Main}>
      {wasInitAuthAttempt &&
        <>
          <div className={styles.LeftColumn}>
            <LeftColumnHeader />
            <ChatList />
          </div>

          <div className={styles.RightColumn}>
            <RightColumnHeader />

            <MainContainer>
              <Routes>
                <Route path="/" element={<Chat />} />
                <Route path="/chat" element={<Chat />} />
                <Route path="/auth" element={<Auth />} />
              </Routes>
            </MainContainer>
          </div>
        </>
      }

    </div>
  );
}

export default App;
