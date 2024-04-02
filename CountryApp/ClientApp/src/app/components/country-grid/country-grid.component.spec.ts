import { ComponentFixture, TestBed } from '@angular/core/testing';
import { EventEmitter } from '@angular/core';
import { CountryGridComponent } from './country-grid.component';
import { Country } from 'src/Models/country.model';
import { MOCK_COUNTRIES } from 'src/testing/countries.mock';

describe('CountryGridComponent', () => {
  let component: CountryGridComponent;
  let fixture: ComponentFixture<CountryGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CountryGridComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize flagsPng array with flags from countries', () => {
    const countries: Country[] = MOCK_COUNTRIES;
    component.countries = countries;
    component.ngOnInit();
    const expectedFlagsPng = countries.map(country => country.flag);
    expect(component.flagsPng).toEqual(expectedFlagsPng);
  });

  it('should emit country when handleTileClick is called', () => {
    const country: Country = MOCK_COUNTRIES[1];
    const emitSpy = spyOn(component.clickEmitter, 'emit');
    component.handleTileClick(country);
    expect(emitSpy).toHaveBeenCalledWith(country);
  });
});
