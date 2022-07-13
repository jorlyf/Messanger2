import React from "react";

import styles from "./BurgerMenu.module.scss";

export interface IBurgerMenuItem {
  text?: string;
  iconUrl?: string;
  onClick?: () => void | undefined | Promise<void>;
}

const BurgerMenu: React.FC<{ items: IBurgerMenuItem[] }> = ({ items }) => {

  const [isIpen, setIsOpen] = React.useState<boolean>(false);

  const getInlineStyleForSpan = (item: IBurgerMenuItem) => {
    if (item.onClick) { return { cursor: "pointer" } }
    else return {}
  }

  return (
    <>
      <button onClick={() => setIsOpen(prev => !prev)} className={styles.Main}>
      </button>

      {isIpen &&
        <div className={styles.Content}>
          {items?.map(e => (
            <div className={styles.Item}>
              {e.iconUrl && <img src={e.iconUrl} alt="" />}
              {e.text && <span onClick={e.onClick} style={getInlineStyleForSpan(e)} >{e.text}</span>}
            </div>
          ))}
        </div>
      }
    </>
  )
}

export default BurgerMenu;
