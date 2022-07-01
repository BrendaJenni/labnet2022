import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Categories } from '../categories/models/categories';
import { throwError as observableThrowError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  endPoint: string = 'ApiCategories/';
  url = environment.apicategories + this.endPoint;
  constructor(private http: HttpClient) {}

  public createCategory(categoryRequest: Categories): Observable<any> {
    return this.http
      .post(this.url, categoryRequest)
      .pipe(catchError(this.errorHandler));
  }
  public getCategory(): Observable<Array<Categories>> {
    return this.http
      .get<Array<Categories>>(this.url)
      .pipe(catchError(this.errorHandler));
  }
  public deleteCategory(categoryId: number): Observable<any> {
    return this.http
      .delete<any>(this.url + categoryId)
      .pipe(catchError(this.errorHandler));
  }
  public updateCategory(categoryRequest: Categories): Observable<any> {
    return this.http
      .put<any>(this.url + categoryRequest.CategoryId, categoryRequest)
      .pipe(catchError(this.errorHandler));
  }
  errorHandler(error: HttpErrorResponse) {
    return observableThrowError(error.message || 'server error');
  }
}
