import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { PlayerStatsAverages } from '../models/player-stats-averages.models';

@Injectable({
  providedIn: 'root',
})
export class BasketballApi {
  
  private http = inject(HttpClient);
  private apiUrl = environment.playerStatsURL;

  public getPlayerById(playerId: number): Observable<PlayerStatsAverages> { // Fetch player stats by ID from Basketball API
    return this.http.get<PlayerStatsAverages>(`${this.apiUrl}/playerstats/playerstats/${playerId}`);
  }
}
