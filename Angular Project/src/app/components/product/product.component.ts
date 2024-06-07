import { Component } from '@angular/core';
import { PopupComponent } from '../popup/popup.component';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserDataService } from '../../services/user-data.service';
import { EditProductComponent } from '../edit-product/edit-product.component';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {
  users:any;
  productList:any;
  constructor(private router:Router, private modalService:NgbModal, private userData:UserDataService){
    userData.users().subscribe((data:any)=>{
      console.warn("data",data);
      this.users=data.products.slice(0,6);
      console.log(this.users)
    });
    this.loadProductList();
  }
  openPopup(){
    const modalRef=this.modalService.open(PopupComponent);
    modalRef.componentInstance.submitEvent.subscribe((data: any) => {
      this.userData.addProduct(data).subscribe((res) => {
        console.warn(res);
        this.loadProductList();
      });
    });
  } 
  editPopup(productid: number) {
    const modalRef = this.modalService.open(EditProductComponent);
    modalRef.componentInstance.productid = productid;
  }
  
  loadProductList() {
    this.userData.productList().subscribe((res) => {
      console.warn(res);
      this.productList = res;
      // location.reload();
    });
  }
  ngOnInit():void{
  }
  submit(data:{ id: number, title: string, price: number, rating: number, brand: string }[]) {
    this.userData.addProduct(data).subscribe((res) => {
      console.warn(res);
      this.loadProductList();
    });
  } 
  deleteProduct(id: number) {
    this.userData.deleteProduct(id).subscribe(() => {
      console.log("Product deleted successfully");
      this.loadProductList(); // Reload the product list after deletion
    });
  }
  deletedummyProduct(id: number) {
    this.users = this.users.filter((item: any) => item.id !== id);
  }
  
  
}
