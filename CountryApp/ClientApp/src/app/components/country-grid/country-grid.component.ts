import { Component, OnInit, Output, EventEmitter,  Input } from '@angular/core';
import { Country } from 'src/Models/country.model';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';


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
  loading: boolean = true;

  constructor() {}

  ngOnInit(): void {
    this.flagsPng = this.countries.map(x => x.flag);
    this.checkFlagsLoaded();
  }
  
  handleTileClick(country: Country): void {
    this.clickEmitter.emit(country)
  }

  private checkFlagsLoaded(): void {
    const flagPromises = this.flagsPng.map(url => this.checkImage(url));
    Promise.all(flagPromises)
      .then(() => {
        this.loading = false; 
      })
      .catch((error) => {
        console.error('Error loading flags:', error);
      });
  }

  private checkImage(url: string): Promise<void> {
    return new Promise<void>((resolve, reject) => {
      const img = new Image();
      img.onload = () => resolve();
      img.onerror = () => reject();
      img.src = url;
    });
  }

}
