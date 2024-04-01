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
  @Output() clickEmitter: EventEmitter<string> = new EventEmitter<string>();


  constructor() {}

  ngOnInit(): void {
    this.names = this.countries.map(x => x.name);
    this.flagsPng = this.countries.map(x => x.flag);
  }
  
  handleTileClick(countryName: string): void {
    this.clickEmitter.emit(countryName)
  }

}
