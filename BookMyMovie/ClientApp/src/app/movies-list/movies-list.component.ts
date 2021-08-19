import { Component, OnInit } from '@angular/core';
import { Movie } from './movie.model';
import { MoviesListService } from './movies-list.service';

@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.css']
})
export class MoviesListComponent implements OnInit {

  public moviesList;
  public filteredMoviesList;
  public searchText = '';

  constructor(
    private moviesListService: MoviesListService
  ) { }

  async ngOnInit() {
    debugger;
    this.moviesList = await this.moviesListService.getMoviesList();
    this.filteredMoviesList = this.moviesList;
    console.log(this.moviesList)
  }

  onValueChange(event) {
    this.filteredMoviesList = this.moviesList.filter(movie => {
      this.searchText = this.searchText.toLowerCase()
      return movie.title.toLowerCase().includes(this.searchText)
    })
  }

  onSort(order: string) {
    if(order === 'ASC') {
      this.filteredMoviesList.sort((a,b) => a.Title > b.Title ? 1 : -1)
    } else {
      this.filteredMoviesList.sort((a,b) => a.Title > b.Title ? -1 : 1)
    }
  }
}
