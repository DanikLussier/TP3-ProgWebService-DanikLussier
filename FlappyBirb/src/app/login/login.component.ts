import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MaterialModule } from '../material.module';
import { FormsModule } from '@angular/forms';
import { lastValueFrom } from 'rxjs';
import { HttpClient, HttpContext } from '@angular/common/http';
import { FlappyBirbServiceService } from '../services/flappy-birb-service.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MaterialModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  hide = true;

  registerUsername : string = "";
  registerEmail : string = "";
  registerPassword : string = "";
  registerPasswordConfirm : string = "";

  loginUsername : string = "";
  loginPassword : string = "";

  constructor(public flappyBirb : FlappyBirbServiceService) { }

  ngOnInit() {
  }

  login() {
    this.flappyBirb.login(this.loginUsername, this.loginPassword)
  }

  register() {
    this.flappyBirb.register(
      this.registerUsername,
      this.registerEmail,
      this.registerPassword,
      this.registerPasswordConfirm
    )
  }
  
}
