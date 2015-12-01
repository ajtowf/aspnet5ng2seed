import { Component, View, bootstrap } from 'angular2/angular2';

@Component({
    selector: "my-app" 
})
@View({
    template: `
{{message}}
<br/><input [(ng-model)]="message"/>
`
})
class AppComponent {
    message: string = "Hello world!";
}

bootstrap(AppComponent);