import IChatUser from "../../models/IChatUser";

import styles from "./UserList.module.scss";

const SearchResult: React.FC<{ items: IChatUser[] }> = ({ items }) => {
  return (
    <div className={styles.Main}>
      {items?.map(u => (
        <div key={u.id} className={styles.Item}>
          <span>{u.login}</span>
        </div>
      ))}
    </div>
  )
}

export default SearchResult;
