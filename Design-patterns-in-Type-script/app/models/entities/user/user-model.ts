import { UserRoleEnum } from '../../../enums/userRoleEnum';
import { EntityModel } from '../../entities/entity-model';
export class UserModel extends EntityModel {
    name : string;
    age : number;
    role : UserRoleEnum;

    constructor(name : string, age : number, role = UserRoleEnum.USER) {
        super();
        this.name = name;
        this.age = age;
        this.role = role;
    }
}