import { createSlice, PayloadAction } from "@reduxjs/toolkit";
///////////////////////////////////////////////
import IChatOwner from "../../models/IChatOwner";
import IChatDialog from "../../models/IChatDialog";

interface IChatState {
  owner: IChatOwner | null;
  currentChatDialog: IChatDialog | null;
  chatDialogs: IChatDialog[];
  isReadyForChatting: boolean;
  isConnectedChatHub: boolean;
}

const initialState: IChatState = {
  owner: null,
  currentChatDialog: null,
  chatDialogs: [],
  isReadyForChatting: false,
  isConnectedChatHub: false
}

const chatSlice = createSlice({
  name: "chat",
  initialState,
  reducers: {
    setOwnerUser(state, action: PayloadAction<{ id: number, login: string, username?: string, avatarUrl?: string }>) {
      state.owner = {
        id: action.payload.id,
        login: action.payload.login,
        username: action.payload.username,
        avatarUrl: action.payload.avatarUrl
      };
    },
    setUsername(state, action: PayloadAction<string>) {
      if (state.owner === null) return;
      state.owner.username = action.payload;
    },
    setAvatarUrl(state, action: PayloadAction<string>) {
      if (state.owner === null) return;
      state.owner.avatarUrl = action.payload;
    },
    setCurrentChatDialog(state, action: PayloadAction<IChatDialog>) {
      state.currentChatDialog = action.payload;
    },
    setChatDialogs(state, action: PayloadAction<IChatDialog[]>) {
      state.chatDialogs = action.payload;
    },
    addChatDialog(state, action: PayloadAction<IChatDialog>) {
      state.chatDialogs.push(action.payload);
    },
    removeChatDialog(state, action: PayloadAction<IChatDialog>) {
      state.chatDialogs.filter(d => d.id !== action.payload.id);
    },
    setIsConnectedChatHub(state, action: PayloadAction<boolean>) {
      state.isConnectedChatHub = action.payload;
    }
  }
});

export const {
  setOwnerUser,
  setUsername,
  setAvatarUrl,
  setCurrentChatDialog,
  setChatDialogs,
  addChatDialog,
  removeChatDialog,
  setIsConnectedChatHub
} = chatSlice.actions;

export default chatSlice.reducer;
