import { IProduct } from './product';

export interface Pagination {
  currentPage : number;
  itemsPerPage: number;
  totalItems: number;
  totalPages: number;
  //data: IProduct[];
}

export class PaginatedResutlt<T> { // Same as paginatedResutlt<IProduct[]> but we use as generic, T is array of products

  result: T; // List of product in result property
  pagination: Pagination;


}

