import { Component, ViewChild,ElementRef} from '@angular/core';
import { UserDataService } from '../../services/user-data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.css']
})
export class PopupComponent {
  @ViewChild('popupElement') popupElement!:ElementRef;
  showPopup:boolean=true;
  closePopup(){
    this.showPopup=false;
  }
  productList:undefined | any[]
  constructor(private router: Router, private userData:UserDataService){}

  ngOnInit():void{
  }
  submit(data: any) {
    this.userData.addProduct(data).subscribe((res) => {
      console.warn(res);
    this.productList=res;
    this.showPopup = false;
    location.reload();
    });
  }  
  
  
}

