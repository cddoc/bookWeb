import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public _user_id: number;
  public _http: HttpClient;
  public _baseUrl: string;
  public router: Router;
  public listbooks: ListBook[];
  public listbookfavorits: ListBookFavorit[];



  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
  }

  Login(name: string) {
    this._http.get<number>(this._baseUrl + 'User/' + name).subscribe(result => {
      this._user_id = result;

      this._http.get<ListBook[]>(this._baseUrl + 'book').subscribe(result => {
        this.listbooks = result;
      }, error => console.error(error));

      this._http.get<ListBookFavorit[]>(this._baseUrl + 'favoritbook/' + this._user_id).subscribe(result => {
        this.listbookfavorits = result;
      }, error => console.error(error));

    }, error => console.error(error));  
  }

  ngOnInit() {
  }

  addFavorit(lbook: ListBook) {
    this._http.get<ListBookFavorit[]>(this._baseUrl + 'favoritbook/' + this._user_id + '/' + lbook.bookID).subscribe(result => {
      this.listbookfavorits = result;
    }, error => console.error(error));
  }
}

interface ListBook {
  bookID: number;
  title: string;
  author: string;
}

interface ListBookFavorit {
  bookID: number;
  title: string;
  author: string;
}
