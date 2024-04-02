import { Country } from "src/Models/country.model";

export const MOCK_COUNTRIES: Country[] = [
  {
    name: 'United States',
    capital: ['Washington, D.C.'],
    currencies: ['United States Dollar'],
    population: 331449281,
    isoCode: 'US',
    languages: ['English'],
    flag: 'https://restcountries.com/data/usa.svg'
  },
  {
    name: 'United Kingdom',
    capital: ['London'],
    currencies: ['Pound Sterling '],
    population: 67886011,
    isoCode: 'GB',
    languages: ['English'],
    flag: 'https://restcountries.com/data/gbr.svg'
  },
  {
    name: 'Germany',
    capital: ['Berlin'],
    currencies: ['Euro'],
    population: 83783942,
    isoCode: 'DE',
    languages: ['German'],
    flag: 'https://restcountries.com/data/deu.svg'
  }
];
