export class Subscription {
    userID: number;
    customerID: Object;
    notification: boolean;

    constructor(userID: number, customerID: Object, notification: boolean){
        this.userID = userID;
        this.customerID = customerID;
        this.notification = notification;
    }
}
