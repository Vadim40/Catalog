
import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable, debounceTime, filter, distinctUntilChanged, tap, switchMap, catchError, of } from 'rxjs';
import { PhoneVariant } from 'src/app/models/phone/phoneVariant';
import { PhoneService } from 'src/app/services/phone.service';

@Component({
  selector: 'app-add-phone',
  templateUrl: './add-phone.component.html',
  styleUrls: ['./add-phone.component.css']
})
export class AddPhoneComponent {
 

  
  searchCtrl = new FormControl;
  variants$?: Observable<PhoneVariant[]>

  selectedVariant: PhoneVariant | null = null;

  constructor(
 
   private phoneService: PhoneService,

  ){
  }

  ngOnInit(){
    this.variants$ = this.searchCtrl.valueChanges.pipe(
      debounceTime(300),
      filter(val => typeof val === 'string' && !!val.trim() ),
      distinctUntilChanged((a, b) => a.trim() === b.trim()),
      tap(),
      switchMap( name => 
        this.phoneService.searchVariant(name).pipe(
           catchError(err => {
                      console.error(err);
                      return of([]);
                    })
        )
      )
    )
  }

  onSelectVariant(variant: PhoneVariant) {
    this.selectedVariant=variant;
  }


  
}
