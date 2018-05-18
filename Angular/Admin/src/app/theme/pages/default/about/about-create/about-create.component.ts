import { Component, OnInit } from '@angular/core';
import { AboutService } from '../../../../../_services/about.service';
import { MessageService } from 'primeng/components/common/messageservice';
import { Message } from 'primeng/primeng';
import { Router } from '@angular/router';
@Component({
    selector: 'app-about-create',
    templateUrl: './about-create.component.html',
    styleUrls: ['./about-create.componet.css']
})
export class AboutCreateComponent implements OnInit {
    msgs: Message[] = [];
    public isRequire: boolean = false;
    public about: CreateAbout = {
        description: '',
        isSelected: false
    };
    constructor(
        private aboutService: AboutService,
        private router: Router,
    ) {

    }

    ngOnInit() {
    }

    Create() {
        if (this.about.description == '' || this.about.description == null || this.about.description == 'undefined') {
            this.isRequire = true;
        } else {
            this.isRequire = false;
            this.aboutService.createAbout(this.about).subscribe(data => {
                this.msgs.push({ severity: 'success', summary: 'Thông Tin', detail: 'Lưu Thành Công' });

                setTimeout(() => {
                    this.router.navigateByUrl('/about');
                }, 2000);
            },
                error => {
                    this.msgs.push({ severity: 'error', summary: error.toString(), detail: 'Lưu Thành Công' });
                });
        }
    }
}
