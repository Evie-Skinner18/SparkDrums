export interface IProductInventory {
    id: number;
    product: IProduct;
    quantityAvailable: number;
    idealQuantity: number;
    createdOn: Date;
    updatedOn: Date;
}

export interface IProduct {
    id: number;
    name: string;
    category: string;
    description: string;
    price: number;
    isTaxable: boolean;
    isArchived: boolean;
    isOnSale: boolean;
    createdOn: Date;
    updatedOn: Date;
}