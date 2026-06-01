import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerStatsPage } from './player-stats-page';

describe('PlayerStatsPage', () => {
  let component: PlayerStatsPage;
  let fixture: ComponentFixture<PlayerStatsPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayerStatsPage],
    }).compileComponents();

    fixture = TestBed.createComponent(PlayerStatsPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
