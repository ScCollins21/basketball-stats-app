import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerSearchBar } from './player-search-bar';

describe('PlayerSearchBar', () => {
  let component: PlayerSearchBar;
  let fixture: ComponentFixture<PlayerSearchBar>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayerSearchBar],
    }).compileComponents();

    fixture = TestBed.createComponent(PlayerSearchBar);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
