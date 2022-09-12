import { UsuarioModel } from "src/models/UsuarioModel";
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { interval, take, lastValueFrom, firstValueFrom, Observable } from 'rxjs';
import { EscolaridadeModel } from "src/models/EscolaridadeModel";

@Injectable({
    providedIn:"root"
})

export class UsuarioService
{
    httpOptions = { headers: new HttpHeaders({'Content-Type': 'application/json'}) };
    baseUrl = 'https://localhost:7182/api/home';
    constructor(private httpCliente: HttpClient){};

    getUsuario(id: number) : Observable<UsuarioModel> 
    {
        return this.httpCliente.get<UsuarioModel>(`${this.baseUrl}/${id}`);
    }

    getAllUsuarios() : Observable<UsuarioModel[]>
    {
        return this.httpCliente.get<UsuarioModel[]>(`${this.baseUrl}`);
    }


    deleteUsuario(id: number)
    {
        return this.httpCliente.delete<any>(`${this.baseUrl}/${id}`);
    }

    saveUsuario(usuarioModel: UsuarioModel)
    {
        const body = JSON.stringify(usuarioModel);
        console.log(body);

        return this.httpCliente.post<any>(`${this.baseUrl}`, body, this.httpOptions);
    }

    // updateUsuario(usuarioModel: UsuarioModel)
    // {
    //     return this.httpCliente.post<any>(`${this.baseUrl}`, usuarioModel);
    // }

    // addUsuario(usuarioModel: UsuarioModel)
    // {
    //     return this.httpCliente.post<any>(`${this.baseUrl}`, usuarioModel);
    // }

    getEscolaridades()
    {
        return this.httpCliente.get<EscolaridadeModel[]>(`${this.baseUrl}/escolaridades`);
    }

}