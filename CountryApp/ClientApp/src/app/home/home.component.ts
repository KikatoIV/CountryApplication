import { Component, OnInit } from '@angular/core';
import { Country } from '../../Models/country.model';
import { CountryService } from '../service/countries.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  countries: Country[] = [];
  orignalCountries: any[] = [];
  countrtyCount: number = 0;
  countrySubscription: Subscription | undefined;
  isInfoPanelOpen: boolean = false;
  selectedCountry: Country | undefined;

  constructor(private countryService: CountryService) {}

  ngOnInit(): void {
    this.countrySubscription = this.countryService
      .getAllCountries()
      .subscribe((data) => {
        this.countries = data;
        this.orignalCountries = data;
      });
    this.countrtyCount = this.countries.length;
    console.log(this.countrtyCount);
  }

  handleSearch(searchTerm: string) {
    console.log('Received search term:', searchTerm);
    if (searchTerm.trim() === '') {
      this.countries = [...this.orignalCountries];
    } else {
      this.countries = this.countries.filter((country) =>
        country.name.toLowerCase().includes(searchTerm.toLowerCase())
      );
    }
  }

  handleCountryClick(countryClick: Country) {
    this.selectedCountry = countryClick;
    this.isInfoPanelOpen = true;
  }
  handlePanelClosed() {
    // Perform any actions needed when the info panel is closed
    this.isInfoPanelOpen = false;
  }

  ngOnDestroy(): void {
    if (this.countrySubscription) {
      this.countrySubscription.unsubscribe();
    }
  }
}
