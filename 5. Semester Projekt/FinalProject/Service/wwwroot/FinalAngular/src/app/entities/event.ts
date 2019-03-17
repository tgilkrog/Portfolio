export class Event {
  Id: number;
  Title: string;
  Description: string;
  Date: Date;
  CusId: number;

  constructor(title: string, description: string, date: Date, cusId: number) {
    this.Title = title;
    this.Description = description;
    this.Date = date;
    this.CusId = cusId;
  }
}
