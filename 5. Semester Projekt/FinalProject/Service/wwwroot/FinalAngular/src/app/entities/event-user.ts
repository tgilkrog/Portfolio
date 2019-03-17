export class EventUser {
  EventId: number;
  UserId: number;

  constructor(eventId: number, userId: number) {
    this.EventId = eventId;
    this.UserId = userId;
  }
}
