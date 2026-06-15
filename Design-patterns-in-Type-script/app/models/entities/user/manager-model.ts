import { RegionEnum } from '../../../enums/regionEnum';
import { UserRoleEnum } from '../../../enums/userRoleEnum';
import { UserModel } from './user-model';

export class ManagerModel extends UserModel {
    private region : RegionEnum;

    public get Region(){
        return this.region;
    }

    constructor(name, age, region : RegionEnum, role : UserRoleEnum)  {
        super(name, age, role);
        this.region = region;
    }
}