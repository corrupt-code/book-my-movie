import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class MoviesListService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getMoviesList() {
    return this.httpClient.get('https://localhost:44394/api/movies').toPromise();
  }

  public getMovieById(id: string) {
    return this.httpClient.get('https://localhost:44394/api/movies/'+id).toPromise();
  }
}
