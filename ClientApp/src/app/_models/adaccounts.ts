export interface dbAccounts {
    id: number;
    key: string;
    name: string;
    lvl: number;
    created: Date;
    lastActive: Date;
    parentId: any;

    children : dbAccounts[]

  }