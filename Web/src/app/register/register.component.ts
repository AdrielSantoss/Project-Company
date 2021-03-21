import { AuthService } from './../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

  form = this.fb.group({
    name: [null, Validators.required],
    email: [null, Validators.required],
    confirmPassword: [null, Validators.required],
    password: [null, Validators.required]
  })
  submitted = false;

  constructor(public fb: FormBuilder, public auth: AuthService, public router: Router, private toastr: ToastrService) { }

  ngOnInit(): void { }

  register() { 
    this.submitted = true;
    if (!this.form.invalid) {
      if (this.form.value.password !== this.form.value.confirmPassword) {
        this.toastr.error('Repita sua senha corretamente.','Senhas não conferem!');
      }else {
        this.auth.postRegister(this.form.value.name, this.form.value.email, this.form.value.password).subscribe(()=>{
            this.toastr.success('Conta criada com sucesso.','Registrado!');
            this.router.navigate(['/']);
        }, () => {
          this.toastr.error('Uma conta já possui este email.','Email cadastrado!');
        })
      } 
    }
  }
}
