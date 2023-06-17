import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DividendMapComponent } from './dividend-map.component';

describe('DividendMapComponent', () => {
  let component: DividendMapComponent;
  let fixture: ComponentFixture<DividendMapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DividendMapComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DividendMapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
