import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'suma-comp',
    templateUrl: './suma.component.html'
})
export class SumaComponent {
    lista: number[] = [];
    subcon: number = 2;
    suma: number = 14;
    sumCon: Array<Array<number>> = Object.create(null);
    num: number = 0;

    constructor(private http: HttpClient, @Inject('BASE_URL') private burl: string) {
        this.default();
    }

    default() {
        this.lista = [4, 5, 9, 13, 1, 10];
        this.subcon = 2;
        this.suma = 14;
    }

    generar() {
        if (this.valida()) {
            this.http.post<any>(this.burl + 'api/Suma/' + this.subcon + '/' + this.suma, this.lista).subscribe(response => {
                console.log(JSON.stringify(response));
                this.sumCon = response;
            });
        }
    }

    elimina(i: number) {
        this.lista.splice(i, 1);
    }

    agrega() {
        if (this.num && this.num > 0) {
            this.lista.push(this.num);
        }
    }

    valida() {
        if (this.subcon < 1) {
            alert('Conjunto debe ser numerico')
            return false;
        }
        if (this.suma < 1) {
            alert('Conjunto debe ser numerico')
            return false;
        }

        return true;
    }
}