import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class UserDataService {
  url = "https://dummyjson.com/products";
  constructor(private http:HttpClient) { }

  users(){
    return this.http.get(this.url)
  }

  addProduct(data:any){
   return this.http.post<any>('http://localhost:3000/products', data);
  }
  productList(){
    return this.http.get<{ id: number, title: string, price: number, rating: number, brand: string }[]>('http://localhost:3000/products');
}

  deleteProduct(id: number) {
    return this.http.delete<{ id: number, title: string, price: number, rating: number, brand: string }[]>('http://localhost:3000/products/' + id);
  }
  
}
