import { Injectable } from '@angular/core';

import { NzNotificationService } from 'ng-zorro-antd';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  constructor(private notifier: NzNotificationService) { }

  public success(title: string, content?: string, options?: object) {
    this.notifier.success(title, content, options || {
      nzStyle: {
        width: '400px'
      }
    })
  }

  public error(title: string, content?: string, options?: object) {
    this.notifier.error(title, content, options || {
      nzStyle: {
        width: '400px'
      }
    })
  }

  public info(title: string, content?: string, options?: object) {
    this.notifier.info(title, content, options || {
      nzStyle: {
        width: '400px'
      }
    })
  }

  public warning(title: string, content?: string, options?: object) {
    this.notifier.warning(title, content, options || {
      nzStyle: {
        width: '400px'
      }
    })
  }
}
