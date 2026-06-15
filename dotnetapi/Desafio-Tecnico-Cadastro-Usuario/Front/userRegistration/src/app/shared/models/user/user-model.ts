export class UserModel {
  id : string;
  name : string;
  birthDate : Date;
  email: string;
  password : string;
  gender : Gender;
  active : boolean;
}

export enum Gender {
  Male = 'Masculino',
  Female = 'Feminino'
}
