import { Component,ViewChild,ElementRef, Input } from '@angular/core';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrl: './edit-product.component.css'
})
export class EditProductComponent {
  @Input() productid: any;
  productdata:any;
  constructor(private productService: ProductService){}
  @ViewChild('popupElement') popupElement!:ElementRef;
  showPopup:boolean=true;
  closePopup(){
    this.showPopup=false;
  }
  ngOnInit(): void {
    if (this.productid) {
      this.productService.getproduct(this.productid).subscribe((data) => {
        this.productdata = data;
      });
    }
  }
  submit(data: any):void{
    console.warn(data);
    if (this.productdata) {
      data.id = this.productdata.id;
      this.showPopup = false;
    location.reload();
    }
    this.productService.updateproduct(data).subscribe((res) => {
    });
  }
  


}
