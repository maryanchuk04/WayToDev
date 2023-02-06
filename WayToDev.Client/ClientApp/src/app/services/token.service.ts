import {Injectable} from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class TokenService{
  private readonly TOKEN_KEY = "token";
  private readonly ROLE_KEY = "role";
  private readonly USER_ID_KEY = "userId";

  setToken(token: string){
    localStorage.removeItem(this.TOKEN_KEY);
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  setAuthData(data: { token: string, role: number} ){
    localStorage.removeItem(this.ROLE_KEY);
    localStorage.removeItem(this.TOKEN_KEY);

    localStorage.setItem(this.TOKEN_KEY, data.token);
    localStorage.setItem(this.ROLE_KEY, data.role.toString());
  }

  setUserAuthData(data: { token: string, role: number, id: string} ){
    localStorage.removeItem(this.ROLE_KEY);
    localStorage.removeItem(this.TOKEN_KEY);
    localStorage.removeItem(this.USER_ID_KEY);

    localStorage.setItem(this.TOKEN_KEY, data.token);
    localStorage.setItem(this.ROLE_KEY, data.role.toString());
    localStorage.setItem(this.USER_ID_KEY, data.id);
  }

  getToken(): string{
    let token = localStorage.getItem(this.TOKEN_KEY);
    if(token == undefined){
      throw Error("Token is not defined in localStorage");
    }

    return token;
  }

  getUserId(): string{
    let userId = localStorage.getItem(this.USER_ID_KEY);
    if(!userId){
      throw Error("User id not found");
    }

    return userId;
  }
}
