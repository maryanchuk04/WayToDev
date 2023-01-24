import {Injectable} from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class TokenService{
  private readonly TOKEN_KEY = "token";
  private readonly ROLE_KEY = "role";

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

  getToken(): string{
    let token = localStorage.getItem(this.TOKEN_KEY);
    if(token == undefined){
      throw Error("Token is not defined in localStorage");
    }

    return token;
  }
}
