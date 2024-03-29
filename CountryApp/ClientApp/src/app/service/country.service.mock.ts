import { Observable, of } from 'rxjs';
import { Country } from '../../Models/country.model';
import { COUNTRIES_MOCK } from '../../testing/countries.mock';

export class CountryServiceMock {
  private readonly mockCountries: Country[] = COUNTRIES_MOCK;
  getAllCountries(): Observable<Country[]> {
    return of(this.mockCountries);
  }
}
