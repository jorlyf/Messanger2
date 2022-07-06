export const trimString = (value: string) => {
  return value.trim().replace(/  +/g, ' ').replace(/\n\s*\n\s*\n/g, '\n\n');
}