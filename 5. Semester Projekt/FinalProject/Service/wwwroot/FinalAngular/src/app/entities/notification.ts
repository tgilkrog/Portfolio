export class Notification {
  Id: number;
  UserId: number;
  NoteText: string;

  public constructor(public userId: number, public noteText: string) {
    this.UserId = userId;
    this.NoteText = noteText;
  }
}
