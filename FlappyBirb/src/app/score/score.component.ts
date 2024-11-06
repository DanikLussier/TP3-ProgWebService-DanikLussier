import { Component } from '@angular/core';
import { Score } from '../models/score';
import { MaterialModule } from '../material.module';
import { CommonModule } from '@angular/common';
import { Round00Pipe } from '../pipes/round-00.pipe';
import { FlappyBirbServiceService } from '../services/flappy-birb-service.service';

@Component({
  selector: 'app-score',
  standalone: true,
  imports: [MaterialModule, CommonModule, Round00Pipe],
  templateUrl: './score.component.html',
  styleUrl: './score.component.css'
})
export class ScoreComponent {

  myScores : Score[] = [];
  publicScores : Score[] = [];
  userIsConnected : boolean = false;

  constructor(public flappyBirb : FlappyBirbServiceService) { }

  async ngOnInit() {

    this.userIsConnected = sessionStorage.getItem("token") != "";
    this.flappyBirb.getPublicScores().then((x) => {
      this.publicScores = x
    });
    this.flappyBirb.getPrivateScores().then((x) => {
      this.myScores = x
    })

  }

  async changeScoreVisibility(score : Score){
    console.log(score)
    await this.flappyBirb.changeScoreVisibility(score).then((x) => {
      console.log(x)
    });
    this.ngOnInit()
  }

}
