import IChatUser from "../../models/IChatUser";

import styles from "./UserList.module.scss";

export interface IItem {
  user: IChatUser;
  handleClick: () => void;
}

interface IUserListProps {
  items: IItem[];
}

const UserList: React.FC<IUserListProps> = ({ items }) => {
  return (
    <div className={styles.Main}>
      {items?.map(i => (
        <div key={i.user.id} onClick={i.handleClick} className={styles.Item}>
          <span>{i.user.login}</span>
        </div>
      ))}
    </div>
  )
}

export default UserList;
