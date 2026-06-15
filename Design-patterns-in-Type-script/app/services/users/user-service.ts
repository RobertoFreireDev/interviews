import { UserModel } from '../../models/entities/user/user-model';

export class UserService {
    static instance : UserService;
    private users : Array<UserModel> = [
        new UserModel("João", 23),
        new UserModel("Maria", 22)
    ];

    constructor(){
        if (UserService.instance) {
            return UserService.instance;
        } 
        UserService.instance = this;
    }

    public getAll() : Array<UserModel> {
        return this.users;
    }

    public add(user : UserModel) : void {
        this.users.push(user);
    }
}