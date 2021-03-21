import { userInfosLogin } from './../models';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AuthService {

  constructor(private http: HttpClient) { }

    private userInfos: userInfosLogin | null = null;

    postRegister(name: string, email: string, password: string) {
        return this.http.post('http://localhost:5000/api/user', {
            name,
            email,
            password
        })
    }
}
