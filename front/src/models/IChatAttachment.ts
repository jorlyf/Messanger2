export default interface IChatAttachment {
  type: AttachmentTypes;
  url: string;
}

export enum AttachmentTypes {
  photo = 0,
  video = 1,
  audio = 2
}