import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-news',
  templateUrl: './fetch-news.component.html'
})
export class FetchNewsComponent {
  public news: NewsItem[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<NewsItem[]>(baseUrl + 'api/news').subscribe(result => {
      this.news = result;
    }, error => console.error(error));
  }
}

interface NewsItem {
  header: string;
  intro: string;
  body: string;
}
