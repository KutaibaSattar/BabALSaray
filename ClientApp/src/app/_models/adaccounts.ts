export interface dbAccounts {
    id: number;
    key: string;
    name: string;
    lvl: number;
    created: Date;
    lastActive: Date;
    parentId: any;
    line1:string
    line2 :string
    email :string
    region :string
    city :string
    country :string
    children : dbAccounts[]

  }