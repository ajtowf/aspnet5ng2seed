import { Component, View, bootstrap, NgFor } from 'angular2/angular2';
import { Http, HTTP_PROVIDERS, Response } from 'angular2/http';
import { Shipment } from './model';

@Component({
    selector: "my-app" 
})
@View({
    directives: [NgFor],
    templateUrl: 'app/partials/app.html'
})
class AppComponent {
    shipments: Array<Shipment> = [];

    constructor(public http: Http) {
        this.getData();
    }

    getData() {
        this.http.get('http://localhost:2949/api/data')
            .map(res => (<Response>res).json())
            .map((shipments: Array<any>) => {
                let result: Array<Shipment> = [];
                if (shipments) {
                    shipments.forEach(shipment => {
                        result.push(
                            new Shipment(
                                shipment.id,
                                shipment.origin,
                                shipment.destination,
                                new Date(shipment.shippedDate)));
                    });
                }

                return result;
            }).
            subscribe(
                data => {
                    this.shipments = data;
                    console.log(this.shipments);
                },
                err => console.log(err)
            );
    }
}

bootstrap(AppComponent, [HTTP_PROVIDERS]);