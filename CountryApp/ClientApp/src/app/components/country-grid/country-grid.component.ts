import { Component, OnInit } from '@angular/core';
import { Country } from 'src/Models/country.model';
import { CountryService } from 'src/app/service/countries.service';

@Component({
  selector: 'app-country-grid',
  templateUrl: './country-grid.component.html',
  styleUrls: ['./country-grid.component.css'],
})

export class CountryGridComponent implements OnInit{
  countries: Country[] = [];
  names: string[] = [];
  flagsPng: string[] = [];

  constructor(private countrySevice: CountryService) {}

  ngOnInit(): void {
    this.countrySevice.getAllCountries().subscribe((data) => {
      this.countries = data;
      this.names = data.map(x => x.name)
      this.flagsPng = data.map(x => x.flag)
    });
  }
  
  handleTileClick(countryName: string): void {
    console.log('Clicked on:', countryName);
  }

}
