import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription, timer } from 'rxjs';

import { UserService } from 'src/app/core/services/user/user.service';
import { UserModel } from 'src/app/shared/models/user/user-model';
import { TypeAlert, MessageAlert, GenerateMessageAlert } from '../../shared/alertbox/altertMessage';
import { ModalService } from 'src/app/shared/modal/modal.service';
import { ModalModel } from 'src/app/shared/models/modal/modal-model';
import { FormControl, FormGroup } from '@angular/forms';
import { UserFilterModel, ActiveFilterTypeEnum, FieldTypeEnum } from '../../shared/models/filters/userFilter-model';

@Component({
  selector: 'app-user-report',
  templateUrl: './user-report.component.html',
  styleUrls: ['./user-report.component.css']
})
export class UserReportComponent implements OnInit  {
  users : UserModel[] = [];
  activeOptions : string[] = [ActiveFilterTypeEnum.NO_FILTER,ActiveFilterTypeEnum.INACTIVE,ActiveFilterTypeEnum.ACTIVE];
  userSearchForm : FormGroup;
  deleteUserSubscription : Subscription;
  searchUserSubscription : Subscription;
  toggleActivationUserSubscription : Subscription;
  userEdited : UserModel;
  userToDelete : UserModel;
  modalDeleteUser : ModalModel = {
    title : "Remoção de usuário",
    text : "Deseja realmente excluir?",
    button : "Deletar"
  };
  isLoading : boolean = false;
  messageTimer = timer(2000);
  messageAlert : MessageAlert = {
    message : "",
    type : TypeAlert.Unknown,
    active : false
  }

  constructor(private router : Router,
              private userService: UserService,
              private modalService : ModalService) { }

  ngOnInit() {
    const getUserSubscription = this.userService.getUsers().subscribe(users => {
      this.users = users;
      getUserSubscription.unsubscribe();
    });

    this.userSearchForm = new FormGroup({
      'name' : new FormControl(''),
      'active' : new FormControl(ActiveFilterTypeEnum.NO_FILTER)
    });
  }

  searchUserByFilter() : void {
    const userSearch = this.userSearchForm.value;

    let userFilter : UserFilterModel = {
      Filters : []
    }

    if (userSearch.name.trim()) userFilter.Filters.push({  Field : FieldTypeEnum.NAME, Value : userSearch.name.trim() });
    if (userSearch.active != ActiveFilterTypeEnum.NO_FILTER) userFilter.Filters.push({  Field : FieldTypeEnum.ACTIVE, Value : userSearch.active });

    this.searchUserSubscription = this.userService.getUsersByFilter(userFilter).subscribe(users => {
      this.users = users;
    });
  }

  editUser(user : UserModel) : void {
    if (this.isLoading) return;
    this.router.navigate(["/user"],{
      state : {
        user : user
      }
    });
  }

  openModalToDeleteUser(user : UserModel) : void {
    if (this.isLoading) return;
    this.userToDelete = user;
    this.modalService.openModal.next();
  }

  confirmDeleteUser() : void {
    this.deleteUser();
  }

  deleteUser() : void {
    this.isLoading = true;
    this.deleteUserSubscription = this.userService.deleteUser(this.userToDelete.id).subscribe(this.deleteSuccessHandler, this.deleteErrorHandler);
  }

  private deleteSuccessHandler = () => {
    this.messageAlert = GenerateMessageAlert(TypeAlert.Success, "Usuário removido com sucesso!");
    if (this.deleteUserSubscription) this.deleteUserSubscription.unsubscribe();

    const subscribe = this.messageTimer.subscribe(() => {
      this.fadeOutAlertMessage();
      this.enableButtonsAgain();
      const getUserSubscription = this.userService.getUsers().subscribe(users => {
        this.users = users;
        getUserSubscription.unsubscribe();
      });
      subscribe.unsubscribe();
    });
  }

  private deleteErrorHandler = () => {
    this.messageAlert = GenerateMessageAlert(TypeAlert.Error, "Erro ao remover usuário!");
    if (this.deleteUserSubscription) this.deleteUserSubscription.unsubscribe();

    const subscribe = this.messageTimer.subscribe(() => {
      this.fadeOutAlertMessage();
      this.enableButtonsAgain();
      subscribe.unsubscribe();
    });
  }

  toggleActivationToUser(userId: string): void {
    this.isLoading = true;
    this.userEdited = this.users.find(user => user.id === userId);
    this.toggleActivationUserSubscription = this.userService.toggleActivationUser({
      id : this.userEdited.id,
      active : !this.userEdited.active
    }).subscribe(this.toggleActivationSuccessHandler, this.toggleActivationErrorHandler);
  }

  private toggleActivationSuccessHandler = () => {
    this.messageAlert = GenerateMessageAlert(TypeAlert.Success, "Usuário editado com sucesso!");
    if (this.toggleActivationUserSubscription) this.toggleActivationUserSubscription.unsubscribe();
    this.replaceActiveValueUserEdited(!this.userEdited.active);
    this.userEdited = null;
    const subscribe = this.messageTimer.subscribe(() => {
      this.fadeOutAlertMessage();
      this.enableButtonsAgain();
      subscribe.unsubscribe();
    });
  }

  private replaceActiveValueUserEdited(activeValue : boolean) : void {
    const userEditedIndex = this.users.findIndex(user => user.id === this.userEdited.id);
    this.users[userEditedIndex] = {
      ... this.users[userEditedIndex],
      active : activeValue
    };
  }

  private toggleActivationErrorHandler = () => {
    this.messageAlert = GenerateMessageAlert(TypeAlert.Error, "Erro ao editar usuário!");
    if (this.toggleActivationUserSubscription) this.toggleActivationUserSubscription.unsubscribe();
    this.replaceActiveValueUserEdited(this.userEdited.active);
    const subscribe = this.messageTimer.subscribe(() => {
      this.fadeOutAlertMessage();
      this.enableButtonsAgain();
      subscribe.unsubscribe();
    });
  }

  private fadeOutAlertMessage(){
    this.messageAlert.active = false;
  }

  private enableButtonsAgain(){
    this.isLoading = false;
  }

  getDate(dateString: string){
    const date = (new Date(dateString));
    return date.getDay() + "/" + date.getMonth() + "/" + date.getFullYear();
  }
}
