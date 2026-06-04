import { Component, inject } from '@angular/core';
import { BasketballApi } from '../../services/basketball-api';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {

  playerService = inject(BasketballApi);

  ngOnInit() {
    this.playerService.getPlayerById(17).subscribe(playerStats => {
      console.log(playerStats);
    });
  }
}
