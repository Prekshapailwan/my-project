import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContactService } from '../../contact.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent {

  contactForm: FormGroup;
  isImageToggled: boolean = false;
  constructor(private fb: FormBuilder, private contactService: ContactService) {
    this.contactForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      subject: ['', Validators.required],
      message: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.contactForm.valid) {
      const { email, subject, message } = this.contactForm.value;
      this.contactService.sendEmail(email, subject, message).subscribe({
        next: (response) => {
          console.log('Email sent successfully', response);
          // Handle success (e.g., display a success message)
        },
        error: (error) => {
          console.error('Error sending email', error);
          // Handle error (e.g., display an error message)
        }
      });
    }
  }
  toggleImage() { // Add this method
    this.isImageToggled = !this.isImageToggled;
  }
}
