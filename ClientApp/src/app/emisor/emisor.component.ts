import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    templateUrl: './emisor.component.html'
})
export class EmisorComponent {
    show: boolean = true;
    emi: emisor;
    emis: emisor[] = [];

    constructor(private http: HttpClient, @Inject('BASE_URL') private burl: string) {
        this.lista();
    }

    lista() {
        this.http.get<emisor[]>(this.burl + 'api/Emisor').subscribe(response => {
            this.emis = response;
        }, error => console.error(error));
    }

    nuevo() {
        this.emi = {
            id: 0, rfc: '', fechaInicioOperacion: (new Date()).toISOString(), capital: 0, activo: 1
        };
        this.show = false;
    }

    mod(e: emisor) {
        this.emi = e;
        this.show = false;
    }

    guarda() {
        if (this.valida()) {
            if (this.emi.id == 0) {
                this.http.post<emisor>(this.burl + 'api/Emisor', this.emi).subscribe(response => {
                    this.emi = response;
                    alert('Emisor guardado de forma correcta.');
                }, error => console.error(error));
            } else {
                this.http.put<emisor>(this.burl + 'api/Emisor/' + this.emi.id, this.emi).subscribe(response => {
                    this.emi = response;
                    alert('Emisor actualizado de forma correcta.');
                }, error => console.error(error));
            }
        }
    }

    eli(id: number) {
        this.http.delete(this.burl + 'api/Emisor/' + id).subscribe(response => {
            this.lista();
        }, error => console.error(error));
    }

    regresa() {
        this.show = true;
        this.lista();
    }

    valida() {
        if (this.emi.rfc == '') {
            alert('RFC no puede estar vacío.');
            return false;
        }
        if (this.emi.fechaInicioOperacion == '') {
            alert('Fecha de inicio de operaciones no puede estar vacío.');
            return false;
        }
        return true;
    }
    
}

interface emisor {
    id: number;
    rfc: string;
    fechaInicioOperacion: string;
    capital: number;
    activo: number;
}