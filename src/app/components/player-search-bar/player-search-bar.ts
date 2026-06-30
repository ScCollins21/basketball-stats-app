import { Component, EventEmitter, Output } from '@angular/core';
import { BasketballApi } from '../../services/basketball-api';
import { inject } from '@angular/core';
import { PlayerSearchbar } from '../../models/player-searchbar.models';
import { MatInputModule } from '@angular/material/input';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatOptionModule } from '@angular/material/core';
import { ReactiveFormsModule, FormControl } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { debounceTime, distinctUntilChanged, filter, switchMap } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-player-search-bar',
  imports: [MatInputModule, MatAutocompleteModule, MatOptionModule, MatFormFieldModule, ReactiveFormsModule, CommonModule],
  templateUrl: './player-search-bar.html',
  styleUrl: './player-search-bar.css',
})
export class PlayerSearchBar {

  searchControl = new FormControl('', { nonNullable: true });
  playerService = inject(BasketballApi);
  filteredPlayers: PlayerSearchbar[] = [];

  @Output() cardSelected = new EventEmitter<PlayerSearchbar>();

  
  ngOnInit(): void {
    this.searchControl.valueChanges // Waits for changes in the search input, then fetches matching cards from the API and updates the filteredCards list(API grabs 8 card at most)
      .pipe(
        filter(value => value.length > 0), // Only search if there is at least one character in the input
        debounceTime(300),
        distinctUntilChanged(),
        switchMap(value =>
          this.playerService.getPlayerByName(value)
        )
      )
      .subscribe(players => {
        this.filteredPlayers = players || []; 
        this.filteredPlayers.forEach(player => {
          player.playerImg = this.playerService.getPlayerImage(player.playerId); // Fetch the player image for each player in the filtered list
        });
      });
  }

  selectPlayer(player: PlayerSearchbar) {
    this.cardSelected.emit(player);
  }

}
