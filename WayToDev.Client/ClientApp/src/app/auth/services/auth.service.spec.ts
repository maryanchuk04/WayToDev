import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing";
import { TestBed } from "@angular/core/testing";
import { JwtHelperService, JwtModule } from "@auth0/angular-jwt";
import { environment } from "src/environments/environment";
import { AuthService } from "./auth.service"

describe("Authenticate tests", () => {
    let service: AuthService;
    let url: string = `${environment.basePath}/authenticate`
    let httpController: HttpTestingController;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientTestingModule, JwtModule.forRoot({
                config: {
                    tokenGetter: () => {
                        return '';
                    }
                }
            })],
            providers: [JwtHelperService]
        });
        service = TestBed.inject(AuthService);
        httpController = TestBed.inject(HttpTestingController);
    })

    it('should create the service', () => {
        //Assert
        expect(service).toBeTruthy();
    });

    it('should authenticate', ()=>{
            
    });
})