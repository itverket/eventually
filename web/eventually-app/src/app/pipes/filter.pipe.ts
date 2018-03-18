import { Pipe, PipeTransform } from '@angular/core';
import { IEvent } from '../interfaces/IEvent';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(events: IEvent[], filterBy: string): IEvent[] {

    if (!filterBy || filterBy.length < 3) {
      return events;
    }
    var filterWithRemovedWhitespaces  = filterBy.toLowerCase().trim().replace(/  +/g, ' ');

    var filters = filterWithRemovedWhitespaces.split(" ").filter(x => x.length > 2);

    return events.filter(x =>
    filters.some(filter => x.name && x.name.toLowerCase().indexOf(filter) != -1) ||
    filters.some(filter => x.location && x.location.toLowerCase().indexOf(filter) != -1) ||
    filters.some(filter => x.description && x.description.toLowerCase().indexOf(filter) != -1)
    )
  }
}
