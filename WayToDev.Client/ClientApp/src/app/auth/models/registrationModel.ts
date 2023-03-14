export class RegistrationModel{
  email: string
  password: string
  userName?: string
  companyName?: string
  role: Role;
}

enum Role{
  User,
  Company
}
