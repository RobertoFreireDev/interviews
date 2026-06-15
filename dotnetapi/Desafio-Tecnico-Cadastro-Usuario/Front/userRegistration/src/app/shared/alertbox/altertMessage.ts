export enum TypeAlert {
  Success = 'sucess',
  Error = 'error',
  Unknown = ''
}

export class MessageAlert {
  message : String;
  type : TypeAlert;
  active : Boolean;
}

export function GenerateMessageAlert(typeAlert : TypeAlert, message : string){
  const altert : MessageAlert = {
    message : message,
    active : true,
    type : TypeAlert.Unknown
  }
  if (typeAlert === TypeAlert.Success){
    altert.type = TypeAlert.Success;
  }
  else if (typeAlert === TypeAlert.Error)
  {
    altert.type =  TypeAlert.Error;
  }
  return altert;
}
