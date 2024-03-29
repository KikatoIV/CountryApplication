import { Component, OnInit } from '@angular/core';
import { Country, Flags } from 'src/Models/country.model';
import { CountryServiceMock } from 'src/app/service/country.service.mock';

@Component({
  selector: 'app-country-grid',
  templateUrl: './country-grid.component.html',
  styleUrls: ['./country-grid.component.css'],
})

export class CountryGridComponent implements OnInit{
  countries: Country[] = [];
  names: string[] = [];
  flagsPng: string[] = [];

  constructor(private countryService: CountryServiceMock) {}

  ngOnInit(): void {
    this.countryService.getAllCountries().subscribe((data) => {
      this.countries = data;
      this.names = data.map(x => x.name.common)
      this.flagsPng = data.map(x => x.flags.png)
    });
    
  }
  handleTileClick(countryName: string): void {
    console.log('Clicked on:', countryName);
  }

}
