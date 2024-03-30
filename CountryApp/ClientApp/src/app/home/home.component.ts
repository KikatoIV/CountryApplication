import { Component, OnInit } from '@angular/core';
import { Country } from '../../Models/country.model';
import { CountryServiceMock } from '../service/country.service.mock';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  countries: Country[] = [];

  constructor(private countryService: CountryServiceMock) {}

  ngOnInit(): void {
    this.countryService.getAllCountries().subscribe((data) => {
      this.countries = data;
    });

    // console.log(this.countries);
  }
}
