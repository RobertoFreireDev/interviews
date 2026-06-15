import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { UserModel } from '../../../shared/models/user/user-model';
import { UserHttpService } from '../../http/user/user-http.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private userHttpService : UserHttpService) {
  }

  public getUsers() : Observable<UserModel[]>{
    return this.userHttpService.getUsers();
  }

  public getUsersByFilter(userFilter) : Observable<UserModel[]>{
    return this.userHttpService.getUsersByFilter(userFilter);
  }

  public toggleActivationUser(user) : Observable<void>{
    return this.userHttpService.toggleActivationUser(user);
  }

  public deleteUser(userId : string) : Observable<Boolean>{
    return this.userHttpService.deleteUser(userId);
  }

  public editUser(user : UserModel) : Observable<UserModel>{
    return this.userHttpService.editUser(user);
  }

  public addUser(user : UserModel) : Observable<UserModel>{
    user.active = true;
    return this.userHttpService.addUser(user);
  }
}
