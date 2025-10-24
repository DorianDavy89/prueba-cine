import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { Router } from "@angular/router";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatIconModule,
  ],
})

export class LoginComponent {

  usuario = '';
  contrasena = '';
  error = false;

  constructor(
    private router: Router
  ) { }


  ingresar(): void {
    if (this.usuario === 'default' && this.contrasena === 'default') {
      this.router.navigate(['/dashboard']);
    } else {
      this.error = true;
    }
  }

}
