import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MeanPriceComponent } from './mean-price.component';

describe('MeanPriceComponent', () => {
  let component: MeanPriceComponent;
  let fixture: ComponentFixture<MeanPriceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MeanPriceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MeanPriceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
