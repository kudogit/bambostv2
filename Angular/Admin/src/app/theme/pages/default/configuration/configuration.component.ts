import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ConfigurationService } from '../../../../_services/configuration.service';
import { MessageService } from 'primeng/components/common/messageservice';
import { Message } from 'primeng/primeng';
import { Router } from '@angular/router';
@Component({
    selector: 'app-configuration',
    templateUrl: './configuration.component.html',
    styleUrls: [
        './configuration.css'
    ],
    encapsulation: ViewEncapsulation.None,
})
export class ConfigurationComponent implements OnInit {

    public generalInfoModel: Configuration = {
        key: '',
        value: ''
    };
    msgs: Message[] = [];
    constructor(
        public configurationService: ConfigurationService,
        private messageService: MessageService,
        private router: Router
    ) {

    }

    ngOnInit() {
    }

    save() {
        this.configurationService.configGeneralInfo(this.generalInfoModel).subscribe(data => {
            this.msgs.push({ severity: 'success', summary: 'Thông Tin', detail: 'Lưu Thành Công' });
            setTimeout(() => {
                this.router.navigateByUrl('/index');
            }, 2000);


        },
            error => {
                setTimeout(() => {
                    this.msgs.push({ severity: 'error', summary: 'Thông Tin', detail: 'Lưu không thành công' });
                }, 1000);
                this.clear();
            });
    }

    clear() {
        this.messageService.clear();
    }
}
