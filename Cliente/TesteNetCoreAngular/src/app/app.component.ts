import { Component } from '@angular/core';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

import { faL, faPen } from '@fortawesome/free-solid-svg-icons';
import { faTrashCan } from '@fortawesome/free-solid-svg-icons';
import { UsuarioService } from 'src/services/UsuariosService';
import { UsuarioModel } from 'src/models/UsuarioModel';
import { NgTemplateOutlet } from '@angular/common';
import { EscolaridadeModel } from 'src/models/EscolaridadeModel';
import { TitleStrategy } from '@angular/router';
import {NgbDateStruct, NgbCalendar} from '@ng-bootstrap/ng-bootstrap';
import Swal from 'sweetalert2';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent {
    title = 'TesteNetCoreAngular';
    faTrashCan = faTrashCan;
    faPen = faPen;
    closeResult = '';
    tituloModal = 'Detalhes Usuário';

    usuarioSelecionado: UsuarioModel = new UsuarioModel();
    escolaridadeSelecionadaId: number = 0;
    nascimento: NgbDateStruct = this.calendar.getToday();


    constructor(private modalService: NgbModal, private usuarioService: UsuarioService, private calendar: NgbCalendar) {

      this.listaTodosUsuarios();
      this.carregaEscolaridades();
    }

    usuarios: UsuarioModel[] = [];
    escolaridades: EscolaridadeModel[] = [];

    open(content:any, usuario: any = null) {
      
      if(usuario != null)
      {
          this.tituloModal = 'Detalhes Usuário';
          this.usuarioSelecionado.id = usuario.id;
          this.usuarioSelecionado.nome = usuario.nome;
          this.usuarioSelecionado.sobrenome = usuario.sobrenome;
          this.usuarioSelecionado.email = usuario.email;
          this.usuarioSelecionado.dataNascimento = usuario.dataNascimento;

          this.usuarioSelecionado.escolaridadeId = usuario.escolaridadeId;

          let data = new Date(usuario.dataNascimento);

          this.nascimento.day = data.getDate();
          this.nascimento.month = data.getMonth() + 1;
          this.nascimento.year = data.getFullYear();
      }
      else{
        this.tituloModal = 'Novo Usuário';
        this.usuarioSelecionado = new UsuarioModel();
        this.escolaridadeSelecionadaId = 0;
        this.nascimento = this.calendar.getToday();
      }

      this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title',
        // beforeDismiss: () => {
          
        //   return false;
        // }
      }).result.then((result) => {

        // if(!this.UsuarioValido())
        //   return;

        this.usuarioSelecionado.dataNascimento = new Date(this.nascimento.year, this.nascimento.month -1, this.nascimento.day);
        

        this.usuarioService.saveUsuario(this.usuarioSelecionado).subscribe(
          {
              complete: () => {
              },
              next: (data) =>{
                this.listaTodosUsuarios();
              },
              error: (data) =>{
                  let message = data.error.message ? data.error.message : data.message;
                  let erro = '';
                  
                  if(data.error.errors)
                  {
                      for(let p in data.error.errors)
                      {
                        erro += `${p}: ${data.error.errors[p][0]} <br/> `;
                      }
                        
                      this.ExibeErroValidacao(erro);
                  }
                  
              }
          });

      }, (reason) => {
        //console.log('escolaridade selecionada:', this.escolaridadeSelecionadaId);
          //alert('fechou');
        console.log(this.nascimento);
      });
    }

   
    listaTodosUsuarios()
    {


        this.usuarioService.getAllUsuarios().subscribe(
        {
            complete: () => {
            },
            next: (data) =>{
                this.usuarios = data;
            },
            error: (data) =>{
                let message = data.error.message ? data.error.message : data.message;
                console.log(data);
                this.ExibeErro(message);
            }
        });
    }

    carregaEscolaridades()
    {
        this.usuarioService.getEscolaridades().subscribe(
        {
            complete: () => {
            },
            next: (data) =>{
                
                //this.escolaridades.push(new EscolaridadeModel(0, 'Selecione uma escolaridade'));
                this.escolaridades = data;
                this.escolaridades.splice(0, 0, new EscolaridadeModel(0, 'Selecione uma escolaridade'));

                console.log(this.escolaridades);
                console.log(this.escolaridades);

            },
            error: (data) =>{
                let message = data.error.message ? data.error.message : data.message;
                console.log(data);

                this.ExibeErro(message);
            }
        });
    }


    UsuarioValido(): boolean
    {
        let erro = '';

        if(!this.usuarioSelecionado.nome || this.usuarioSelecionado.nome.trim().length == 0 )
            erro = 'Informe um nome para o usuário';


        if(erro.length > 0)
        {
            this.ExibeErro(erro);
            return false;
        }

        return true;
    }

    excluiUsuario(usuario: UsuarioModel)
    {
      Swal.fire({
        title: 'Atenção',
        text: `Tem certeza de que deseja excluir o usuário ${usuario.id} ${usuario.nome} ${usuario.sobrenome}?`,
        icon: 'question',
        showCancelButton: true,
        cancelButtonText: 'Não',
        confirmButtonText: 'OK',
      }).then((result) => {
        if (result.isConfirmed) {

          this.usuarioService.deleteUsuario(usuario.id).subscribe(
            {
                complete: () => {
                },
                next: (data) =>{
                  this.listaTodosUsuarios();
                  Swal.fire(
                    'Deletado',
                    'Usuário deletado com sucesso.',
                    'success'
                  )
                },
                error: (data) =>{
                    let message = data.error.message ? data.error.message : data.message;
                    console.log(data);
    
                    this.ExibeErro(`Não foi possível excluir: ${message}`);
                }
            });
        }
      })
    }

    ExibeErroValidacao(mensagem: string)
    {
      Swal.fire({
        title: 'Atenção',
        html: mensagem,
        icon: 'warning',
        confirmButtonText: 'OK'
      });
    }

    
    ExibeErro(mensagem: string)
    {
      Swal.fire({
        title: 'Atenção',
        html: mensagem,
        icon: 'error',
        confirmButtonText: 'OK'
      });
    }
    
}
