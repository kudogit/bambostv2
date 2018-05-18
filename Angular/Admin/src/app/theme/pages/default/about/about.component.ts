import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { AboutService } from '../../../../_services/about.service';
import { MessageService } from 'primeng/components/common/messageservice';
import { Message } from 'primeng/primeng';
import { Router } from '@angular/router';
@Component({
    selector: 'app-about',
    templateUrl: './about.component.html',
    styleUrls: ['./about.css'],
    encapsulation: ViewEncapsulation.None,
})
export class AboutComponent implements OnInit {
    public abouts: any[];
    public selectedAbout = { description: '', id: 0 }
    description: string = '';
    msgs: Message[] = [];
    public size = [
        { id: 0, name: '5' },
        { id: 1, name: '10' },
        { id: 2, name: '20' }
    ]
    constructor(
        private aboutService: AboutService,
        private messageService: MessageService,
        private router: Router
    ) { }

    ngOnInit() {
        this.aboutService.getAbouts().subscribe(data => {
            this.abouts = data;
        })
    }

    edit(about) {
        about.IsEdit = true;
        this.selectedAbout.id = about.id;
    }

    save(about) {
        about.IsEdit = false;
        this.selectedAbout.description = this.description;
        console.log(this.selectedAbout);
        this.aboutService.updateAbout(this.selectedAbout).subscribe(data => {
            this.msgs.push({ severity: 'success', summary: 'Thông Tin', detail: 'Lưu Thành Công' });

            setTimeout(() => {
                window.location.reload();
            }, 2000);

        });
    }

    cancel(about) {
        about.IsEdit = false;
    }

    clear() {
        this.messageService.clear();
    }

    Create() {
        this.router.navigateByUrl('about/create');
    }

}
