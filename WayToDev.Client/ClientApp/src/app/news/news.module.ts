import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsPageComponent } from './components/news-page/news-page.component';
import { NewsPreviewComponent } from './components/news-preview/news-preview.component';
import { AllNewsPageComponent } from './components/all-news-page/all-news-page.component';
import { NewsRoutingModule } from './news-routing.module';
import { UiModule } from '../ui/ui.module';
import {StoreModule} from "@ngrx/store";
import {newsReducers} from "./store/news.reducers";
import {EffectsModule} from "@ngrx/effects";
import {NewsEffects} from "./store/news.effects";
import {NgxPaginationModule} from "ngx-pagination";
import {FormsModule} from "@angular/forms";

@NgModule({
    declarations: [
        NewsPageComponent,
        NewsPreviewComponent,
        AllNewsPageComponent
    ],
    imports: [
        NewsRoutingModule,
        CommonModule,
        UiModule,
        StoreModule.forFeature('news', newsReducers),
        EffectsModule.forFeature([NewsEffects]),
        NgxPaginationModule,
        FormsModule
    ]
})
export class NewsModule { }
