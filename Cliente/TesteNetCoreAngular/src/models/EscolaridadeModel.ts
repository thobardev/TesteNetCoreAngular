export class EscolaridadeModel
{
    constructor(id:number = 0, descricao:string = '')
    {
        this.id = id;
        this.descricao= descricao;
    }

    id: number = 0;
    descricao: string = '';
}