import { Component, inject } from '@angular/core';
import { BasketballApi } from '../../services/basketball-api';
import { PlayerStatsAverages } from '../../models/player-stats-averages.models';
import { DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [DecimalPipe],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {

  playerService = inject(BasketballApi);
  playerStats: PlayerStatsAverages | undefined;
  playerImageUrl: string | undefined;


  ngOnInit() {
    this.playerImageUrl = this.playerService.getPlayerImage(2544);
    this.playerService.getPlayerById(2544).subscribe(stats => {
      this.playerStats = stats;
      console.log('Player stats fetched successfully:', stats);
    });

    this.playerService.getPlayerByName('Jalen').subscribe(players => {
      console.log('Players fetched successfully:', players);
    });
  }
}
