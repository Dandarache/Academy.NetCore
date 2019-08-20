import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-categories',
  templateUrl: './fetch-categories.component.html'
})
export class FetchCategoriesComponent {
  public categories: Category[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Category[]>(baseUrl + 'api/categories').subscribe(result => {
      this.categories = result;
    }, error => console.error(error));
  }
}

interface Category {
  id: number;
  name: string;
}
