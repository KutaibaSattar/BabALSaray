

let i = 5;

let s: string;
interface RootObject {
  id: number;
  name: string;
  description: string;
  price: number;
  pictureUrl: string;
  productType: string;
  productBrand: string;
}

interface ICar {

color: string;
model?: string;
speed?: number;

}

const car: ICar = {
    color : 'read'

};

const  multiply = (x: any, y: any): string => {
  return  ( x * y).toString() ;

};

