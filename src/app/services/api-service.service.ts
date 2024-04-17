import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {
  whichCity = 'Jaraguá do Sul, SC'
  weatherData: any;

  constructor(private http: HttpClient) { }

  fetchWeatherData() {
    this.whichCity = 'Jaraguá do Sul, SC'
    let apiLink = `https://api.hgbrasil.com/weather?format=json-cors&key=bac82211&city_name=${this.whichCity}`
    return this.http.get<any>(apiLink).subscribe((data) => {this.weatherData = data;});
  }
}















// para as imagens concatenar o nome dado pela Api com o .svg das imgs
//criar interface para substituir os anys