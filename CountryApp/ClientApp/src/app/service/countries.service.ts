import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Country } from '../../Models/country.model';

@Injectable({
  providedIn: 'root',
})

export class CountryService {
  private apiUrl = 'http://localhost:21025/api/countries';

  constructor(private http: HttpClient) { }

  getAllCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(this.apiUrl);
  }
}
