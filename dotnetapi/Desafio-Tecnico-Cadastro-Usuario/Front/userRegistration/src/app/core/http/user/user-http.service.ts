import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { UserModel } from 'src/app/shared/models/user/user-model';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserHttpService {
  rootPath = environment.apiUrl;

  constructor(private http : HttpClient) { }

  public getUsers() : Observable<any>{
    return this.http.get(this.rootPath + "/user/get");
  }

  public getUsersByFilter(userFilter) : Observable<any>{
    return this.http.post(this.rootPath + "/user/getusersbyfilter", userFilter);
  }

  public toggleActivationUser(user) : Observable<any>{
    return this.http.post(this.rootPath + "/user/toggleactivation", user);
  }

  public deleteUser(userId : string) : Observable<any>{
    return this.http.get(this.rootPath + "/user/delete?id=" + userId);
  }

  public editUser(user : UserModel) : Observable<any>{
    return this.http.post(this.rootPath + "/user/edit", user);
  }

  public addUser(user : UserModel) : Observable<any>{
    return this.http.post(this.rootPath + "/user/add", user);
  }
}
