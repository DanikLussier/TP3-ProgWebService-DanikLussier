import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MaterialModule } from '../material.module';
import { FormsModule } from '@angular/forms';
import { lastValueFrom } from 'rxjs';
import { HttpClient, HttpContext } from '@angular/common/http';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MaterialModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  domain : string = "https://localhost:7205/"

  hide = true;

  registerUsername : string = "";
  registerEmail : string = "";
  registerPassword : string = "";
  registerPasswordConfirm : string = "";

  loginUsername : string = "";
  loginPassword : string = "";

  constructor(public route : Router, public http: HttpClient) { }

  ngOnInit() {
  }

  async login() : Promise<void>{

    let LoginDTO = {
      username: this.loginUsername,
      password: this.loginPassword,
    }
    let x = await lastValueFrom(this.http.post<any>(this.domain + "api/Users/Login", LoginDTO));
    console.log(x)
    localStorage.setItem("token", x.token)

    // Redirection si la connexion a réussi :

    //this.route.navigate(["/play"]);
  }

  async register() : Promise<void> {
    let registerDTO = {
      username: this.registerUsername,
      email: this.registerEmail,
      password: this.registerPassword,
      passwordConfirm: this.registerPasswordConfirm
    };
    let x = await lastValueFrom(this.http.post<any>(this.domain + "api/Users/Register", registerDTO));
    console.log(x)
  }
  
}
