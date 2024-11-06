import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { Score } from '../models/score';

@Injectable({
  providedIn: 'root'
})
export class FlappyBirbServiceService {
  
   domain : string = "https://localhost:7205/"

  constructor(public http: HttpClient, public route : Router) { }

  async postScore() : Promise<void>{

    let token = localStorage.getItem("token")
    let httpOptions = {
      headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
      })
    }

    let scoreDTO = {
      value: JSON.parse(sessionStorage.getItem("score")!),
      time: JSON.parse(sessionStorage.getItem("time")!)
    }
    
    let x = await lastValueFrom(this.http.post<any>(this.domain + "api/Scores/PostScore", scoreDTO, httpOptions));
      console.log(x)

  }

  async getPrivateScores() : Promise<Array<Score>>{
    let token = localStorage.getItem("token")
    let httpOptions = {
      headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
      })
    }

    let scores = new Array<Score>

    let x = await lastValueFrom(this.http.get<Array<Score>>(this.domain + "api/Scores/GetMyScores", httpOptions)).then((x) => {
      scores = x
    }).catch((err) => {
      console.log(err)
    });

    console.log(scores)

    return scores
  }

  async getPublicScores() : Promise<Array<Score>>{

    let token = localStorage.getItem("token")
    let httpOptions = {
      headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
      })
    }

    let scores = new Array<Score>

    let x = await lastValueFrom(this.http.get<Array<Score>>(this.domain + "api/Scores/GetPublicScores", httpOptions)).then((x) => {
      scores = x
    }).catch((err) => {
      console.log(err)
    });

    console.log(scores)

    return scores
  }

  async changeScoreVisibility(score: Score) : Promise<void> {

    let token = localStorage.getItem("token")
    let httpOptions = {
      headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
      })
    }

    console.log("ok")

    let x = await lastValueFrom(this.http.put<any>(this.domain + "api/Scores/ChangeScoreVisibility/" + score.id, null, httpOptions)).then((x) => {
      console.log("success modified")
      console.log(x)
    }).catch((err) => {
      console.log(err)
    });
  }

  async login(username : string, password : string) : Promise<void>{
    let LoginDTO = {
      username: username,
      password: password,
    }
    let x = await lastValueFrom(this.http.post<any>(this.domain + "api/Users/Login", LoginDTO)).then((x) => {
      console.log(x)
      localStorage.setItem("token", x.token)
      // Redirection si la connexion a réussi :
      this.route.navigate(["/play"])
    }).catch((err) => {
      console.log(err)
    });
  }

  async register(username : string, email : string, password: string, passwordConfirm : string) : Promise<void>{
    let registerDTO = {
      username: username,
      email: email,
      password: password,
      passwordConfirm: passwordConfirm
    };
    let x = await lastValueFrom(this.http.post<any>(this.domain + "api/Users/Register", registerDTO));
    console.log(x)
  }
}
