import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from '../../../../../_services/configuration.service';

@Component({
    selector: 'app-configuration-display',
    templateUrl: './configuration-display.component.html',
    styles: []
})
export class ConfigurationDisplayComponent implements OnInit {

    public generalModel: Configuration = {
        key: '',
        value: ''
    };

    constructor(public configService: ConfigurationService) { }

    ngOnInit() {
        this.getGeneralInfo();
    }

    getGeneralInfo() {
        this.configService.getGeneralInfo().subscribe(data => {
            this.generalModel = data;
        });
    }

}
