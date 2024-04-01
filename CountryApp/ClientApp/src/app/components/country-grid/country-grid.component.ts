import { Component, OnInit, Output, EventEmitter,  Input } from '@angular/core';
import { Country } from 'src/Models/country.model';
@Component({
  selector: 'app-country-grid',
  templateUrl: './country-grid.component.html',
  styleUrls: ['./country-grid.component.css'],
})

export class CountryGridComponent implements OnInit{
  @Input() countries: Country[] = [];
  names: string[] = [];
  flagsPng: string[] = [];
  @Output() clickEmitter: EventEmitter<Country> = new EventEmitter<Country>();

  constructor() {}

  ngOnInit(): void {
    this.flagsPng = this.countries.map(x => x.flag);
  }
  
  handleTileClick(country: Country): void {
    this.clickEmitter.emit(country)
  }

}
