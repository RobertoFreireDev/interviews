export class UserFilterModel {
  Filters : Filter[];
}

class Filter {
  Field : String;
  Value : String;
}

export enum ActiveFilterTypeEnum {
  NO_FILTER = "Sem filtro",
  INACTIVE = "Inativo",
  ACTIVE = "Ativo"
}

export enum FieldTypeEnum {
  ACTIVE = "Active",
  NAME = "Name"
}






