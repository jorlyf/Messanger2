import { Routes, Route } from "react-router-dom";
//////////////\
import MainContainer from "./containers/MainContainer";
import ChatList from "./components/ChatList";
import LeftColumnHeader from "./components/LeftColumnHeader";
import RightColumnHeader from "./components/RightColumnHeader";
//////////////\
import useAppSelector from "./hooks/useAppSelector";
import useAuth from "./hooks/useAuth";
import useChatHub from "./hooks/useChatHub";
//////////////\
import Chat from "./pages/Chat";
import Auth from "./pages/Auth";
//////////////\
import styles from "./App.module.scss";

const App: React.FC = () => {

  useAuth();
  useChatHub();

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
                <Route path="/auth" element={<Auth />} />
                <Route path="*"  element={<Chat />} />
              </Routes>
            </MainContainer>
          </div>
        </>
      }

    </div>
  );
}

export default App;
