import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  _filtroLista: string;

  get filtroLista(): string{
    return this._filtroLista;
  }
  set filtroLista(value: string){
    this._filtroLista = value;
  }

  eventos: any = [];
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  alternarImagem(){
      this.mostrarImagem = !this.mostrarImagem;
  }

  getEventos(){
      this.http.get('https://localhost:5001/api/values').subscribe(response =>{
      this.eventos = response;
      console.log(this.eventos);
    },error => {
      console.log(error);
    });
  }

}
