import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { PlayerSearchBar } from '../player-search-bar/player-search-bar';


@Component({
  selector: 'app-navbar',
  imports: [RouterModule, MatButtonModule, PlayerSearchBar],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css',
})
export class Navbar {}
