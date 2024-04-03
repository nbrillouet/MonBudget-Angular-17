export class AsiFolder {
    id: number = null;
    label: string = null;
    image: string = null;
    countFile: number = null;
}

export class AsiFile {
    id: number = null;
    fileImport: string = null;
    dateImport: Date = null;
}

export class AsiFolderExplorer {
    idFolder: number = null;
    folders: AsiFolder[] = [];
    files: AsiFile[] = [];
    countFolder: number = null;
    countFile: number = null;
}
