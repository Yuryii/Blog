import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {
  ButtonModule,
  CardModule,
  FormModule,
  GridModule,
} from '@coreui/angular';
import { IconModule } from '@coreui/icons-angular';
import { PostComponent } from './post/post.component';
import { ContentRoutingModule } from './content-routing.module';

@NgModule({
  imports: [
    ContentRoutingModule,
    CommonModule,
    CardModule,
    ButtonModule,
    GridModule,
    IconModule,
    FormModule,
  ],
  declarations: [PostComponent],
})
export class ContentModule {}
