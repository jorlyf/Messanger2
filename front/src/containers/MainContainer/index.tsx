import styles from "./MainContainer.module.scss";

interface IMainContainerProps {
  children: React.ReactNode;
}

const MainContainer: React.FC<IMainContainerProps> = ({ children }) => {
  return (
    <div className={styles.Main}>
      {children}
    </div>
  )
}

export default MainContainer;
