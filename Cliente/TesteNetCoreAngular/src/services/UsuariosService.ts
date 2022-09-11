import { UsuarioModel } from "src/models/UsuarioModel";
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { interval, take, lastValueFrom, firstValueFrom } from 'rxjs';

@Injectable({
    providedIn:"root"
})

export class UsuarioService
{
 
    constructor(private httpCliente: HttpClient){};

    async getUsuario(id: number) : Promise<UsuarioModel> 
    {
        const usuarioModel: UsuarioModel = new UsuarioModel();
        try {

           let response = await firstValueFrom(this.httpCliente.get<any>(`https://localhost:7182/api/home/${id}`));

           alert(response.hasError);


        } catch (error) {
            
        }

        return usuarioModel;
    }

    getUsuarios() : UsuarioModel[]
    {
        let usuarios: UsuarioModel[] = [];
        try {




        } catch (error) {
            
        }

        return usuarios;
    }


    deleteUsuario(id: number)
    {
        try {




        } catch (error) {
            
        }
    }

    updateUsuario(usuarioModel: UsuarioModel)
    {
        try {




        } catch (error) {
            
        }
    }

}