import { Component, OnInit } from '@angular/core';
import { Country } from 'src/Models/country.model';
import { CountryService } from 'src/app/service/countries.service';
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

  constructor(private countryService: CountryServiceMock, private countrysevice2: CountryService) {}

  ngOnInit(): void {
    this.countryService.getAllCountries().subscribe((data) => {
      this.countries = data;
      this.names = data.map(x => x.name)
      this.flagsPng = data.map(x => x.flag)
    });
    this.countrysevice2.getAllCountries().subscribe((x) => {
      console.log(x)

    })
  }
  
  handleTileClick(countryName: string): void {
    console.log('Clicked on:', countryName);
  }

}
