import styles from "./MainContainer.module.scss";

interface IProps {
  children: React.ReactNode;
}

const MainContainer: React.FC<IProps> = ({ children }) => {
  return (
    <div className={styles.Main}>
      {children}
    </div>
  )
}

export default MainContainer;
