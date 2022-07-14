import React from "react";

import styles from "./BurgerMenu.module.scss";

export interface IBurgerMenuItem {
  text: string;
  iconUrl?: string;
  onClick: () => void | undefined | Promise<void>;
}

const BurgerMenu: React.FC<{ items: IBurgerMenuItem[] }> = ({ items }) => {

  const [isIpen, setIsOpen] = React.useState<boolean>(false);

  return (
    <>
      <div onClick={() => setIsOpen(prev => !prev)} className={styles.Main}>
        <span />
      </div>

      {isIpen &&
        <div className={styles.Content}>
          {items?.map(e => (
            <div key={e.text} className={styles.Item}>
              {e.iconUrl && <img src={e.iconUrl} alt="" />}
              <span onClick={e.onClick} >{e.text}</span>
            </div>
          ))}
        </div>
      }
    </>
  )
}

export default BurgerMenu;
