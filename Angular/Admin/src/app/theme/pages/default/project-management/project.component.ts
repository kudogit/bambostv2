import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";

@Component({
    selector: 'app-project',
    templateUrl: './project.component.html',
    styles: [
        'project.css'
    ]
})
export class ProjectComponent implements OnInit {

    public projectTypeId: number;

    constructor(private route: ActivatedRoute) {
        this.route.params.subscribe(params => {
            this.projectTypeId = params["id"]
        });
    }

    ngOnInit() {
    }

}
