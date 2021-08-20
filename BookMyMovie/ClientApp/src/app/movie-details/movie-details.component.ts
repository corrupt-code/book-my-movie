import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Movie } from '../movies-list/movie.model';
import { MoviesListService } from '../movies-list/movies-list.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  movieId;
  movie: Movie;

  constructor(
    private route: ActivatedRoute,
    private moviesListService: MoviesListService,
    private location: Location
  ) { }

  async ngOnInit() {

    this.movie = await this.moviesListService.getMovieById(this.route.snapshot.params['id']);
  }

  onBack() {
    this.location.back()
  }
}
