import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor( private http:HttpClient) { }
  deleteProduct(id: number) {
    return this.http.delete(`http://localhost:3000/products/${id}`);
  }
  getproduct(id:string){
    return this.http.get(`http://localhost:3000/products/${id}`)
  }
  updateproduct(product:any){
    
    return this.http.put(`http://localhost:3000/products/${product.id}`,product)

  }

}
