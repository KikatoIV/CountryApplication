import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Country } from '../../Models/country.model';
import { environment } from '../../environments/environment'; //

@Injectable({
  providedIn: 'root',
})

export class CountryService {

  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }
  
  getAllCountries(): Observable<Country[]> {
    if(this.apiUrl === '')
    {
      this.apiUrl =  window.location.href;
    }

    return this.http.get<Country[]>(`${this.apiUrl}/countries`);
  }
}
