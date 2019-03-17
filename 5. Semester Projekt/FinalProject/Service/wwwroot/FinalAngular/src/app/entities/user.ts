export class User {
  Id: string;
  Username: string;
  Password: string;
  Email: string;
  CusId: string;

    constructor(username: string, password: string, email: string){
        this.Username = username;
        this.Password = password;
        this.Email = email;
    }
}
