import { Injectable, Input } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AjaxService {
  base = 'http://localhost:50287/api/';
  
  constructor(private http: HttpClient) { }
// library http methods
  getLibraries() {
    return this.http.get<any>(this.base +'libraries');
  }

  getLibraryById(LibraryId) {
    return this.http.get<any>(this.base +'libraries/' + LibraryId );
  }

  updateLibrary(library): Observable<any>{
    return this.http.put<any>(this.base + 'libraries/' + library.Id , library);
  }

  addLibrary(library): Observable<any>{
    return this.http.post<any>(this.base + 'libraries/', library);
  }

  deleteLibrary(libraryId): Observable<any>{
    return this.http.delete<any>(this.base + 'libraries/' + libraryId);
  }
  

  //books http methods
  getBooks() {
    return this.http.get<any>(this.base + 'books');
  }

  // publisher http methods
  getPublishers() {
    return this.http.get<any>(this.base + 'publishers');
  }

  // client http methods
  getClients() {
    return this.http.get<any>(this.base + 'clients');
  }
}
