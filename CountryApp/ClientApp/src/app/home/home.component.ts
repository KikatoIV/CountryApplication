import { Component, OnInit } from '@angular/core';
import { Country } from '../../Models/country.model';
import { CountryService } from '../service/country-service/countries.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})

export class HomeComponent implements OnInit {
  countries: Country[] = [];
  originalCountries: any[] = [];
  countrtyCount: number = 0;
  countrySubscription: Subscription | undefined;
  isInfoPanelOpen: boolean = false;
  selectedCountry: Country | undefined;
  darkModeEnabled: boolean = true;

  constructor(private countryService: CountryService) {}

  ngOnInit(): void {
    this.countrySubscription = this.countryService
      .getAllCountries()
      .subscribe((data) => {
        this.countries = data;
        this.originalCountries = data;
      });
  }

  handleSearch(searchTerm: string) {
    console.log('Received search term:', searchTerm);
    if (searchTerm.trim() === '') {
      this.countries = [...this.originalCountries];
    } else {
      this.countries = this.originalCountries.filter((country) =>
        country.name.toLowerCase().includes(searchTerm.toLowerCase())
      );
    }
  }

  handleCountryClick(countryClick: Country) {
    this.selectedCountry = countryClick;
    this.isInfoPanelOpen = true;
  }
  
  handlePanelClosed() {
    this.isInfoPanelOpen = false;
  }

  ngOnDestroy(): void {
    if (this.countrySubscription) {
      this.countrySubscription.unsubscribe();
    }
  }

  toggleDarkMode(): void {
    this.darkModeEnabled = !this.darkModeEnabled;
    console.log("hello")
  }
}
