import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private router: Router, private toastr: ToastrService) {}

  username: string = '';
  password: string = '';
  passwordVisible: boolean = false;

  validation(): any {
    if (!(this.username && this.password)) {
      this.toastr.error('Please enter both username and password & username should be an email');
      return;
    }
  
    const passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%?&])[A-Za-z\d@$!%?&]{5,20}$/;
    if (!passwordPattern.test(this.password)) {
      this.toastr.error('Password must contain at least one uppercase letter, one lowercase letter, digit, special character');
      return false;
    }
  
    this.onSubmit();
  }

  onSubmit() {
    this.toastr.success('Logged In');
    this.router.navigate(['/dashboard']);
  }

  togglePasswordVisibility() {
    this.passwordVisible = !this.passwordVisible;
  }
}
