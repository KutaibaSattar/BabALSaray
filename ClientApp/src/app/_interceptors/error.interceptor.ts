import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { catchError} from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor( private router: Router, private toastr: ToastrService) {} // router for roue to errors page

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError( error => {  // maping catch error
        if (error) {

          switch (error.status) {
            case 400: // bad request
              if (error.error.errors) {

                const modalStateError = [];
                for (const key in error.error.errors) {
                  if (error.error.errors[key]) {
                    modalStateError.push(error.error.errors[key]);
                    this.toastr.error(error.error.errors[key]);
                  }
                }

                // throw modalStateError.flat();


              } else {
                this.toastr.error(error.statusText, error.status);

              }
            break;

            case 401: // auth
            this.toastr.error(error.error.message, error.error.statusCode);
              break;
            case 404: // not found
              this.router.navigateByUrl('/not-found');
              break;
            case 500: // server inetrnal error
              const navigationExtras: NavigationExtras = { state: { error: error.error } };
              this.router.navigateByUrl('/server-error', navigationExtras);
              break;
            default:
            this.toastr.error('Something unexpected went wrong');
            console.log(error);
            break;
          }

        }
        return throwError(error);

      })

    );
  }
}
