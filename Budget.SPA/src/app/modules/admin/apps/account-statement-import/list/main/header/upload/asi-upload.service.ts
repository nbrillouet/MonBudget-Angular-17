import { Injectable } from '@angular/core';
import { AuthService } from 'app/core/auth/auth.service';
import { environment } from 'environments/environment';
import { FileUploader } from 'ng2-file-upload';

@Injectable()
export class AsiUploadService
{
    private baseUrl = environment.apiUrl;

    constructor(
        private _authService: AuthService
    ) {  }

    public uploader(): FileUploader{
        return new FileUploader({
            url: `${this.baseUrl}account-statement-import/users/${this._authService.user.id}/upload-file`,
            authToken: `Bearer ${this._authService.user.token}`, // 'Bearer ' + localStorage.getItem('currentUser').token,
            isHTML5: true,
            // allowedMimeType: ['text/csv'], // CSV File limitation,
            // allowedFileType: ['application'],
            // allowedMimeType: ['application/vnd.ms-excel'],
            removeAfterUpload: true,
            autoUpload: false,
            maxFileSize: 10*1024*1024,
            queueLimit : 1
          });
    }
}
