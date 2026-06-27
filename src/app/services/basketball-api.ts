import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { PlayerStatsAverages } from '../models/player-stats-averages.models';
import { PlayerSearchbar } from '../models/player-searchbar.models';

@Injectable({
  providedIn: 'root',
})
export class BasketballApi {
  
  private http = inject(HttpClient);
  private apiUrl = environment.playerStatsURL;

  public getPlayerById(playerId: number): Observable<PlayerStatsAverages> { // Fetch player stats by ID from Basketball API
    return this.http.get<PlayerStatsAverages>(`${this.apiUrl}/playerstats/stataverages/${playerId}`);
  }

  public getPlayerByName(playerName: string): Observable<PlayerSearchbar[]> { // Fetch players by name from Basketball API
    return this.http.get<PlayerSearchbar[]>(`${this.apiUrl}/playerstats/byname/${playerName}`);
  }

  public getPlayerImage(playerId: number): string{
    return "https://cdn.nba.com/headshots/nba/latest/1040x760/" + playerId + ".png"; // Returns the URL for the player's image based on their ID
  }
}
