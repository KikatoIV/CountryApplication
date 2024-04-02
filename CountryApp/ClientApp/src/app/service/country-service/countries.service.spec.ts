import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Country } from '../../../Models/country.model';
import { CountryService } from './countries.service';
import { environment } from 'src/environments/environment';
import { MOCK_COUNTRIES } from 'src/testing/countries.mock';

describe('CountryService', () => {
  let service: CountryService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CountryService]
    });
    service = TestBed.inject(CountryService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return expected countries', () => {
    const mockCountries: Country[] = MOCK_COUNTRIES;

    service.getAllCountries().subscribe(countries => {
      expect(countries).toEqual(mockCountries);
    });

    const req = httpTestingController.expectOne(`${environment.apiUrl}/countries`);
    expect(req.request.method).toEqual('GET');
    req.flush(mockCountries);
  });
});
