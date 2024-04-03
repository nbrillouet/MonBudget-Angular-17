import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { fuseAnimations } from '@fuse/animations';
import { AuthService } from 'app/core/auth/auth.service';
import { AsifGroupByAccounts } from 'app/model/account-statement-import/account-statement-import-file.model';
import { AsiService } from 'app/services/account-statement/account-statement-import/asi.service';
import { FileUploader } from 'ng2-file-upload';
import { AsiUploadService } from './asi-upload.service';
import { ToastrService } from 'ngx-toastr';

// styleUrls: ['./asi-upload.component.scss'],
@Component({
    selector: 'asi-upload',
    templateUrl: './asi-upload.component.html',
    styleUrls: ['./asi-upload.component.scss'],
    animations   : fuseAnimations
  })
  export class AsiUploadComponent implements OnInit {
    @Output() fileInProgress = new EventEmitter<boolean>();
    @Output() fileError= new EventEmitter<boolean>();
    @Output() fileSuccess= new EventEmitter<boolean>();
    @Output() uploadResponse= new EventEmitter<AsifGroupByAccounts>();

    uploader: FileUploader = new FileUploader({url:''});
    hasBaseDropZoneOver: boolean = false;

    constructor(
      private _toastrService: ToastrService,
      private _asiService: AsiService,
      private _authService: AuthService,
      private _asiUploadService: AsiUploadService
    ) { }

    ngOnInit(): void {
    //   this.fileInProgress.emit(false);
    //   this.fileError.emit(false);
    //   this.fileSuccess.emit(false);
    //   this.initializeUploader();
    }

    uploadFile(fileList: FileList): void
    {
         // Return if canceled
        if ( !fileList.length )
        {
            return;
        }

        const allowedTypes = ['text/csv','.csv', 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet', 'application/vnd.ms-excel'];
        const file = fileList[0];

        // Return if the file is not allowed
        if ( !allowedTypes.includes(file.type) )
        {
            return;
        }

        const formData = new FormData();

        formData.append(file.name, file);


        // Upload the file
        this._asiService.uploadFile(this._authService.user, formData );
        // this._profileService.changeAvatar(Number(this._profileService.profileForm.getValue(x=>x.id)), formData);
    }

    public fileOverBase(e: any): void {
      this.hasBaseDropZoneOver = e;
    }

    // loadFile($event) {

    // }

    initializeUploader(): void {

      this.uploader = this._asiUploadService.uploader();
    //    new FileUploader({
    //     url: `${this.baseUrl}account-statement-import/users/${this.user.id}/upload-file`,
    //     authToken: `Bearer ${this.user.token}`, // 'Bearer ' + localStorage.getItem('currentUser').token,
    //     isHTML5: true,
    //     // allowedMimeType: ['text/csv'], // CSV File limitation,
    //     // allowedFileType: ['application'],
    //     // allowedMimeType: ['application/vnd.ms-excel'],
    //     removeAfterUpload: true,
    //     autoUpload: false,
    //     maxFileSize: 10*1024*1024,
    //     queueLimit : 1
    //   });

      this.uploader.onSuccessItem = (item, response, status, headers): void => {
        if (response) {
          const asifGroupByAccounts = JSON.parse(response) as AsifGroupByAccounts;
          this.fileSuccess.emit(true);
          this.uploadResponse.emit(asifGroupByAccounts);

          this._toastrService.success('Enregistrement réussi', 'Relevé chargé');

        }
      };

      this.uploader.onWhenAddingFileFailed = (item: any, filter: any, options: any): void => {
        this._toastrService.error('Type de fichier incorrect', 'Le fichier doit être de type .csv');
      };

      this.uploader.onProgressAll = (fileItem): void => {
        this.fileInProgress.emit(true);
        this.fileError.emit(false);
        this.fileSuccess.emit(false);
      };

      this.uploader.onCompleteItem = (item, response, status, headers): void => {
        this.fileInProgress.emit(false);
      };

      this.uploader.onErrorItem = ((item, response, status, headers): void => {
        this.fileError.emit(true);
        this.fileInProgress.emit(false);
        const error = this.handleError(response);
        this._toastrService.error('Erreur', error);
        });
    }

    private handleError(error): any {
        const serverError = JSON.parse(error);
        let modelStateErrors = '';
        if(serverError) {
            for(const key in serverError)
            {
                if(serverError[key]){
                    modelStateErrors += serverError[key] + '\n';
                }
            }
        }
        return modelStateErrors;
    }

  }
