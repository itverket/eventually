import { Pipe, PipeTransform } from '@angular/core';
import { IEvent } from '../interfaces/IEvent';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(events: IEvent[], filterBy: string): IEvent[] {

    if(!filterBy){
      return events;
    }
    
    return events.filter(x =>
      x.title.toLowerCase().indexOf(filterBy) != -1 ||
        x.location.indexOf(filterBy) != -1  ||
        x.description.indexOf(filterBy) != -1
    )
  }
}
