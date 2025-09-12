import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable()
export class GlobalErrorInterceptor implements HttpInterceptor {


  constructor(private snackBar: MatSnackBar) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        let message = 'Unexpected error occurred';
        
        const problem = error.error;
        message = `${problem.detail ?? problem.title}`;

        this.snackBar.open(message, 'Close', {
          duration: 5000,
          verticalPosition: 'top',      
          horizontalPosition: 'center', 
        });
        
        return throwError(() => error);
      })
    );
  }
}
