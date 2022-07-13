import React from "react";
import { HttpTransportType, HubConnection, HubConnectionBuilder } from "@microsoft/signalr"
import useAppSelector from "./useAppSelector";

const buildConnection = (): HubConnection => {
  return new HubConnectionBuilder()
    .withUrl("/ChatHub", {
      skipNegotiation: true,
      transport: HttpTransportType.WebSockets
    })
    .withAutomaticReconnect()
    .build();
}

const useChatHub = () => {
  const isAuthorized = useAppSelector(state => state.auth.isAuthorized);
  const owner = useAppSelector(state => state.chat.owner);

  React.useEffect(() => {
    if (!isAuthorized) return;


  }, [isAuthorized]);
}

export default useChatHub;
