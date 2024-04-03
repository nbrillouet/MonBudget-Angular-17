import { UserForAuth } from 'app/model/referential/user/user.model';

export const ASI_LIST_LOAD = 'asi-list-load';
export const ASI_FOLDER_EXPLORER_LOAD = 'asi-folder-explorer-load';
export const ASI_FOLDER_EXPLORER_CHANGE = 'asi-folder-explorer-change';
export const ASI_FILE_UPLOAD = 'asi-file-upload';

export class LoadAsiList {
    static readonly type = ASI_LIST_LOAD;

    constructor(public payload: { idUser: number }) { }
}

export class LoadAsiFolderExplorer {
    static readonly type = ASI_FOLDER_EXPLORER_LOAD;

    constructor(public payload: { idUser: number }) { }
}

export class ChangeAsiFolderExplorer {
    static readonly type = ASI_FOLDER_EXPLORER_CHANGE;

    constructor(public payload: { idUser: number; idFolder: number }) { }
}

export class UploadAsiFile {
    static readonly type = ASI_FILE_UPLOAD;

    constructor(public payload: { user: UserForAuth; formData: FormData }) {}
}
