import React from "react";

const useDebounce = (callback: (...args: any) => void, delay: number) => {
  const timer = React.useRef<any>(null);

  const debouncedCallback = React.useCallback((...args: any) => {
    if (timer.current) {
      clearTimeout(timer.current);
    }

    timer.current = setTimeout(() => {
      callback(...args);
    }, delay);

  }, [callback, delay]);

  return debouncedCallback;
}

export default useDebounce;
