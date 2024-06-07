import { Component } from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrl: './about.component.css'
})
export class AboutComponent {
  isImageToggled: boolean = false;

  toggleImage() {
    this.isImageToggled = !this.isImageToggled;
  }
}
